namespace Auctionhouse
{
    /// <summary>
    /// Interface or general implementation of all of the events in the program
    /// Referred to as an Event as it makes more sense in natural language than IEvent
    /// </summary>
    public interface IEvent
    {
        /// <summary>
        /// Every event has a title such as (registeration)
        /// </summary>
        /// <value></value>
        public abstract string TITLE {get; set;}

        /// <summary>
        /// The main function that is run when a button is pressed
        /// </summary>
        public abstract void Run();

    }
}