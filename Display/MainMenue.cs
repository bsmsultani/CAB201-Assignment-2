namespace Auctionhouse
{
    /// <summary>
    /// Menu which is responsible for creating a client menu and configuring it
    /// With the list of buttons and their respective Event in case the button is pressed
    /// </summary>
    class MainMenu : Menu
    {
        /// <summary>
        /// A type of Event responsible for registering the user
        /// </summary>
        private IEvent registeration;
        /// <summary>
        /// A type of Event responsible for singing in the user 
        /// </summary>
        private IEvent signIn;
        /// <summary>
        /// A type of Event responsible for exiting the program
        /// </summary>
        private IEvent exit;

        /// <summary>
        /// Constructor, settign the above Events to their approperiate Event type
        /// </summary>
        public MainMenu()
        {
            this.registeration = new Registeration();
            this.signIn = new SignIn();
            this.exit = new Exit(this);

        }

        /// <summary>
        /// Inherited function which is executed when parent function's StartDisplay() is called, allows for configuring any Menu
        /// In this case Buttons and their respective Event Trigger is added for the Main Menu (which is a type of Menu)
        /// </summary>
        public override void Configure()
        {
            this.TITLE = "Main Menu\n---------";
            this.Buttons.Add(new Button("Register", registeration));
            this.Buttons.Add(new Button("Sign In", signIn));
            this.Buttons.Add(new Button("Exit", exit));
        }
    }
}