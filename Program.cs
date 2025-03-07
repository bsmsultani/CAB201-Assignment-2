namespace Auctionhouse

{
    /// <summary>
    /// Has the main method
    /// </summary>
    class Program
    {
        /// <summary>
        /// Entry to the application
        /// Creates a Database and Displays the Main Menu
        /// </summary>
        static void Main()
        {
            Console.WriteLine("+------------------------------+\n| Welcome to the Auction House |\n+------------------------------+\n");
            DBMS.LoadDatabase("database");
            Menu MainDiolog;
            MainDiolog = new MainMenu();
            MainDiolog.startDisplay();            
            
        }
    }
}