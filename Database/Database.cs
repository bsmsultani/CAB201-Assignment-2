using System.Text.Json;
using System.IO;
using System;
using System.Collections.Generic;


namespace Auctionhouse
{
    /// <summary>
    /// The class contained within it user data and functions to access and manage it.
    /// </summary>
    sealed public class Database
    {
        private string _filePath;

        /// <summary>
        /// Set to a known user when Login is sucessfull
        /// User details can be accessed via the cursor 
        /// From classes outside
        /// </summary>
        public User cursor {get; private set;}
        /// <summary>
        /// Serves as the main component of the database
        /// Where all known users are saved
        /// </summary>
        private List<User> _users;
        /// <summary>
        /// Finds the database file and transforms it back to list of user objects
        /// If cannot find database file, creates an empty list of users
        /// </summary>
        /// <param name="DATABASE_FILENAME">The name of the json file which the database is saved to.</param>
        public Database(string DATABASE_FILENAME)
        {
            _filePath= $"{Directory.GetCurrentDirectory()}/{DATABASE_FILENAME}.json";

            if (File.Exists(_filePath))
            {
                using StreamReader reader = new StreamReader(_filePath);
                _users = JsonSerializer.Deserialize<List<User>>(reader.ReadToEnd());
                reader.Close();
                
            }
            else
            {
                _users = new List<User>();
            }
        }

        /// <summary>
        /// Transforms the list of users to its JSON equivalent
        /// And saves it in the current working directory.
        /// </summary>
        public void Commit()
        {
            string jsonFormat = JsonSerializer.Serialize(_users);
            using StreamWriter writer = new StreamWriter(_filePath);
            writer.WriteLine(jsonFormat);
        }

        /// <summary>
        /// Adds the User object given to the list of users
        /// </summary>
        /// <param name="user">A type of User object</param>
        public void AddUserToDatabase(User user)
        {
            _users.Add(user);
        }

        /// <summary>
        /// Checks if any user has the email
        /// </summary>
        /// <param name="email">The email to see if exists</param>
        /// <returns>True if email exists</returns>
        public bool EmailExists(string email)
        {
            foreach(User eachUser in _users)
            {
                if (eachUser.Email == email) {return true;}
             }
            return false;
        }
        
        /// <summary>
        /// Authenticates users, if authenticated sets Database cursor to logged in user
        /// </summary>
        /// <param name="email">User email address</param>
        /// <param name="password">User password</param>
        /// <returns>True if email and password matches</returns>

        public bool Login(string email, string password)
        {
            foreach(User eachUser in _users)
            {
                if (eachUser.Email == email && eachUser.Password == password) {this.cursor = eachUser; return true;}
            }
            return false;
        }

        /// <summary>
        /// Searches for all of the products in the database
        /// that is not of the logged in user and returns it
        /// </summary>
        /// <returns>List of products</returns>
        public List<Product> GetAdvertisedProducts()
        {
            List<Product> advertisedProducts = new List<Product>();
            foreach(User user in _users)
            {
                if (user.Email != DBMS.database.cursor.Email)
                {
                    foreach(Product product in user.AdvertisedProducts)
                    {
                        advertisedProducts.Add(product);
                    }
                }
            }
            return advertisedProducts; 
        }

        /// <summary>
        /// Sends the product to the highest bidder
        /// </summary>
        /// <param name="product">The product to send</param>
        public void SendProductToBidder(Product product)
        {
            foreach(User eachUser in _users)
            {
                if (eachUser.Email == product.bidderEmail)
                {
                    eachUser.PurchasedProducts.Add(product);
                }
            }
        }

        /// <summary>
        /// Removes a product from logged in user (if user sells)
        /// </summary>
        /// <param name="product">The product to remove</param>
        public void RemoveProductFromUser(Product product)
        {
            cursor.AdvertisedProducts.Remove(product);
        }

    }
}
