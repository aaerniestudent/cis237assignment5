//Author: Anthony Aernie
//CIS 237
//Assignment 5
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//methods have been added, but some methods have been kept the same
namespace assignment1
{
    class UserInterface
    {
        const int maxMenuChoice = 6;
        //---------------------------------------------------
        //Public Methods
        //---------------------------------------------------

        //Display Welcome Greeting
        //***added buffer height, changed welcome message***
        public void DisplayWelcomeGreeting()
        {            
            Console.BufferHeight = 10000;
            Console.WriteLine("Welcome to the beverage program");
        }

        //Display Menu And Get Response
        public int DisplayMenuAndGetResponse()
        {
            //declare variable to hold the selection
            string selection;

            //Display menu, and prompt
            this.displayMenu();
            this.displayPrompt();

            //Get the selection they enter
            selection = this.getSelection();

            //While the response is not valid
            while (!this.verifySelectionIsValid(selection))
            {
                //display error message
                this.displayErrorMessage();

                //display the prompt again
                this.displayPrompt();

                //get the selection again
                selection = this.getSelection();
            }
            //Return the selection casted to an integer
            return Int32.Parse(selection);
        }

        //Get the search query from the user
        public string GetSearchQuery()
        {
            Console.WriteLine();
            Console.WriteLine("What would you like to search for?");
            Console.Write("> ");
            return Console.ReadLine();
        }

        //Get New Item Information From The User.
        public string[] GetNewItemInformation()
        {
            Console.WriteLine();
            Console.WriteLine("What is the new items Id?");
            Console.Write("> ");
            string id = Console.ReadLine();
            Console.WriteLine("What is the new items Description?");
            Console.Write("> ");
            string description = Console.ReadLine();
            Console.WriteLine("What is the new items Pack?");
            Console.Write("> ");
            string pack = Console.ReadLine();

            return new string[] { id, description, pack };
        }

        //***new get item information methods***
        //get information for update
        public string[] GetUpdateItemInformation()
        {
            //already have ID
            Console.WriteLine("What is the updated items Description?");
            Console.Write("> ");
            string description = Console.ReadLine();
            Console.WriteLine("What is the updated items Pack?");
            Console.Write("> ");
            string pack = Console.ReadLine();

            return new string[] { description, pack };
        }

        //get and validate item price
        //used in new and update
        public decimal GetItemPrice()
        {
            decimal price = -1;
            Console.WriteLine("What is the items Price?");
            Console.Write("> $");
            //get a valid price
            //no voids, but zero is valid
            while (price < 0)
            {
                string input = Console.ReadLine();
                try
                {
                    price = Decimal.Parse(input);
                }
                catch
                {
                    Console.WriteLine();
                    Console.WriteLine("Error: not a valid price: price must be a positive number");
                    Console.WriteLine("What is the items Price?");
                    Console.Write("> $");
                }
            }
            return price;
        }

        //get and validate item active status
        //used in new and update
        public bool GetItemActive()
        {
            bool active = true;
            bool response = false;
            Console.WriteLine("Is the item Active?");
            Console.WriteLine("> Y/N?");
            //get a valid input
            while (!response)
            {
                string input = Console.ReadLine();
                //check valid inputs Y/N
                //no voids
                if (input == "y" || input == "Y")
                {
                    response = true;
                }else if (input == "n" || input == "N")
                {
                    active = false;
                    response = true;
                } else
                {                  
                    Console.WriteLine();
                    Console.WriteLine("Please input just Y or N");
                    Console.WriteLine("Is the item Active?");
                    Console.WriteLine("> Y/N?");
                }
            }
            return active;
        }

        //Display All Items
        public void DisplayAllItems(string[] allItemsOutput)
        {
            Console.WriteLine();
            foreach (string itemOutput in allItemsOutput)
            {
                Console.WriteLine(itemOutput);
            }
        }

        //***Update Methods***
        //Get the search query from the user
        public string GetUpdateQuery()
        {
            Console.WriteLine();
            Console.WriteLine("Please input an ID to update:");
            Console.Write("> ");
            return Console.ReadLine();
        }

