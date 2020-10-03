using System;
using System.Collections.Generic;
using System.Text;

/*
 * Author: Nicholas Sixbury
 * Class Name: BriarheartBurger.cs
 * Purpose: Represents the Briarheart Burger item and holds most of 
 * its information in one place
 */

namespace BleakwindBuffet.Data.Entrees
{
    /// <summary>
    /// Represents the Briarheart Burger item
    /// </summary>
    public class BriarheartBurger : Entree
    {
        // backer variable for Bun
        private bool bun = true;
        // backer variable for Ketchup
        private bool ketchup = true;
        // backer variable for Mustard
        private bool mustard = true;
        // backer variable for Pickle
        private bool pickle = true;
        // backer variable for Cheese
        private bool cheese = true;
        /// <summary>
        /// Whether or not this item has a bun
        /// </summary>
        public bool Bun { get { return bun; } set { bun = value; NotifyPropertyChanged("Bun"); NotifyPropertyChanged("SpecialInstructions"); } }
        /// <summary>
        /// Whether or not this item has ketchup
        /// </summary>
        public bool Ketchup { get { return ketchup; } set { ketchup = value; NotifyPropertyChanged("Ketchup"); NotifyPropertyChanged("SpecialInstructions"); } }
        /// <summary>
        /// Whether or not this item has mustard
        /// </summary>
        public bool Mustard { get { return mustard; } set { mustard = value; NotifyPropertyChanged("Mustard"); NotifyPropertyChanged("SpecialInstructions"); } }
        /// <summary>
        /// Whether or not this item has pickles
        /// </summary>
        public bool Pickle { get { return pickle; } set { pickle = value; NotifyPropertyChanged("Pickle"); NotifyPropertyChanged("SpecialInstructions"); } }
        /// <summary>
        /// Whether or not this item has cheese
        /// </summary>
        public bool Cheese { get { return cheese; } set { cheese = value; NotifyPropertyChanged("Cheese"); NotifyPropertyChanged("SpecialInstructions"); } }
        /// <summary>
        /// Represents the price of this item
        /// </summary>
        public override double Price
        {
            get { return 6.32; }
        }//end getter
        /// <summary>
        /// Represents the number of calories this item has
        /// </summary>
        public override uint Calories
        {
            get { return 743; }
        }//end getter
        /// <summary>
        /// Contains any special instructions this item has
        /// </summary>
        public override List<string> SpecialInstructions
        {
            get
            {
                List<string> specialInstructions = new List<string>();
                if (!Bun) { specialInstructions.Add("Hold bun"); }
                if (!Ketchup) { specialInstructions.Add("Hold ketchup"); }
                if (!Mustard) { specialInstructions.Add("Hold mustard"); }
                if (!Pickle) { specialInstructions.Add("Hold pickle"); }
                if (!Cheese) { specialInstructions.Add("Hold cheese"); }
                return specialInstructions;
            }//end getter
        }//end getter

        /// <summary>
        /// ToString() returns a string representation of the object,
        /// in this case the name and nothing else
        /// </summary>
        /// <returns>the name as a string</returns>
        public override string ToString()
        {
            return "Briarheart Burger";
        }//end ToString()
    }//end class BriarheartBurger
}//end namespace