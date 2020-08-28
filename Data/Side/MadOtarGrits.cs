using BleakwindBuffet.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

/*
 * Author: Nicholas Sixbury
 * Class Name: MadOtarGrits.cs
 * Purpose: To represent a Mad Otar Grits item and hold
 * information pertaining to it in one place.
 */

namespace BleakwindBuffet.Data.Side
{
    /// <summary>
    /// Represents a Mod Otar Grits item
    /// </summary>
    class MadOtarGrits
    {
        // backer variable for Size
        private Size size = Size.Small;
        /// <summary>
        /// Represents the size of this item, small, 
        /// medium, or large
        /// </summary>
        public Size Size
        {
            get { return size; }
            set { size = value; }
        }//end getter
        /// <summary>
        /// Represents the price of this item, dependant
        /// on size
        /// </summary>
        public double Price
        {
            get
            {
                switch (Size)
                {
                    case Size.Small:
                        return 1.22;
                    case Size.Medium:
                        return 1.58;
                    case Size.Large:
                        return 1.93;
                    default:
                        return 0;
                }//end switch case
            }//end setter
        }//end getter
        /// <summary>
        /// Represents the number of calories this item has,
        /// dependant on size
        /// </summary>
        public uint Calories
        {
            get
            {
                switch (Size)
                {
                    case Size.Small:
                        return 105;
                    case Size.Medium:
                        return 142;
                    case Size.Large:
                        return 179;
                    default:
                        return 0;
                }//end switch case
            }//end setter
        }//end getter
        /// <summary>
        /// Contains any special instructions this item might
        /// have
        /// </summary>
        public List<string> SpecialInstructions
        {
            get
            {
                return new List<string>();
            }//end getter
        }//end getter

        /// <summary>
        /// A String representation of this item, in this case
        /// showing the name and size of the object.
        /// </summary>
        /// <returns>A string representation of this object</returns>
        public override string ToString()
        {
            return $"{Size} Mad Otar Grits";
        }//end ToString()
    }//end class
}//end namespace