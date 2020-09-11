using System;
using System.Collections.Generic;
using System.Text;

/*
 * Author: Nicholas Sixbury
 * Class Name: SmokehouseSkeleton.cs
 * Purpose: Represents the Smokehouse Skeleton item and holds most of 
 * its information in one place
 */

namespace BleakwindBuffet.Data.Entrees
{
    /// <summary>
    /// Represents the Smokehouse Skeleton item
    /// </summary>
    public class SmokehouseSkeleton : Entree
    {
        // backer variable for SausageLink
        private bool sausageLink = true;
        // backer variable for Egg
        private bool egg = true;
        // backer variable for HashBrowns
        private bool hashBrowns = true;
        // backer variable for Pancake
        private bool pancake = true;
        /// <summary>
        /// Whether or not this item has sausage links
        /// </summary>
        public bool SausageLink { get { return sausageLink; } set { sausageLink = value; } }
        /// <summary>
        /// Whether or not this item has an egg
        /// </summary>
        public bool Egg { get { return egg; } set { egg = value; } }
        /// <summary>
        /// Whether or not this item has hashbrowns
        /// </summary>
        public bool HashBrowns { get { return hashBrowns; } set { hashBrowns = value; } }
        /// <summary>
        /// Whether or not this item has pancakes
        /// </summary>
        public bool Pancake { get { return pancake; } set { pancake = value; } }
        /// <summary>
        /// Represents the price of this item
        /// </summary>
        public override double Price
        {
            get { return 5.62; }
        }//end getter
        /// <summary>
        /// Represents the number of calories this item has
        /// </summary>
        public override uint Calories
        {
            get { return 602; }
        }//end getter
        /// <summary>
        /// Contains any special instructions this item has
        /// </summary>
        public override List<string> SpecialInstructions
        {
            get
            {
                List<string> specialInstructions = new List<string>();
                if (!SausageLink) { specialInstructions.Add("Hold sausage"); }
                if (!Egg) { specialInstructions.Add("Hold eggs"); }
                if (!HashBrowns) { specialInstructions.Add("Hold hash browns"); }
                if (!Pancake) { specialInstructions.Add("Hold pancakes"); }
                return specialInstructions;
            }//end getter
        }//end getter

        /// <summary>
        /// ToString() returns a string representation of the object,
        /// in this case the name and nothing else
        /// </summary>
        /// <returns>the name as a string</returns>
        public override string ToString()
        {
            return "Smokehouse Skeleton";
        }//end ToString()
    }//end class SmokehouseSkeleton
}//end namespace