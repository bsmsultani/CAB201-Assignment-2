namespace Auctionhouse
{
    /// <summary>
    /// Event triggered when user wants to exit the program
    /// </summary>
    class Exit : IEvent
    {
        public string TITLE {get; set;}
        Menu _mainMenu;
        
        /// <summary>
        /// gets the instance of the Main Menu
        /// </summary>
        /// <param name="mainMenu">the instance of the Main Menu passed by the Main Menu</param>
        public Exit(Menu mainMenu)
        {
            _mainMenu = mainMenu;
            this.TITLE = "+--------------------------------------------------+\n| Good bye, thank you for using the Auction House! |\n+--------------------------------------------------+";
        }
        
        /// <summary>
        /// Displays good by message, saves the database and stops displaying the main menu
        /// </summary>
        public void Run()
        {
            Console.WriteLine(TITLE);
            DBMS.database.Commit();
            _mainMenu.StopDisplay();
        }
        
    }
}