using System.Text.RegularExpressions;

namespace Auctionhouse
{
    /// <summary>
    /// An abstract Menu which enables the management of displaying the menu
    /// Including its buttons (options)
    /// </summary>
    public abstract class Menu
    {
        /// <summary>
        /// The title of the menu such as Main Menu
        /// </summary>
        /// <value></value>
        protected string? TITLE {get; set;}
        /// <summary>
        /// The list of options displayed for the user
        /// </summary>
        /// <value></value>
        protected List<Button>? Buttons {get; set;}
        /// <summary>
        /// Controls whether the menu should stop displaying
        /// </summary>
        /// <value></value>
        private bool _displayOn;

        /// <summary>
        /// Constructor, initiates a new list of buttons (options)
        /// </summary>
        public Menu()
        {
            this.Buttons = new List<Button>();
        }

        /// <summary>
        /// The primary function for 'configuring', mainly adding new buttons to the button list
        /// From inherited members
        /// </summary>
        public abstract void Configure();
        
        /// <summary>
        /// Has a default behaviour of displaying the buttons (options)
        /// Gets the user input for running (pressing) a button
        /// </summary>
        public virtual void Display()
        {

            while (_displayOn)
            {
                Console.WriteLine(TITLE);
                for(int counter = 0; counter < Buttons.Count(); counter++)
                {
                    Console.WriteLine($"({counter+1}) {Buttons[counter].ToString()}");
                }

                ConsoleInput selectMenue = new SelectOption(1, this.Buttons.Count());
                selectMenue.GetInput();
                
                int chosenButton = int.Parse(selectMenue.ToString()) - 1;
                this.Buttons[chosenButton].PressButton();
            }
        }

        /// <summary>
        /// Method used by other classes (such as exit or log off) to stop displaying the menu
        /// </summary>

        public void StopDisplay()
        {
            _displayOn = false;
        }

        /// <summary>
        /// Method for displaying the menu
        /// </summary>
        public void startDisplay()
        {
            Configure();
            _displayOn = true;
            Display();
        }
    } 
}