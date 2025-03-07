namespace Auctionhouse
{
    /// <summary>
    /// The Event which allows the user to sign in 
    /// </summary>
    class SignIn : IEvent 
    {
        public string TITLE {get; set;}
        /// <summary>
        /// 
        /// </summary>
        private ClientMenu _clientMenue;
        public SignIn() 
        {
            this.TITLE = "Sign In\n-------";
        }

        /// <summary>
        /// The function which is ran when user chooses to trigger this event (by clicking login button)
        /// Gets the user information (email and password) and authenticates the user
        /// If authentication is sucessfull, then it creates a new client menu for the user 
        /// </summary>
        public void Run()
        {
            Console.WriteLine(this.TITLE);
            string email = UI.GetInput("Please enter your email address");
            if (DBMS.database.EmailExists(email))
            {
                string password = UI.GetInput("Please enter your password");
                if (DBMS.database.Login(email, password))
                {
                    if (!DBMS.database.cursor.HasAddress())
                    {
                        Console.WriteLine($"Personal Details for {DBMS.database.cursor.Name}({DBMS.database.cursor.Email})\n----------------------------------------------------------------------------");
                        Console.WriteLine("\nPlease provide your home address.");
                        DBMS.database.cursor.HomeAddress.GetAddress();
                        Address homeAdress = DBMS.database.cursor.HomeAddress;
                        Console.WriteLine("Address has been updated to {0}/{1} {2} {3}, {4} {5} {6}", homeAdress.HouseNumber, homeAdress.StreetNumber, homeAdress.StreetName, homeAdress.StreetSuffix, homeAdress.CityName, homeAdress.StateName, homeAdress.Postcode);
                    }

                    _clientMenue = new ClientMenu();
                    _clientMenue.startDisplay();
                }
                else
                {
                    Console.WriteLine("The provided password does not match this email!");
                }

            }
            else
            {
                Console.WriteLine("This email does not belong to any users");
            }
        }
    }
}