﻿using System;
using System.Collections.Generic;
using System.Text;

/*
 * Author: Nicholas Sixbury
 * Class Name: ThugsTBone.cs
 * Purpose: Represents the Thugs T-Bone item and holds most of 
 * its information in one place
 */ 

namespace BleakwindBuffet.Data.Entrees
{
    /// <summary>
    /// Represents the Thugs T-Bone item
    /// </summary>
    public class ThugsTBone : Entree
    {
        /// <summary>
        /// Represents the price of this item
        /// </summary>
        public override double Price
        {
            get { return 6.44; }
        }//end getter
        /// <summary>
        /// Represents the number of calories this item has
        /// </summary>
        public override uint Calories
        {
            get { return 982; }
        }//end getter
        /// <summary>
        /// Contains any special instructions this item has
        /// </summary>
        public override List<string> SpecialInstructions
        {
            get
            {
                List<string> specialInstructions = new List<string>();
                return specialInstructions;
            }//end getter
        }//end getter

        /// <summary>
        /// A description of this item
        /// </summary>
        public override string Description
        {
            get { return "Juicy T-Bone, not much else to say."; }
        }//end Description

        /// <summary>
        /// ToString() returns a string representation of the object,
        /// in this case the name and nothing else
        /// </summary>
        /// <returns>the name as a string</returns>
        public override string ToString()
        {
            return "Thugs T-Bone";
        }//end ToString()
    }//end class ThugsTBone
}//end namespace