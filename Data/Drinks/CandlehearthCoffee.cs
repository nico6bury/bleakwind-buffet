using BleakwindBuffet.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

/*
 * Author: Nicholas Sixbury
 * Class Name: CandlehearthCoffee.cs
 * Purpose: To represent the CandlehearthCoffee drink and
 * hold this item's information
 */

namespace BleakwindBuffet.Data.Drinks
{
    /// <summary>
    /// Represents the Candlehearth Coffee drink item
    /// </summary>
    public class CandlehearthCoffee : Drink, INotifyPropertyChanged
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
            set { 
                ice = value;
                NotifyPropertyChanged("Ice");
                NotifyPropertyChanged("SpecialInstructions");
            }
        }//end getter/setter
        /// <summary>
        /// Whether this item is decaf or not
        /// </summary>
        public bool Decaf
        {
            get { return decaf; }
            set { 
                decaf = value;
                NotifyPropertyChanged("Decaf");
                NotifyPropertyChanged("SpecialInstructions");
            }
        }//end getter/setter
        public bool RoomForCream
        {
            get { return roomForCream; }
            set { 
                roomForCream = value;
                NotifyPropertyChanged("RoomForCream");
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
                        return 0.75;
                    case Size.Medium:
                        return 1.25;
                    case Size.Large:
                        return 1.75;
                    default:
                        throw new NotImplementedException("That size is no implemented.");
                }//end switch case
            }//end getter
        }//end getter
        /// <summary>
        /// the calories of this item, dependant on size
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
                        return 7;
                    case Size.Medium:
                        return 10;
                    case Size.Large:
                        return 20;
                    default:
                        throw new NotImplementedException("That size is no implemented.");
                }//end switch case
            }//end getter
        }//end getter
        /// <summary>
        /// Any special instructions this item might have
        /// </summary>
        public override List<string> SpecialInstructions
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
                de_caffine = " Decaf";
            }//end if item is decaf
            else
            {
                de_caffine = "";
            }//end if item does have caffine
            return $"{Size}{de_caffine} Candlehearth Coffee";
        }//end ToString()
    }//end class CandlehearthCoffee
}//end namespace