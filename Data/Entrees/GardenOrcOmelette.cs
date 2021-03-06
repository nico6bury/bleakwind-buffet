﻿using System;
using System.Collections.Generic;
using System.Text;

/*
 * Author: Nicholas Sixbury
 * Class Name: GardenOrcOmelette.cs
 * Purpose: Represents the Garden Orc Omelette item and holds most of 
 * its information in one place
 */

namespace BleakwindBuffet.Data.Entrees
{
    /// <summary>
    /// Represents the Garden Orc Omelette item
    /// </summary>
    public class GardenOrcOmelette : Entree
    {
        // backer variable for 
        private bool broccoli = true;
        // backer variable for 
        private bool mushrooms = true;
        // backer variable for 
        private bool tomato = true;
        // backer variable for 
        private bool cheddar = true;
        /// <summary>
        /// Whether or not this item has broccoli
        /// </summary>
        public bool Broccoli { get { return broccoli; } set { broccoli = value; NotifyPropertyChanged("Broccoli"); NotifyPropertyChanged("SpecialInstructions"); } }
        /// <summary>
        /// Whether or not this item has mushrooms
        /// </summary>
        public bool Mushrooms { get { return mushrooms; } set { mushrooms = value; NotifyPropertyChanged("Mushrooms"); NotifyPropertyChanged("SpecialInstructions"); } }
        /// <summary>
        /// Whether or not this item has tomato
        /// </summary>
        public bool Tomato { get { return tomato; } set { tomato = value; NotifyPropertyChanged("Tomato"); NotifyPropertyChanged("SpecialInstructions"); } }
        /// <summary>
        /// Whether or not this item has cheddar
        /// </summary>
        public bool Cheddar { get { return cheddar; } set { cheddar = value; NotifyPropertyChanged("Cheddar"); NotifyPropertyChanged("SpecialInstructions"); } }
        /// <summary>
        /// Represents the price of this item
        /// </summary>
        public override double Price
        {
            get { return 4.57; }
        }//end getter
        /// <summary>
        /// Represents the number of calories this item has
        /// </summary>
        public override uint Calories
        {
            get { return 404; }
        }//end getter
        /// <summary>
        /// Contains any special instructions this item has
        /// </summary>
        public override List<string> SpecialInstructions
        {
            get
            {
                List<string> specialInstructions = new List<string>();
                if (!Broccoli) { specialInstructions.Add("Hold broccoli"); }
                if (!Mushrooms) { specialInstructions.Add("Hold mushrooms"); }
                if (!Tomato) { specialInstructions.Add("Hold tomato"); }
                if (!Cheddar) { specialInstructions.Add("Hold cheddar"); }
                return specialInstructions;
            }//end getter
        }//end getter

        /// <summary>
        /// A description of this item
        /// </summary>
        public override string Description
        {
            get { return "Vegetarian. Two egg omelette packed with a mix" +
                    " of broccoli, mushrooms, and tomatoes. Topped with" +
                    " cheddar cheese."; }
        }//end Description

        /// <summary>
        /// ToString() returns a string representation of the object,
        /// in this case the name and nothing else
        /// </summary>
        /// <returns>the name as a string</returns>
        public override string ToString()
        {
            return "Garden Orc Omelette";
        }//end ToString()
    }//end class GardenOrcOmelette
}//end namespace