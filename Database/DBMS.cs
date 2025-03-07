namespace Auctionhouse
{
    /// <summary>
    /// DBMS -> Database Mangement System
    /// Enables access to Database instance
    /// </summary>
    public static class DBMS
    {
        /// <summary>
        /// Database instance which can be accessed via other classes
        /// </summary>
        /// <value></value>
        public static Database database {get; private set;}

        /// <summary>
        /// Is used to create a new instance of the Database as 'database'
        /// </summary>
        /// <param name="DATABASE_FILENAME">The name of the json file which the database is saved to.</param>
        public static void LoadDatabase(string DATABASE_FILENAME)
        {
            database = new Database(DATABASE_FILENAME);
        }
    }
}