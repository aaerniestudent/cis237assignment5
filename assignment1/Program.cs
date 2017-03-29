//Author: David Barnes
//CIS 237
//Assignment 1
/*
 * The Menu has been updated
 * The Menu Choices Displayed By The UI
 * 1. Print The Entire Database Of Items
 * 2. Search For An Item By ID
 * 3. Add New Item To The Database
 * 4. Update Item In Database
 * 5. Delete Item From the Database
 * 6. Exit Program
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    class Program
    {
        static void Main(string[] args)
        {             

            //Create an instance of the UserInterface class
            UserInterface userInterface = new UserInterface();           

            //Display the Welcome Message to the user
            userInterface.DisplayWelcomeGreeting();

            //Display the Menu and get the response. Store the response in the choice integer
            //This is the 'primer' run of displaying and getting.
            int choice = userInterface.DisplayMenuAndGetResponse();

            while (choice != 7)
            {
                switch (choice)
                {
                    case 1:
                        //Print Entire List Of Items
                        //string[] allItems = wineItemCollection.GetPrintStringsForAllItems();
                        //if (allItems.Length > 0)
                        //{
                        //    //Display all of the items
                        //    userInterface.DisplayAllItems(allItems);
                        //}
                        //else
                        //{
                        //    //Display error message for all items
                        //    userInterface.DisplayAllItemsError();
                        //}
                        break;
                    case 2:
                        //Search For An Item
                        //string searchQuery = userInterface.GetSearchQuery();
                        //string itemInformation = wineItemCollection.FindById(searchQuery);
                        //if (itemInformation != null)
                        //{
                        //    userInterface.DisplayItemFound(itemInformation);
                        //}
                        //else
                        //{
                        //    userInterface.DisplayItemFoundError();
                        //}
                        break;

                    case 3:
                        //Add A New Item To The List
                        //string[] newItemInformation = userInterface.GetNewItemInformation();
                        //if (wineItemCollection.FindById(newItemInformation[0]) == null)
                        //{
                        //    wineItemCollection.AddNewItem(newItemInformation[0], newItemInformation[1], newItemInformation[2]);
                        //    userInterface.DisplayAddWineItemSuccess();
                        //}
                        //else
                        //{
                        //    userInterface.DisplayItemAlreadyExistsError();
                        //}
                        
                        break;

                    case 4:
                        
                        break;
                    case 5:

                        break;
                    case 6:

                        break
                }

                //Get the new choice of what to do from the user
                choice = userInterface.DisplayMenuAndGetResponse();
            }

        }
    }
}
