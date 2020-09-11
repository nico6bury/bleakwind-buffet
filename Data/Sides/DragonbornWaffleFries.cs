using BleakwindBuffet.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

/*
 * Author: Nicholas Sixbury
 * Class Name: DragonbornWaffleFries.cs
 * Purpose: To represent a Dragonborb Waffle Fries 
 * item and hold information pertaining to it in 
 * one place.
 */

namespace BleakwindBuffet.Data.Sides
{
    /// <summary>
    /// Represents a Dragonborn Waffle Fries item
    /// </summary>
    public class DragonbornWaffleFries
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
        /// <exception cref="System.NotImplementedException">
        /// If size is not recognized, throws an exception
        /// </exception>
        public double Price
        {
            get
            {
                switch (Size)
                {
                    case Size.Small:
                        return 0.42;
                    case Size.Medium:
                        return 0.76;
                    case Size.Large:
                        return 0.96;
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
        public uint Calories
        {
            get
            {
                switch (Size)
                {
                    case Size.Small:
                        return 77;
                    case Size.Medium:
                        return 89;
                    case Size.Large:
                        return 100;
                    default:
                        throw new NotImplementedException("That size is no implemented.");
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
            return $"{Size} Dragonborn Waffle Fries";
        }//end ToString()
    }//end class DragonbornWaffleFries
}//end namespace