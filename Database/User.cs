namespace Auctionhouse
{
    sealed public class User
    {
        /// <summary>
        /// is used to store user's name
        /// </summary>
        private string _name;

        /// <summary>
        /// Manages access to _name by other classes.
        /// Validates any attempt to change _name
        /// Same for all of the feilds below
        /// </summary>
        public string Name
        {
            get 
            {
                return _name;
            }
            set
            {
                if (UI.StringNotEmpty(value))
                {
                    _name = value;
                }
                else
                {
                    throw new InputEmptyException("User name");
                }
            }
        }

        private string _email;
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                if (UI.StringNotEmpty(value))
                {
                    if (UI.IsValidEmailAddress(value))
                    {
                        _email = value;
                    }
                    else
                    {
                        throw new Exception("Invalid email address");
                    }
                }
                else
                {
                    throw new InputEmptyException("User email");
                }

            }
        }

        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                if(UI.StringNotEmpty(value))
                {
                    if (UI.IsValidPassword(value))
                    {
                        _password = value;
                    }
                    else
                    {
                        throw new Exception("Password does not meet the requirements!");
                    }
                }
                else
                {
                    throw new InputEmptyException("User password");
                }
            }
        }
        /// <summary>
        /// List of products the user is owned and is for selling
        /// </summary>
        /// <value></value>
        public List<Product> AdvertisedProducts {get; set;}
        /// <summary>
        /// List of products purchased products by the user
        /// </summary>
        /// <value></value>
        public List<Product> PurchasedProducts {get; set;}

        /// <summary>
        /// User's home address
        /// </summary>
        /// <value></value>
        public Address HomeAddress { get; set; }


        /// <summary>
        /// Constructor, sets default values
        /// </summary>
        public User()
        {
            this.AdvertisedProducts = new List<Product>();
            this.PurchasedProducts = new List<Product>();
            this.HomeAddress = new Address();
        }
        
        /// <summary>
        /// Checks to see if use has a home Address
        /// </summary>
        /// <returns>True if user has a home address</returns>
        public bool HasAddress()
        {
            if (this.HomeAddress == null)
            {
                return false;
            }
            else
            {
                if (this.HomeAddress.StreetName != "4444")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            
        }
                
    }
}