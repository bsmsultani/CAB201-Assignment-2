namespace Auctionhouse
{
    /// <summary>
    /// A type of Event which enables the registerations of a new user
    /// </summary>
    class Registeration : IEvent
    {
        public  string TITLE {get; set;}
        public Registeration() 
        {
            this.TITLE = "Registration\n------------\n";
        }

        /// <summary>
        /// Function automatically run when buttons is 'pressed'
        /// Its gets user input, displays any exception if user input does not meet 
        /// the field requirements (such as Name cannot be empty string etc.) this is determined by the setter of that field
        /// After getting name, email and password, it registers the user into the database
        /// </summary>
        public void Run()
        {        
            Console.WriteLine(this.TITLE);    
            User registerUser = new User();
            while (true)
            {
                try
                {
                    registerUser.Name = UI.GetInput("Please enter your name");
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
                    string userinput = UI.GetInput("Please enter your email address");
                    if (DBMS.database.EmailExists(userinput))
                    {
                        throw new Exception("Email is already being used");
                    }
                    else
                    {
                        registerUser.Email = userinput;
                        break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            while (true)
            {
                try
                {
                    registerUser.Password = UI.GetInput("Please choose a password\n* At least 8 characters\n* No white space characters\n* At least one upper-case letter\n* At least one lower-case letter\n* At least one digit\n* At least one special character");
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            
            DBMS.database.AddUserToDatabase(registerUser);            
            Console.WriteLine($"Client {registerUser.Name}({registerUser.Email}) has successfully registered at the Auction House.\n");

        }
    }
}