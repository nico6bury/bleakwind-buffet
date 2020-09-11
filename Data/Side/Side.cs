﻿using BleakwindBuffet.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

/*
 * Author: Nicholas Sixbury
 * Class: Side.cs
 * Purpose: To serve as a base class for all Sides
 */ 

namespace BleakwindBuffet.Data.Side
{
    /// <summary>
    /// The base class for all sides, which contains a few common 
    /// fields and is inherited by all sides.
    /// </summary>
    abstract class Side : IOrderItem
    {
        /// <summary>
        /// The size of this item. Based on Size enum found in this project.
        /// </summary>
        public abstract Size Size { get; set; }

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