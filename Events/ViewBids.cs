namespace Auctionhouse
{
    class ViewBids : IEvent 
    {
        public const string noBiddedProducts = "There has not been a bid on any of your products yet.";
        /// <summary>
        /// this list stores the products of user that it has been bidded
        /// </summary>
        private List<Product> _myBiddedProducts;

        public string TITLE {get; set;}

        public ViewBids()
        {
            this.TITLE = $"List Product Bids for {DBMS.database.cursor.Name}({DBMS.database.cursor.Email})\n------------------------------------------------------------------------\n";
            
        }

        /// <summary>
        /// The function is that ran when for letting user view people's bids on their products
        /// </summary>

        public void Run()
        {
            _myBiddedProducts = new List<Product>();
            Console.WriteLine(this.TITLE);
            foreach(Product product in DBMS.database.cursor.AdvertisedProducts)
            {
                if (UI.IsValidEmailAddress(product.bidderEmail))
                {
                    _myBiddedProducts.Add(product);
                }
                
            }
            try
            {
                UI.DisplayProducts(_myBiddedProducts, noBiddedProducts);
                SellProduct();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            

        }

        /// <summary>
        /// The function responsible for asking user whether they want to sell a product from the list of products other users have bidded
        /// </summary>
        private void SellProduct()
        {
            string sellProduct = UI.GetInput("Would you like to sell something (yes or no)?");
            if (sellProduct.ToUpper() == "YES")
            {
                SelectOption selectSellProduct = new SelectOption(1, _myBiddedProducts.Count());
                selectSellProduct.GetInput();
                Product selectedProduct = _myBiddedProducts[int.Parse(selectSellProduct.ToString())-1];
                DBMS.database.RemoveProductFromUser(selectedProduct);
                DBMS.database.SendProductToBidder(selectedProduct);
                Console.WriteLine($"You have sold {selectedProduct.ProductName} to {selectedProduct.BidderName} for {selectedProduct.BidPrice}.");
            }
            else if (sellProduct.ToUpper() == "NO")
            {

            }
            else
            {
                Console.WriteLine("Please choose yes or no");
                this.SellProduct();
            }
        }

    }   
}