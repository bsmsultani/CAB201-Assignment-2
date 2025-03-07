namespace Auctionhouse
{
    /// <summary>
    /// A general class for creating subclasses to extend and validate user input
    /// </summary>
    public abstract class ConsoleInput
    {
        /// <summary>
        /// the string to ask the user for
        /// </summary>
        /// <value></value>
        protected string askFor {get; set;}
        /// <summary>
        /// error message to display for the user
        /// </summary>
        /// <value></value>
        protected string? errorMessage {get; set;}

        /// <summary>
        /// the value of user input
        /// </summary>
        /// <value></value>
        protected string value {get; set;}


        /// <summary>
        /// Gets and validates user input
        /// </summary>
        public virtual void GetInput()
        {
            Console.WriteLine(askFor);
            Console.Write("> ");
            this.value = Console.ReadLine();
            while (!Validate(this.value))
            {
                Console.WriteLine(errorMessage);
                Console.Write("> ");
                this.value = Console.ReadLine();
            }
        }

        /// <summary>
        /// general validation class which is extended in inherited classes
        /// </summary>
        /// <param name="userInput"></param>
        /// <returns></returns>

        public abstract bool Validate(string? userInput);

        public override string ToString()
        {
            return this.value;
        }

        /// <summary>
        /// sets ask message
        /// </summary>
        /// <param name="askForMessage"></param>

        public void SetAskFor(string askForMessage)
        {
            this.askFor = askForMessage;
        }

        /// <summary>
        /// sets error message
        /// </summary>
        /// <param name="errorMessage"></param>

        public void SetError(string errorMessage)
        {
            this.errorMessage = errorMessage;
        }
    }
}