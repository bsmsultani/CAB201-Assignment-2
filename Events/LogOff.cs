namespace Auctionhouse
{
    /// <summary>
    /// A type of Event which is executed when the user chooses to log off
    /// </summary>
    class LogOff : IEvent 
    {
        /// <summary>
        /// No need to display the title for logging off as it currently doesn't have one
        /// </summary>
        /// <value></value>
        public string TITLE {get; set;}
        Menu _menu;

        /// <summary>
        /// Constructor copies the instance of the client menu
        /// </summary>
        /// <param name="clientMenu"></param>
        public LogOff(Menu clientMenu)
        {
            _menu = clientMenu;
        }

        /// <summary>
        /// Stops the display of the Menu that is passed (client menu in this assignment)
        /// But could be used for any menu of type Menu
        /// </summary>
        public void Run()
        {
            _menu.StopDisplay();
        }
        
    }
}
