using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

/*
 * Author: Nicholas Sixbury
 * Interface: IOrderItem.cs
 * Purpose: To provide a weak has-a connection between all the
 * food/drink item classes along with a few variables common between them.
 */ 

namespace BleakwindBuffet.Data
{
    /// <summary>
    /// interface for all items that can be ordered, has
    /// price, calories, and special instructions for the item
    /// </summary>
    public interface IOrderItem : INotifyPropertyChanged
    {
        /// <summary>
        /// The price of the item in question, in dollars
        /// </summary>
        double Price { get; }
        
        /// <summary>
        /// The number of calories the item in question has
        /// </summary>
        uint Calories { get; }
        
        /// <summary>
        /// A list of special instructions for the item in question,
        /// an empty list if there are no special instructions
        /// </summary>
        List<string> SpecialInstructions { get; }
    }//end interface
}//end namespace