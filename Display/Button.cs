namespace Auctionhouse
{
    /// <summary>
    /// Used to display and run an Event
    /// </summary>
    public class Button
    {
        /// <summary>
        /// The text displayed for the event
        /// </summary>
        private string _buttonText;
        /// <summary>
        /// The Event associated with the button text such as (Sign in, register...)
        /// </summary>
        private IEvent _buttonTriger;
        
        /// <summary>
        /// Set 
        /// </summary>
        /// <param name="ButtonText"></param>
        /// <param name="ButtonTriger"></param>
        public Button(string ButtonText, IEvent ButtonTriger)
        {
            _buttonText = ButtonText;
            _buttonTriger = ButtonTriger;
        }

        /// <summary>
        /// Returns the button text (used to display it on the console)
        /// </summary>
        /// <returns></returns>

        public override string ToString()
        {
            return _buttonText;
        }

        /// <summary>
        /// If the button is pressed, then it executes _buttonTriger (type of Event) Run() method 
        /// This gives the ability to polymorphically run any class of type Event
        /// </summary>

        public void PressButton()
        {
            _buttonTriger.Run();
        }
    }
}