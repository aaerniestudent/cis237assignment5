//Author: David Barnes
//CIS 237
//Assignment 1
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    class BeverageCollection
    {

        private BeverageAAernieEntities beverageAAernieEntities = new BeverageAAernieEntities();
        
        public bool AddNewItem(string id, string name, string pack, decimal price, bool active)
        {


            return true;
        }
        
        //creates a string for the beverage passed in
        private string SingleString(Beverage b)
        {            
            return b.id.Trim() + "   "+ b.name + " " + b.pack + " " + b.price.ToString() + " " + b.active.ToString();
        }

        //converts beverages into strings and returns string array
        public string[] GetPrintStringsForAllItems()
        {
            //old method
            ////set a counter to be used
            //int counter = 0;

            ////If the wineItemsLength is greater than 0, create the array of strings
            //if (wineItemsLength > 0)
            //{
            //    //For each item in the collection
            //    foreach (WineItem wineItem in wineItems)
            //    {
            //        //if the current item is not null.
            //        if (wineItem != null)
            //        {
            //            //Add the results of calling ToString on the item to the string array.
            //            allItemStrings[counter] = wineItem.ToString();
            //            counter++;
            //        }
            //    }
            //}
            ////Return the array of item strings

            //returning an array of beverage strings
            string[] allItemStrings = new string[beverageAAernieEntities.Beverages.Count()];
            int counter = 0;
            foreach (Beverage bev in beverageAAernieEntities.Beverages)
            {
                allItemStrings[counter] = SingleString(bev);
                counter++;
            }
            
            return allItemStrings;
        }

        //Find an item by it's Id
        public string FindById(string id)
        {          
            string returnString = null;
            //search for the passed in id
            Beverage beverageToFind = beverageAAernieEntities.Beverages.Find(id);
            if (beverageToFind != null)
            {
                returnString = SingleString(beverageToFind);
            }
            //"not found" errors are handled after return as they will display a message
            return returnString;
        }

    }
}
