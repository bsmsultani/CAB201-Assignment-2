namespace Auctionhouse

{
    /// <summary>
    /// Extends ConsoleInput where user is asked to enter an option ranging from x -> n
    /// </summary>
    class SelectOption : ConsoleInput
    {
        const string invalidValue = "Invalid value for selecting option";
        private int equalOrHigher {get; set;}
        private int equalOrLower {get; set;}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="equalOrHigher">user input should be higher or equal to this value</param>
        /// <param name="equalOrLower">user input shoudl be lower or equal to this value</param>
        public SelectOption(int equalOrHigher, int equalOrLower)
        {
            this.equalOrHigher = equalOrHigher;
            this.equalOrLower = equalOrLower;

            this.askFor = $"Please select an option between {equalOrHigher} and {equalOrLower}";
            this.errorMessage = "Invalid Option, choose an avaliable option!";
        }

        /// <summary>
        /// validates user input
        /// </summary>
        /// <param name="userInput">user input to validate</param>
        /// <returns>True if user input is valid</returns>
        public override bool Validate(string? userInput)
        {
            uint userOption;
            if (uint.TryParse(userInput, out userOption))
            {
                return userOption >= equalOrHigher && userOption <= equalOrLower;
            }
            else
            {
                this.errorMessage = invalidValue;
                return false;
            }
        }
    }
}