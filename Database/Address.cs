namespace Auctionhouse
{

    public class Address
    {
        /// <summary>
        /// is used to store the House Number of an Address
        /// </summary>
        private string _houseNumber;

        /// <summary>
        /// Manages access to _houseNumber by other classes.
        /// Validates any attempt to change _houseNumber
        /// Same for all of the feilds below
        /// </summary>
         public string HouseNumber
        {
            get
            {
                return _houseNumber;
            }
            set
            {
                if (!UI.StringNotEmpty(value))
                {
                    _houseNumber = "0";
                }
                else
                {
                    if (UI.IsValidNumber(value))
                    {
                        _houseNumber = value;
                    }
                    else
                    {
                        throw new Exception("Invalid house number");
                    }
                }
            }
        }

        private string _streetNumber;
        public string StreetNumber
        {
            get
            {
                return _streetNumber;
            }
            set
            {
                if (UI.StringNotEmpty(value))
                {
                    if (UI.IsValidNumber(value))
                    {
                        _streetNumber = value;
                    }
                    else
                    {
                        throw new Exception("Invalid number street number");
                    }
                }
                else
                {
                    throw new InputEmptyException("Street number");
                }
            }
        }

        private string _streetName;
        public string StreetName
        {
            get
            {
                return _streetName;
            }
            set
            {
                if (UI.StringNotEmpty(value))
                {
                    _streetName = value;
                }
                else
                {
                    throw new InputEmptyException("Street name");
                }

            }
        }

        private string _streetSuffix;
        public string StreetSuffix
        {
            get
            {
                return _streetSuffix;
            }
            set
            {
                if (UI.StringNotEmpty(value))
                {
                    _streetSuffix = value;
                }
                else
                {
                    throw new InputEmptyException("Street suffix");
                }
            }
        }

        private string _cityName;
        public string CityName
        {
            get
            {
                return _cityName;
            }
            set
            {
                if (UI.StringNotEmpty(value))
                {
                    _cityName = value;
                }
                else
                {
                    throw new InputEmptyException("City name");
                }
            }
        }

        private string _postcode;
        public string Postcode
        {
            get
            {
                return _postcode;
            }
            set
            {
                if (UI.StringNotEmpty(value))
                {
                    if (UI.IsValidNumber(value))
                    {
                        int intPostCode = int.Parse(value);
                        if (intPostCode >= 1000 && intPostCode <= 9999)
                        {
                            _postcode = value;
                        }
                        else
                        {
                            throw new Exception("Invalid postcode range");
                        }
                    }
                    else
                    {
                        throw new Exception("Invalid number");
                    }
                }
                else
                {
                    throw new InputEmptyException("Postcode");
                }
            }
        }


        private string _stateName;
        public string StateName
        {
            get
            {
                return _stateName;
            }
            set
            {
                if (UI.StringNotEmpty(value))
                {
                    if (UI.IsValidStateName(value))
                    {
                        _stateName = value;
                    }
                    else
                    {
                        throw new Exception("Invalid state name");
                    }
                }
                else
                {
                    throw new InputEmptyException("City name");
                }
            }
        }

        /// <summary>
        /// Constructor, sets a default value
        /// This is changed when user signs in
        /// </summary>
        public Address()
        {
            _houseNumber = "4444";
            _streetNumber = "4444";
            _streetName = "4444";
            _streetSuffix = "4444";
            _cityName = "4444";
            _postcode = "4444";
            _stateName = "QLD";       
        }

        /// <summary>
        /// Gets user input for Address fields
        /// Validates the user input through setting it via the property,
        /// If successful, moves to next instruction, else writes exception message
        /// and lets user try again
        /// </summary>
        public void GetAddress()
        {
            while(true)
            {
                try
                {
                    this.HouseNumber = UI.GetInput("Unit number (0 = none):");
                    break;
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
                    this.StreetNumber = UI.GetInput("Street number:");
                    break;
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
                    this.StreetName = UI.GetInput("Street name:");
                    break;
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
                    this.StreetSuffix = UI.GetInput("Street suffix:");
                    break;
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
                    this.CityName = UI.GetInput("City:\n");
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
                    this.StateName = UI.GetInput("State (ACT, NSW, NT, QLD, SA, TAS, VIC, WA):");
                    break;
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
                    this.Postcode = UI.GetInput("Postcode (1000 .. 9999):");
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

        }
    }
}