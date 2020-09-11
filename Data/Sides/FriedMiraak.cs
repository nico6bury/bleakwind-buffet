using BleakwindBuffet.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

/*
 * Author: Nicholas Sixbury
 * Class Name: FriedMiraak.cs
 * Purpose: To represent a Fried Miraak item and hold 
 * information pertaining to it in one place.
 */

namespace BleakwindBuffet.Data.Sides
{
    /// <summary>
    /// Represents a Fried Miraak object
    /// </summary>
    public class FriedMiraak : Side
    {
        // backer variable for Size
        private Size size = Size.Small;
        /// <summary>
        /// Represents the size of this item, small, 
        /// medium, or large
        /// </summary>
        public override Size Size
        {
            get { return size; }
            set { size = value; }
        }//end getter
        /// <summary>
        /// Represents the price of this item, dependant
        /// on size
        /// </summary>
        /// <exception cref="System.NotImplementedException">
        /// If size is not recognized, throws an exception
        /// </exception>
        public override double Price
        {
            get
            {
                switch (Size)
                {
                    case Size.Small:
                        return 1.78;
                    case Size.Medium:
                        return 2.01;
                    case Size.Large:
                        return 2.88;
                    default:
                        throw new NotImplementedException("That size is no implemented.");
                }//end switch case
            }//end setter
        }//end getter
        /// <summary>
        /// Represents the number of calories this item has,
        /// dependant on size
        /// </summary>
        /// <exception cref="System.NotImplementedException">
        /// If size is not recognized, throws an exception
        /// </exception>
        public override uint Calories
        {
            get
            {
                switch (Size)
                {
                    case Size.Small:
                        return 151;
                    case Size.Medium:
                        return 236;
                    case Size.Large:
                        return 306;
                    default:
                        throw new NotImplementedException("That size is no implemented.");
                }//end switch case
            }//end setter
        }//end getter
        /// <summary>
        /// Contains any special instructions this item might
        /// have
        /// </summary>
        public override List<string> SpecialInstructions
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
            return $"{Size} Fried Miraak";
        }//end ToString()
    }//end class FriedMiraak
}//end namespace