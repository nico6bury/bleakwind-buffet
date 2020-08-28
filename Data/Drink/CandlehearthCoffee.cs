using BleakwindBuffet.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

/*
 * Author: Nicholas Sixbury
 * Class Name: CandlehearthCoffee.cs
 * Purpose: To represent the CandlehearthCoffee drink and
 * hold this item's information
 */

namespace BleakwindBuffet.Data.Drink
{
    /// <summary>
    /// Represents the Candlehearth Coffee drink item
    /// </summary>
    class CandlehearthCoffee
    {
        // backer variable for Ice
        private bool ice = false;
        // backer variable for Decaf
        private bool decaf = false;
        // backer variable for RoomForCream
        private bool roomForCream = false;
        // backer variable for Size
        private Size size = Enums.Size.Small;
        /// <summary>
        /// Whether or not this item has ice
        /// </summary>
        public bool Ice
        {
            get { return ice; }
            set { ice = value; }
        }//end getter/setter
        /// <summary>
        /// Whether this item is decaf or not
        /// </summary>
        public bool Decaf
        {
            get { return decaf; }
            set { decaf = value; }
        }//end getter/setter
        public bool RoomForCream
        {
            get { return roomForCream; }
            set { roomForCream = value; }
        }//end getter/setter
        /// <summary>
        /// The size of this item
        /// </summary>
        public Size Size
        {
            get { return size; }
            set { size = value; }
        }//end getter/setter
        /// <summary>
        /// The price of this item, dependant on size
        /// </summary>
        public double Price
        {
            get
            {
                switch (Size)
                {
                    case Size.Small:
                        return 0.75;
                    case Size.Medium:
                        return 1.25;
                    case Size.Large:
                        return 1.75;
                    default:
                        return 0;
                }//end switch case
            }//end getter
        }//end getter
        /// <summary>
        /// the calories of this item, dependant on size
        /// </summary>
        public uint Calories
        {
            get
            {
                switch (Size)
                {
                    case Size.Small:
                        return 7;
                    case Size.Medium:
                        return 10;
                    case Size.Large:
                        return 20;
                    default:
                        return 0;
                }//end switch case
            }//end getter
        }//end getter
        /// <summary>
        /// Any special instructions this item might have
        /// </summary>
        public List<string> SpecialInstructions
        {
            get
            {
                List<string> specialInstructions = new List<string>();
                if (Ice) { specialInstructions.Add("Add ice"); }
                if (RoomForCream) { specialInstructions.Add("Add cream"); }
                return specialInstructions;
            }//end getter
        }//end getter

        /// <summary>
        /// ToString() represents the object as a string, in
        /// this case showing the size, name, and caffine of
        /// this object.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string de_caffine;
            if (Decaf == true)
            {
                de_caffine = "Decaf";
            }//end if item is decaf
            else
            {
                de_caffine = "";
            }//end if item does have caffine
            return $"{Size} {de_caffine} Candlehearth Coffee";
        }//end ToString()
    }//end class CandlehearthCoffee
}//end namespace