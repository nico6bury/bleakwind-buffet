using BleakwindBuffet.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

/*
 * Author: Nicholas Sixbury
 * Class Name: VokunSalad.cs
 * Purpose: To represent a Vokun Salad item and hold 
 * information pertaining to it in one place.
 */

namespace BleakwindBuffet.Data.Sides
{
    /// <summary>
    /// represents a Vokun Salad object
    /// </summary>
    public class VokunSalad : Side
    {
        // backer for variable Size
        private Size size = Size.Small;
        /// <summary>
        /// Represents the size of this item, small, 
        /// medium, or large
        /// </summary>
        public override Size Size
        {
            get { return size; }
            set { 
                size = value;
                NotifyPropertyChanged("Size");
                NotifyPropertyChanged("Price");
                NotifyPropertyChanged("Calories");
            }
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
                        return 0.93;
                    case Size.Medium:
                        return 1.28;
                    case Size.Large:
                        return 1.82;
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
                        return 41;
                    case Size.Medium:
                        return 52;
                    case Size.Large:
                        return 73;
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
            return $"{Size} Vokun Salad";
        }//end ToString()
    }//end class VokunSalad
}//end namespace