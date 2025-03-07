namespace Auctionhouse
{
    class ViewPurchased : IEvent 
    {
        public string TITLE {get; set;}
        public ViewPurchased()
        {
            this.TITLE = $"Purchased Items for {DBMS.database.cursor.Name}({DBMS.database.cursor.Email})\n----------------------------------------------------------------------------\n";
        }


        /// <summary>
        /// The function ran when user wants too see their purchased products
        /// </summary>

        public void Run()
        {
            Console.WriteLine(this.TITLE);
            try
            {
                UI.DisplayProducts(DBMS.database.cursor.PurchasedProducts, "You have not purchased any products yet.");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            

        }
        
    }
}