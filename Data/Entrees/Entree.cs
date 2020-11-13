using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using BleakwindBuffet.Data.Enums;

/*
 * Author: Nicholas Sixbury
 * Class: Entree.cs
 * Purpose: To serve as a base class for all Entrees
 */

namespace BleakwindBuffet.Data.Entrees
{
    /// <summary>
    /// The base class for all entrees, which contains a few common 
    /// fields and is inherited by all entrees.
    /// </summary>
    public abstract class Entree : IOrderItem
    {
        /// <summary>
        /// the event to call when the properties start changing
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Returns the price of this item in dollars
        /// </summary>
        public abstract double Price { get; }

        /// <summary>
        /// Returns the number of calories this item has
        /// </summary>
        public abstract uint Calories { get; }

        /// <summary>
        /// Returns a list of special intstruction this item has.
        /// The list can be empty if there are no special instructions
        /// </summary>
        public abstract List<string> SpecialInstructions { get; }

        /// <summary>
        /// A description of this item
        /// </summary>
        public virtual string Description
        {
            get { return "A generic item"; }
        }//end Description

        /// <summary>
        /// This method invokes a PropertyChanged event whenever a method changes a
        /// property and calls this method. It's real handy because now instead of 
        /// writing the same method 16 times, I only have to write it 3 times. Nice.
        /// </summary>
        /// <param name="propName">the name of the property that is 
        /// changing</param>
        public virtual void NotifyPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }//end NotifyPropertyChanged(propName)
    }//end class
}//end namespace