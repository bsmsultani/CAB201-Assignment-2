namespace Auctionhouse
{
    /// <summary>
    /// Type of Exception, used to inform the user that the field is required
    /// </summary>
    class InputEmptyException : Exception
    {
        public InputEmptyException(string inputName) : base ($"{inputName} cannot be empty!")
        {
            
        }
    }
}