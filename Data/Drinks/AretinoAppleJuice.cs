using BleakwindBuffet.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

/*
 * Author: Nicholas Sixbury
 * Class Name: AretinoAppleJuice.cs
 * Purpose: Represents AretinoAppleJuice and holds all 
 * that info in one place.
 */

namespace BleakwindBuffet.Data.Drinks
{
    /// <summary>
    /// Represents the Aretino Apple Juice drink item
    /// </summary>
    public class AretinoAppleJuice : Drink, INotifyPropertyChanged
    {
        // backer variable for Ice
        private bool ice = false;
        // backer variable for Size
        private Size size = Size.Small;
        /// <summary>
        /// Whether or not this item has ice
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
        /// The size of this item
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
        /// The price of this item, dependant on size
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
                        return 0.62;
                    case Size.Medium:
                        return 0.87;
                    case Size.Large:
                        return 1.01;
                    default:
                        throw new NotImplementedException("That size is not implemented.");
                }//end switch case
            }//end getter
        }//end getter
        /// <summary>
        /// The calorie amount of this item, dependant on size
        /// </summary>
        public override uint Calories
        {
            get
            {
                switch (Size)
                {
                    case Size.Small:
                        return 44;
                    case Size.Medium:
                        return 88;
                    case Size.Large:
                        return 132;
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
                if (ice) { specialInstructions.Add("Add ice"); }
                return specialInstructions;
            }//end getter
        }//end getter

        /// <summary>
        /// ToString() represents an object as a string, in this case
        /// showing the name and size of this object.
        /// </summary>
        /// <returns>A string representation of this object</returns>
        public override string ToString()
        {
            return $"{Size} Aretino Apple Juice";
        }//end ToString()
    }//end class AretinoAppleJuice
}//end namespace