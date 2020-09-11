using System;
using System.Collections.Generic;
using System.Text;

namespace BleakwindBuffet.Data
{
    /// <summary>
    /// interface for all items that can be ordered, has
    /// price, calories, and special instructions for the item
    /// </summary>
    interface IOrderItem
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