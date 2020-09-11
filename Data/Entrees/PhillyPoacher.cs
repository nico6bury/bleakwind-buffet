using System;
using System.Collections.Generic;
using System.Text;

/*
 * Author: Nicholas Sixbury
 * Class Name: PhillyPoacher.cs
 * Purpose: Represents the Philly Poacher item and holds most of 
 * its information in one place
 */

namespace BleakwindBuffet.Data.Entrees
{
    /// <summary>
    /// Represents the Philly Poacher item
    /// </summary>
    public class PhillyPoacher : Entree
    {
        // backer variable for Sirloin
        private bool sirloin = true;
        // backer variable for Onion
        private bool onion = true;
        // backer variable for Roll
        private bool roll = true;
        /// <summary>
        /// Whether or not this item is sirloin
        /// </summary>
        public bool Sirloin { get { return sirloin; } set { sirloin = value; } }
        /// <summary>
        /// Whether or not this item has onions
        /// </summary>
        public bool Onion { get { return onion; } set { onion = value; } }
        /// <summary>
        /// Whether or not this item has a roll
        /// </summary>
        public bool Roll { get { return roll; } set { roll = value; } }
        /// <summary>
        /// Represents the price of this item
        /// </summary>
        public override double Price
        {
            get { return 7.23; }
        }//end getter
        /// <summary>
        /// Represents the number of calories this item has
        /// </summary>
        public override uint Calories
        {
            get { return 784; }
        }//end getter
        /// <summary>
        /// Contains any special instructions this item has
        /// </summary>
        public override List<string> SpecialInstructions
        {
            get
            {
                List<string> specialInstructions = new List<string>();
                if (!Sirloin) { specialInstructions.Add("Hold sirloin"); }
                if (!Onion) { specialInstructions.Add("Hold onions"); }
                if (!Roll) { specialInstructions.Add("Hold roll"); }
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
            return "Philly Poacher";
        }//end ToString()
    }//end class PhillyPoacher
}//end namespace