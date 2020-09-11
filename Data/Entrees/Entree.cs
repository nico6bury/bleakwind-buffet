using System;
using System.Collections.Generic;
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
    abstract class Entree : IOrderItem
    {
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
    }//end class
}//end namespace