        //***Delete Methods***
        public string GetDeleteQuery()
        {
            Console.WriteLine();
            Console.WriteLine("Please input an ID to delete:");
            Console.Write("> ");
            return Console.ReadLine();
        }

        //-------------------------
        //Errors and user prompts
        //-------------------------

        //Display All Items Error
        public void DisplayAllItemsError()
        {
            Console.WriteLine();
            Console.WriteLine("There are no items in the list to print");
        }

        //Display Item Found Success
        public void DisplayItemFound(string itemInformation)
        {
            Console.WriteLine();
            Console.WriteLine("Item Found!");
            Console.WriteLine(itemInformation);
        }

        //Display Item Found Error
        public void DisplayItemFoundError()
        {
            Console.WriteLine();
            Console.WriteLine("A Match was not found");
        }

        //Display Add Wine Item Success
        public void DisplayAddBeverageSuccess()
        {
            Console.WriteLine();
            Console.WriteLine("The Item was successfully added");
        }

        //Display Item Already Exists Error
        public void DisplayItemAlreadyExistsError()
        {
            Console.WriteLine();
            Console.WriteLine("An Item With That Id Already Exists");
        }

        //***new errors or display messages***
        //Display Item Input Error
        public void DisplayItemInputError()
        {
            Console.WriteLine();
            Console.WriteLine("Error Entering Item Info");
        }

        //Display Add beverage Fail
        public void DisplayAddBeverageFailure()
        {
            Console.WriteLine();
            Console.WriteLine("Error adding item to database");
        }

        //Display update Fail
        public void DisplayUpdateBeverageFailure()
        {
            Console.WriteLine();
            Console.WriteLine("Error updating item in database");
        }

        //display update successful
        public void DisplayUpdateBeverageSuccess()
        {
            Console.WriteLine();
            Console.WriteLine("Updated item in database");
        }
        //Display delete Fail
        public void DisplayDeleteBeverageFailure()
        {
            Console.WriteLine();
            Console.WriteLine("Error removing item from database: Item may not exist");
        }

        //display delete successful
        public void DisplayDeleteBeverageSuccess()
        {
            Console.WriteLine();
            Console.WriteLine("Removed item from database");
        }

        //---------------------------------------------------
        //Private Methods
        //---------------------------------------------------

        //Display the Menu
        //***updated menu***
        private void displayMenu()
        {
            Console.WriteLine();
            Console.WriteLine("What would you like to do?");
            Console.WriteLine();
            Console.WriteLine("1. Print The Entire Database Of Items");
            Console.WriteLine("2. Search For An Item By ID");
            Console.WriteLine("3. Add New Item To The Database");
            Console.WriteLine("4. Update Item In Database");
            Console.WriteLine("5. Delete Item From the Database");
            Console.WriteLine("6. Exit Program");
        }

        //Display the Prompt
        private void displayPrompt()
        {
            Console.WriteLine();
            Console.Write("Enter Your Choice: ");
        }

        //Display the Error Message
        private void displayErrorMessage()
        {
            Console.WriteLine();
            Console.WriteLine("That is not a valid option. Please make a valid choice");
        }

        //Get the selection from the user
        private string getSelection()
        {
            return Console.ReadLine();
        }

        //Verify that a selection from the main menu is valid
        private bool verifySelectionIsValid(string selection)
        {
            //Declare a returnValue and set it to false
            bool returnValue = false;

            try
            {
                //Parse the selection into a choice variable
                int choice = Int32.Parse(selection);

                //If the choice is between 0 and the maxMenuChoice
                if (choice > 0 && choice <= maxMenuChoice)
                {
                    //set the return value to true
                    returnValue = true;
                }
            }
            //If the selection is not a valid number, this exception will be thrown
            catch (Exception e)
            {
                //set return value to false even though it should already be false
                returnValue = false;
            }

            //Return the reutrnValue
            return returnValue;
        }
    }
}
