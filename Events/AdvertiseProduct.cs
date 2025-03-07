namespace Auctionhouse
{
    /// <summary>
    /// Type of Event which allows the user to advertise products 
    /// </summary>
    class AdvertiseProduct : IEvent 
    {
        public string  TITLE {get; set;}
        public AdvertiseProduct() 
        {
            this.TITLE = $"Product Advertisement for {DBMS.database.cursor.Name}({DBMS.database.cursor.Email})\n---------------------------------------------------------------------------------";
        }

        /// <summary>
        /// The function that is ran when Button is pressed for advertising product
        /// Gets product information and adds it to the user's advertised product list
        /// If user input does not meet the requirements for setting product information (such as empty string but generally it depends on the field being set), 
        /// The approperiate error message which is determined by the product field that is being set
        /// Is thrown and written to the console until the user types the correct product information
        /// /// /// </summary>
        public void Run()
        {
            Console.WriteLine(this.TITLE);

            Product newProduct = new Product();

            while (true)
            {
                try
                {
                    newProduct.ProductName = UI.GetInput("Product name");
                    break;
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            while (true)
            {
                try
                {
                    newProduct.ProductDescription = UI.GetInput("Product description");
                    break;
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            
            while (true)
            {
                try
                {
                    newProduct.ProductPrice = UI.GetInput("Product price ($d.cc)");
                    break;
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            DBMS.database.cursor.AdvertisedProducts.Add(newProduct);
            Console.WriteLine($"Successfully added product {newProduct.ProductName}, {newProduct.ProductDescription}, {newProduct.ProductPrice}.");
        }
        
    }
}