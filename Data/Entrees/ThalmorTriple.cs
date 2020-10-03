using System;
using System.Collections.Generic;
using System.Text;

/*
 * Author: Nicholas Sixbury
 * Class Name: ThalmorTriple.cs
 * Purpose: Represents the Thalmor Triplecs item and holds most of 
 * its information in one place
 */

namespace BleakwindBuffet.Data.Entrees
{
    /// <summary>
    /// Represents the Thalmor Triplecs item
    /// </summary>
    public class ThalmorTriple : Entree
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
        // backer variable for Tomato
        private bool tomato = true;
        // backer variable for Lettuce
        private bool lettuce = true;
        // backer variable for Mayo
        private bool mayo = true;
        // backer variable for Bacon
        private bool bacon = true;
        // backer variable for Egg
        private bool egg = true;
        /// <summary>
        /// Whether or not this item has bun
        /// </summary>
        public bool Bun { get { return bun; } set { bun = value; NotifyPropertyChanged("Bun"); NotifyPropertyChanged("SpecialInstructions");} }
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
        /// Whether or not this item has tomato
        /// </summary>
        public bool Tomato { get { return tomato; } set { tomato = value; NotifyPropertyChanged("Tomato"); NotifyPropertyChanged("SpecialInstructions"); } }
        /// <summary>
        /// Whether or not this item has lettuce
        /// </summary>
        public bool Lettuce { get { return lettuce; } set { lettuce = value; NotifyPropertyChanged("Lettuce"); NotifyPropertyChanged("SpecialInstructions"); } }
        /// <summary>
        /// Whether or not this item has mayo
        /// </summary>
        public bool Mayo { get { return mayo; } set { mayo = value; NotifyPropertyChanged("Mayo"); NotifyPropertyChanged("SpecialInstructions"); } }
        /// <summary>
        /// Whether or not this item has bacon
        /// </summary>
        public bool Bacon { get { return bacon; } set { bacon = value; NotifyPropertyChanged("Bacon"); NotifyPropertyChanged("SpecialInstructions"); } }
        /// <summary>
        /// Whether or not this item has an egg
        /// </summary>
        public bool Egg { get { return egg; } set { egg = value; NotifyPropertyChanged("Egg"); NotifyPropertyChanged("SpecialInstructions"); } }
        /// <summary>
        /// Represents the price of this item
        /// </summary>
        public override double Price
        {
            get { return 8.32; }
        }//end getter
        /// <summary>
        /// Represents the number of calories this item has
        /// </summary>
        public override uint Calories
        {
            get { return 943; }
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
                if (!Tomato) { specialInstructions.Add("Hold tomato"); }
                if (!Lettuce) { specialInstructions.Add("Hold lettuce"); }
                if (!Mayo) { specialInstructions.Add("Hold mayo"); }
                if (!Bacon) { specialInstructions.Add("Hold bacon"); }
                if (!Egg) { specialInstructions.Add("Hold egg"); }
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
            return "Thalmor Triple";
        }//end ToString()
    }//end class ThalmorTriplecs
}//end namespace