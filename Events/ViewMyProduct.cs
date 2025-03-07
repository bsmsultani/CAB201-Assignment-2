namespace Auctionhouse
{
    /// <summary>
    /// The Event responsible for displaying the user products that they have added to the system
    /// </summary>
    class ViewMyProduct : IEvent
    {
        public const string noProductAdded = "You have not added any products yet";
        public string TITLE {get; set;}

        public ViewMyProduct()
        {
            this.TITLE = $"Product List for {DBMS.database.cursor.Name}({DBMS.database.cursor.Email})";
        }

        

        /// <summary>
        /// The function ran when user wants view their product
        /// </summary>
        public void Run()
        {
            Console.WriteLine(this.TITLE);
            UI.DisplayProducts(DBMS.database.cursor.AdvertisedProducts, noProductAdded);
        }
        
    }
}