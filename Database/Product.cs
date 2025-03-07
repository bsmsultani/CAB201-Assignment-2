using System.Text.RegularExpressions;

namespace Auctionhouse
{
    public class Product
    {
        /// <summary>
        /// 20 randomly generated numbers serves as a unique ID 
        /// </summary>
        /// <value></value>
        public int productID {get; set;}

        /// <summary>
        /// Field used store Product Name
        /// </summary>
        private string _productName;

        /// <summary>
        /// Manages access to _productName by other classes.
        /// Validates any attempt to change _productName
        /// Same process for all of the fiels below 
        /// </summary>
        /// <value></value>
        public string ProductName
        {
            get
            {
                return _productName;
            }
            set
            {
                if (UI.StringNotEmpty(value))
                {
                    _productName = value;
                }
                else
                {
                    throw new InputEmptyException("Product name");
                }
                
            }
        }
        private string _productDescription;
        public string ProductDescription
        {
            get
            {
                return _productDescription;
            }
            set
            {
                if (UI.StringNotEmpty(value))
                {
                    if (value != _productName)
                    {
                        _productDescription = value;
                    }
                    else
                    {
                        throw new Exception("Product description cannot be the same as product name");
                    }
                    
                }
                else
                {
                    throw new InputEmptyException("Product description");
                }
            }
        }
        private string _productPrice;
        public string ProductPrice
        {
            get
            {
                return _productPrice;
            }
            set
            {
                if (UI.StringNotEmpty(value))
                {
                    if (UI.IsValidDollar(value))
                    {
                        _productPrice = value;
                    }
                    else
                    {
                        throw new Exception("Invalid dollar amount!");
                    }
                }
                else
                {
                    throw new InputEmptyException("Product price");
                }

            }
        }

        private string _bidderName;
        public string BidderName
        {
            get
            {
                return _bidderName;
            }
            set
            {
                if (UI.StringNotEmpty(value))
                {
                    _bidderName = value;
                }
                else
                {
                    throw new InputEmptyException("Bidder name");
                }
            }
        }
        private string _bidderEmail;
        public string bidderEmail
        {
            get
            {
                return _bidderEmail;

            }
            set
            {
                if (UI.StringNotEmpty(value))
                {
                    _bidderEmail = value;
                }
                else
                {
                    throw new InputEmptyException("Bidder email");
                }
            }
        }
        private string _highestbidPrice;
        
        public string BidPrice
        {
            get
            {
                return _highestbidPrice;
            }
            set
            {
                if (UI.StringNotEmpty(value))
                {
                    if (UI.IsValidDollar(value))
                    {
                        _highestbidPrice = value;
                    }
                    else
                    {
                        throw new Exception("Invalid dollar amount");
                    }
                }
                else
                {
                    throw new InputEmptyException("Bid price");
                }
            }
        }

        /// <summary>
        /// The bidder's delivery address when bidded on the product
        /// </summary>
        /// <value></value>
        public Address BidderDeliveryAddress {get; set;}

        /// <summary>
        /// The start and end collection time for collecting the product
        /// </summary>
        /// <value></value>
        public DateTime startCollectionTime {get; set;}
        public DateTime endCollectionTime {get; set;}

        /// <summary>
        /// Constructor, generates a unique ID
        ///  Sets default field values
        /// /// /// </summary>
        public Product()
        {
            Random productID = new Random(20);
            this.productID = productID.Next();
            _highestbidPrice = "$0.00";
            _bidderEmail = "4444";
            _bidderName = "4444";
        }

        /// <summary>
        /// Searches the instance of the product to see if it contains a keyword
        /// </summary>
        /// <param name="keyword">Keyword to search for</param>
        /// <returns>True if keyword is found</returns>
        public bool HasKeyWord(string keyword)
        {
            if (_productName.Contains(keyword, StringComparison.OrdinalIgnoreCase) || _productDescription.Contains(keyword, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Overrides ToString()
        /// </summary>
        /// <returns>A formatted string with product name, description and product price separated by tab</returns>
        public override string ToString()
        {
            return $"{_productName}\t{_productDescription}\t{_productPrice}";
        }

    }

}