using BleakwindBuffet.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

/*
 * Author: Nicholas Sixbury
 * Class Name: SailorSoda.cs
 * Purpose: Holds all the information for the Sailor
 * Soda drink
 */

namespace BleakwindBuffet.Data.Drinks
{
    /// <summary>
    /// Represents the old-fashioned soda drink 
    /// called Sailor Soda
    /// </summary>
    public class SailorSoda : Drink
    {
        // backer variable for Ice
        private bool ice = true;
        // backer variable for Size
        private Size size = Size.Small;
        // backer variable for Flavor
        private SodaFlavor flavor = SodaFlavor.Cherry;
        /// <summary>
        /// Whether or not this item has ice.
        /// </summary>
        public bool Ice
        {
            get { return ice; }
            set { 
                ice = value;
                NotifyPropertyChanged("Ice");
                NotifyPropertyChanged("SpecialInstructions");
            }
        }//end getter/setter
        /// <summary>
        /// The size of this item, small, medium, or large.
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
        }//end getter/setter
        /// <summary>
        /// The flavor of this item.
        /// </summary>
        public SodaFlavor Flavor
        {
            get { return flavor; }
            set { 
                flavor = value;
                NotifyPropertyChanged("Flavor");
            }
        }//end getter/setter
        /// <summary>
        /// The Price of this item as a double, which depends on size.
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
                        return 1.42;
                    case Size.Medium:
                        return 1.74;
                    case Size.Large:
                        return 2.07;
                    default:
                        throw new NotImplementedException("That size is no implemented.");
                }//end switch case
            }//end getter
        }//end getter
        /// <summary>
        /// The number of calories present in this item, depending 
        /// on size.
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
                        return 117;
                    case Size.Medium:
                        return 153;
                    case Size.Large:
                        return 205;
                    default:
                        throw new NotImplementedException("That size is no implemented.");
                }//end switch case
            }//end getter
        }//end getter
        /// <summary>
        /// Contains any special instructions this item might have
        /// </summary>
        public override List<string> SpecialInstructions
        {
            get
            {
                List<string> specialInstructions = new List<string>();
                if (!Ice) { specialInstructions.Add("Hold ice"); }
                return specialInstructions;
            }//end getter
        }//end getter

        /// <summary>
        /// The ToString() returns a string representation of this
        /// object, in this case the size and flavor in addition to
        /// the name of this item.
        /// </summary>
        /// <returns>A string representation of this item</returns>
        public override string ToString()
        {
            return $"{Size} {Flavor} Sailor Soda";
        }//end ToString()
    }//end class SailorSoda
}//end namespace