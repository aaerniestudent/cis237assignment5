//Author: Anthony Aernie
//CIS 237
//Assignment 5
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
        
        //CREATE new beverage, add to the database and save
        public bool AddNewItem(string id, string name, string pack, decimal price, bool active)
        {
            //new beverage to add
            Beverage toAdd = new Beverage();
            //add properties
            toAdd.id = id;
            toAdd.name = name;
            toAdd.pack = pack;
            toAdd.price = price;
            toAdd.active = active;
            try
            {
                //put it into the database
                beverageAAernieEntities.Beverages.Add(toAdd);
                //save database
                beverageAAernieEntities.SaveChanges();
            } catch
            {
                //remove from the database in case it was added and the save failed
                beverageAAernieEntities.Beverages.Remove(toAdd);
                return false;
            }
            return true;
        }
               
        //READ beverages and return as a string array
        public string[] GetPrintStringsForAllItems()
        {
            
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

        //READ: Find an item by it's Id
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

        //UPDATE update an item with matching id
        public bool UpdateRecord(string id, string name, string pack, decimal price, bool active)
        {
            //find by id
            Beverage beverageToUpdate = beverageAAernieEntities.Beverages.Find(id);
            //update item
            beverageToUpdate.name = name;
            beverageToUpdate.pack = pack;
            beverageToUpdate.price = price;
            beverageToUpdate.active = active;
            try
            {              
                //save changes to database
                beverageAAernieEntities.SaveChanges();
            } catch
            {
                return false;
            }
            return true;

        }
        //DELETE: delete an item with matching id
        public bool DeleteById(string id)
        {
            //get the beverage to delete
            Beverage beverageToDelete = beverageAAernieEntities.Beverages.Find(id);
            try
            {
                //remove beverage
                beverageAAernieEntities.Beverages.Remove(beverageToDelete);
                //save changes to database
                beverageAAernieEntities.SaveChanges();
            }catch
            {
                return false;
            }
            return true;
        }

        //------------------
        //Private Methods
        //------------------

        //returns a string for the beverage passed in
        private string SingleString(Beverage b)
        {
            //change active boolean to useful string
            string act = "ACTIVE";
            if (!b.active)
            {
                act = "NOT ACTIVE";
            }
            return b.id.Trim() + " " + b.name + " " + b.pack + " " + b.price.ToString() + " " + act;
        }

    }
}
