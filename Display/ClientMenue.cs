namespace Auctionhouse
{
    /// <summary>
    /// Menu which is responsible for creating a client menu and configuring it
    /// With the list of buttons and their respective Event in case the button is pressed
    /// </summary>
    class ClientMenu : Menu
    {
        /// <summary>
        /// Type of Event reponsible for advertising user products
        /// </summary>
        private IEvent advertiseProduct;
        /// <summary>
        /// Type of Event reponsible for displaying user's advertised products
        /// </summary>
        private IEvent viewMyProduct;
        /// <summary>
        /// Type of Event responsible for searching products by other users
        /// </summary>
        private IEvent searchForProduct;
        /// <summary>
        /// Type of Event responsible for displaying bids on user products
        /// </summary>
        private IEvent viewBids;
        /// <summary>
        /// Type of Event responsible for displaying user's purchased products
        /// </summary>
        private IEvent viewPurchased;
        /// <summary>
        /// Type of Event responsible logging off the user
        /// </summary>
        private IEvent logOff;

        /// <summary>
        /// Constructor which sets the above Events to their approperiate types
        /// </summary>
        public ClientMenu()
        {
            this.advertiseProduct = new AdvertiseProduct();
            this.viewMyProduct = new ViewMyProduct();
            this.searchForProduct = new SearchForProduct();
            this.viewBids = new ViewBids();
            this.viewPurchased = new ViewPurchased();
            this.logOff = new LogOff(this);
        }


        /// <summary>
        /// Inherited function which is executed when parent function's StartDisplay() is called, allows for configuring any Menu
        /// In this case Buttons and their respective Event Trigger is added for the client menu
        /// </summary>

        public override void Configure()
        {
            this.TITLE = "Client Menu\n-----------";
            this.Buttons.Add(new Button("Advertise Product", advertiseProduct));
            this.Buttons.Add(new Button("View My Product List", viewMyProduct));
            this.Buttons.Add(new Button("Search For Advertised Products", searchForProduct));
            this.Buttons.Add(new Button("View Bids On My Products", viewBids));
            this.Buttons.Add(new Button("View My Purchased Items", viewPurchased));
            this.Buttons.Add(new Button("Log off", logOff));
        }
    }
}