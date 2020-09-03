using BleakwindBuffet.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

/*
 * Author: Nicholas Sixbury
 * Class Name: MarkarthMilk.cs
 * Purpose: Represents the MarkarthMilk drink and holds
 * this item's information
 */

namespace BleakwindBuffet.Data.Drinks
{
    /// <summary>
    /// Represents the Markarth Milk drink item
    /// </summary>
    public class MarkarthMilk
    {
        // backer variable for Ice.
        private bool ice = false;
        // backer variable for Size.
        private Size size = Size.Small;
        /// <summary>
        /// Whether or not his item has ice.
        /// </summary>
        public bool Ice
        {
            get { return ice; }
            set { ice = value; }
        }//end getter/setter
        /// <summary>
        /// The size of this item, in small, medium, or large
        /// </summary>
        public Size Size
        {
            get { return size; }
            set { size = value; }
        }//end getter/setter
        /// <summary>
        /// The price of this item, dependant on size
        /// </summary>
        public double Price
        {
            get
            {
                switch (Size)
                {
                    case Size.Small:
                        return 1.05;
                    case Size.Medium:
                        return 1.11;
                    case Size.Large:
                        return 1.22;
                    default:
                        return 0;
                }//end switch case
            }//end getter
        }//end getter
        /// <summary>
        /// The number of Calories within this item, dependant on size
        /// </summary>
        public uint Calories
        {
            get
            {
                switch (Size)
                {
                    case Size.Small:
                        return 56;
                    case Size.Medium:
                        return 72;
                    case Size.Large:
                        return 93;
                    default:
                        return 0;
                }//end switch case
            }//end getter
        }//end getter
        /// <summary>
        /// Contains any special instructions this item might have
        /// </summary>
        public List<string> SpecialInstructions
        {
            get
            {
                List<string> specialInstructions = new List<string>();
                if (Ice) { specialInstructions.Add("Add ice"); }
                return specialInstructions;
            }//end getter
        }//end getter

        /// <summary>
        /// A String representation of this item, in this case
        /// specifying the size and name of this object.
        /// </summary>
        /// <returns>A String representation of this object.</returns>
        public override string ToString()
        {
            return $"{Size} Markarth Milk";
        }//end ToString()
    }//end class MarkarthMilk
}//end namespace