
namespace Auctionhouse
{
    /// <summary>
    /// Event which allows the user to search for products and place bid on them
    /// </summary>
    class SearchForProduct : IEvent 
    {
        public string TITLE {get; set;}
        /// <summary>
        /// the variable where all of the adverised product is stored 
        /// </summary>
        private List<Product> _advertisedProducts;
        /// <summary>
        /// the variable responsible for storing the products the user searches
        /// </summary>
        private List<Product> _filteredProducts;
        
        /// <summary>
        /// Error messages & input message
        /// </summary>
        private const string noProductWarning = "There is no product that could be found";
        private const string askForSearchMessage = "Please supply a search phrase (ALL to see all products)";
        private const string askPlaceBidMessage = "Would you like to place a bid on any of these items (yes or no)?";

        public SearchForProduct()
        {
            this.TITLE = $"Product Search for {DBMS.database.cursor.Name}({DBMS.database.cursor.Email})\n--------------------------------------------------------------------------";
        }

        /// <summary>
        /// The method first run when user chooses to search for product
        /// Based on user input, it shows all or queryable products
        /// </summary>
        public void Run()
        {
            _advertisedProducts = DBMS.database.GetAdvertisedProducts();
            _filteredProducts = new List<Product>();
            Console.WriteLine(this.TITLE);
            Console.WriteLine("\n\nSearch results\n--------------");
            string searchInput = UI.GetInput(askForSearchMessage);
            if (searchInput.ToUpper() == "ALL")
            {
                _filteredProducts = _advertisedProducts;
            }
            else
            {
                foreach(Product product in _advertisedProducts)
                {
                    if (product.HasKeyWord(searchInput))
                    {
                        _filteredProducts.Add(product);
                    }
                }                
            }

            UI.SortProducts(ref _filteredProducts);
            
            try
            {
                UI.DisplayProducts(_filteredProducts, noProductWarning);
                BidProduct(_filteredProducts);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Allows the user to bid a product from the list of products displayed based on user search
        /// If the user want to bid on the product, it will ask the bid information and validate it
        /// </summary>
        /// <param name="products">List of products the user can place bid on</param>
        public void BidProduct(List<Product> products)
        {
            string placebid = UI.GetInput(askPlaceBidMessage);
            if (placebid.ToUpper() == "YES")
            {
                ConsoleInput selectProduct = new SelectOption(1, products.Count());
                selectProduct.SetAskFor($"Please enter a non-negative integer between 1 and {products.Count()}:");
                selectProduct.GetInput();
                Product selectedProduct = products[int.Parse(selectProduct.ToString())-1];
                Console.WriteLine($"Bidding for {selectedProduct.ProductName}(regular price {selectedProduct.ProductPrice}), current highest bid {selectedProduct.BidPrice}");
                while (true)
                {
                    /// validate bid price (determine whether it is higher than the current bid price)
                    /// while (true)
                    try
                    {
                        string bidAmount = UI.GetInput("How much do you bid?");
                        if (UI.isValidBidPrice(bidAmount, selectedProduct.BidPrice))
                        {
                            selectedProduct.BidPrice = bidAmount;
                            selectedProduct.BidderName = DBMS.database.cursor.Name;
                            selectedProduct.bidderEmail = DBMS.database.cursor.Email;
                            Console.WriteLine($"Your bid of {bidAmount} for {selectedProduct.ProductName} is placed.\n");
                            break;
                        }
                        else
                        {
                            throw new Exception($"\tBid amount must be greater than ({selectedProduct.BidPrice})");
                        }

                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                GetDelivery(selectedProduct);
            }
            else
            {
                
            }
        }

        /// <summary>
        /// Gets the type of delivery for the selected product
        /// </summary>
        /// <param name="product">The product to get the delivery for</param>
        private void GetDelivery(Product product)
        {
            Console.WriteLine("Delivery Instructions\n---------------------\n(1) Click and collect\n(2) Home Delivery");
            SelectOption deliveryOption = new SelectOption(1, 2);
            deliveryOption.GetInput();
            DateTime starttime;
            DateTime endtime;
            if (deliveryOption.ToString() == "1")
            {
                while (true)
                {
                    string startTime = UI.GetInput("Delivery window start (dd/mm/yyyy hh:mm)");
                    try
                    {
                        starttime = DateTime.Parse(startTime);
                        if (DateTime.Compare(starttime, DateTime.Now.AddHours(1)) == 1)
                        {
                            break;
                        }
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                while (true)
                {
                    string endTime = UI.GetInput("Delivery window end (dd/mm/yyyy hh:mm)");
                    try
                    {
                        endtime = DateTime.Parse(endTime);
                        break;
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                try
                {
                    product.startCollectionTime = starttime;
                    product.endCollectionTime = endtime;
                    Console.WriteLine($"Thank you for your bid. If successful, the item will be provided via collection between {starttime.ToString("HH:mm")} on {starttime.ToString("dd/MM/yyyy")} and {endtime.ToString("HH:mm")} on {endtime.ToString("dd/MM/yyyy")}");
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }


            }
            else
            {
                Console.WriteLine("Please provide your delivery address.");
                product.BidderDeliveryAddress = new Address();
                product.BidderDeliveryAddress.GetAddress();
                Console.WriteLine($"Thank you for your bid. If successful, the item will be provided via delivery to {product.BidderDeliveryAddress.HouseNumber}/{product.BidderDeliveryAddress.StreetNumber} {product.BidderDeliveryAddress.StreetName} {product.BidderDeliveryAddress.StreetSuffix}, {product.BidderDeliveryAddress.CityName} {product.BidderDeliveryAddress.StateName.ToUpper()} {product.BidderDeliveryAddress.Postcode}");
            }
        }
    }
}
