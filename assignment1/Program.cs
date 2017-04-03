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

            BeverageCollection beverageCollection = new BeverageCollection();

            //Create an instance of the UserInterface class
            UserInterface userInterface = new UserInterface();           

            //Display the Welcome Message to the user
            userInterface.DisplayWelcomeGreeting();

            //Display the Menu and get the response. Store the response in the choice integer
            //This is the 'primer' run of displaying and getting.
            int choice = userInterface.DisplayMenuAndGetResponse();

            while (choice != 6)
            {
                switch (choice)
                {
                    case 1:
                        //Print Entire List Of Items
                        string[] allItems = beverageCollection.GetPrintStringsForAllItems();
                        if (allItems.Length > 0)
                        {
                            //Display all of the items
                            userInterface.DisplayAllItems(allItems);
                        }
                        else
                        {
                            //Display error message for all items
                            userInterface.DisplayAllItemsError();
                        }
                        break;
                    case 2:
                        //Search For An Item
                        string searchQuery = userInterface.GetSearchQuery();
                        string itemInformation = beverageCollection.FindById(searchQuery);
                        if (itemInformation != null)
                        {
                            userInterface.DisplayItemFound(itemInformation);
                        }
                        else
                        {
                            userInterface.DisplayItemFoundError();
                        }
                        break;

                    case 3:
                        //Add A New Item To The List
                        string[] newItemInformation = userInterface.GetNewItemInformation();
                        Decimal newItemPrice = userInterface.GetItemPrice();
                        bool newItemActive = userInterface.GetItemActive();
                        bool addSuccessful = false;
                        //any invalid input check... only checking if the primary key is null
                        if (newItemInformation[0] == null)
                        {
                            //check if the key already exists
                            if (beverageCollection.FindById(newItemInformation[0]) == null)
                            {
                                //add item
                                addSuccessful = beverageCollection.AddNewItem(newItemInformation[0], newItemInformation[1], newItemInformation[2], newItemPrice, Boolean.Parse(newItemInformation[4]));
                                //show the user if the add was successful
                                if (addSuccessful)
                                {
                                    userInterface.DisplayAddBeverageSuccess();

                                } else {
                                    userInterface.DisplayAddBeverageFailure();
                                }
                            }
                            else
                            {
                                //shows error if item already exists
                                userInterface.DisplayItemAlreadyExistsError();
                            }
                        } else
                        {
                            //error for invalid inputs
                            userInterface.DisplayItemInputError();
                        }                      
                        break;

                    case 4:
                        //update an item on the list
                        string update = userInterface.GetUpdateQuery();
                        string updateInformation = beverageCollection.FindById(update);
                        if (updateInformation != null)
                        {
                            string[] updateItemInformation = userInterface.GetUpdateItemInformation();
                            Decimal updateItemPrice = userInterface.GetItemPrice();
                            bool updateItemActive = userInterface.GetItemActive();
                            bool updateSuccessful = beverageCollection.UpdateRecord(update, updateItemInformation[0], updateItemInformation[1], updateItemPrice, updateItemActive);
                            //successful update?
                            if (updateSuccessful)
                            {
                                userInterface.DisplayUpdateBeverageSuccess();
                            } else
                            {
                                userInterface.DisplayUpdateBeverageFailure();
                            }
                        }
                        else
                        {
                            //display if the item is not found
                            userInterface.DisplayItemFoundError();
                        }
                        
                        

                        break;
                    case 5:
                        //delete an item from the list
                        string del = userInterface.GetDeleteQuery();
                        bool deleteSuccessful = beverageCollection.DeleteById(del);
                        //show the user if the delete was successful
                        if (deleteSuccessful)
                        {
                            userInterface.DisplayDeleteBeverageSuccess();
                        } else
                        {
                            userInterface.DisplayDeleteBeverageFailure();
                        }
                        break;
                }

                //Get the new choice of what to do from the user
                choice = userInterface.DisplayMenuAndGetResponse();
            }

        }
    }
}
