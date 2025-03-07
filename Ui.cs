using System.Text.RegularExpressions;
namespace Auctionhouse
{
    class UI
    {
        /// <summary>
        /// Gets user input 
        /// </summary>
        /// <param name="askFor">The message to display to the console</param>
        /// <returns></returns>
        public static string GetInput(string askFor)
        {
            Console.WriteLine(askFor);
            Console.Write("> ");
            string userinput = Console.ReadLine();
            Console.WriteLine();
            return userinput;
        }

        /// <summary>
        /// Checks if a string is 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool StringNotEmpty(string inputstr)
        {
            return string.IsNullOrEmpty(inputstr) || string.IsNullOrWhiteSpace(inputstr);
        }

        /// <summary>
        /// Checks if a userinput is a valid dollar mount
        /// </summary>
        /// <param name="dollar">The userinput for the dollar amount</param>
        /// <returns>True if userinput is a valid dollar (format) </returns>

        public static bool IsValidDollar(string dollar)
        {
            const string au_dollar = @"^\$[0-9]+.[0-9]{2}$";
            Regex au_dollarRegex = new Regex(au_dollar);
            if (au_dollarRegex.IsMatch(dollar))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        /// <summary>
        /// Checks if a given bid price is higher another bid price
        /// </summary>
        /// <param name="bidPrice">bid price to check</param>
        /// <param name="highestBidPrice">bid price to check against</param>
        /// <returns></returns>
        public static bool isValidBidPrice(string bidPrice, string highestBidPrice)
        {
            decimal bidderPrice = decimal.Parse(bidPrice.Substring(1, bidPrice.Length - 1));
            decimal highestPrice = decimal.Parse(highestBidPrice.Substring(1, highestBidPrice.Length - 1));
            return bidderPrice > highestPrice;
        }

        /// <summary>
        /// Checks to see if an email address is valid
        /// </summary>
        /// <param name="emailAddress">email address to check against</param>
        /// <returns>True if email address is valid</returns>
        public static bool IsValidEmailAddress(string emailAddress)
        {
            const string emailPattern = "^[a-z0-9A-Z][a-z0-9A-Z,_,.,-]+@[a-z0-9A-Z,_,.,-]+[.][a-z]+$";
            Regex validEmailPattern = new Regex(emailPattern);
            if (validEmailPattern.IsMatch(emailAddress))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// checks to see if the user input for password matches the requirements
        /// </summary>
        /// <param name="password">the password to check against</param>
        /// <returns></returns>
        public static bool IsValidPassword(string password)
        {
            if (Regex.IsMatch(password, @"\d+") && Regex.IsMatch(password, @"[a-z]+") && Regex.IsMatch(password, @"[A-Z]+") && Regex.IsMatch(password, @"[^a-zA-Z\d\s]+"))
            {
                if (password.Length >= 8)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// checks to see if the userinput is a valid numbers
        /// </summary>
        /// <param name="number">the number of validate</param>
        /// <returns>True if it is a valid number</returns>
        public static bool IsValidNumber(string number)
        {
            int num;
            if (int.TryParse(number, out num))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Checks to see if user input is a valid state name
        /// </summary>
        /// <param name="stateName">the statename to validate</param>
        /// <returns>True if statename is a valid state name</returns>
        public static bool IsValidStateName(string stateName)
        {
            string[] stateNames = { "ACT", "NSW", "NT", "QLD", "SA", "TAS", "VIC", "WA" };
            if (stateNames.Contains(stateName.ToUpper()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// Displays a list of products
        /// </summary>
        /// <param name="products">list of products to display</param>
        /// <param name="emptyProductWarning">warning to display if product list is empty</param>
        public static void DisplayProducts(List<Product> products, string emptyProductWarning)
        {
            if (products.Count() != 0)
            {
                const string HEADERS = "Item #\tProduct name\tDescription\tLast Price\tBidder name\tBidder email\tBid amt";
                Console.WriteLine(HEADERS);
                
                for (int counter = 0; counter < products.Count(); counter++)
                {
                    if (isValidBidPrice(products[counter].BidPrice, "$0.00"))
                    {
                        Console.WriteLine(counter + 1 + "\t" + products[counter].ToString() + "\t" + products[counter].BidderName + "\t" + products[counter].bidderEmail + "\t" + products[counter].BidPrice); 
                    }
                    else
                    {
                        Console.WriteLine(counter + 1 + "\t" + products[counter].ToString() + "\t-\t-\t-");
                    }

                    
                }
            }
            else
            {
                throw new Exception(emptyProductWarning);
            }
        }

        /// <summary>
        /// sorts a list products alphabetically
        /// </summary>
        /// <param name="products">list of products to sort</param>
        public static void SortProducts(ref List<Product> products)
        {

            List<string> productNames = new List<string>();

            foreach(Product product in products)
            {
                productNames.Add(product.ProductName);
            }

            productNames.Sort();


            List<Product> sortedProducts = new List<Product>();

            for(int counter = 0; counter < products.Count() - 1; counter++)
            {
                for(int looper = 0; looper < productNames.Count() - 1; looper++)
                {
                    if (string.Compare(productNames[counter], products[looper].ProductName) == 0)
                    {
                        sortedProducts.Add(products[looper]);
                    }
                }
            }

            products = sortedProducts;

        }
    }
}