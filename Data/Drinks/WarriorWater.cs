using BleakwindBuffet.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

/*
 * Author: Nicholas Sixbury
 * Class Name: WarriorWater.cs
 * Purpose: Holds all the information for the 
 * Warrior Water drink
 */

namespace BleakwindBuffet.Data.Drinks
{
    /// <summary>
    /// Represents the Warrior Water drink
    /// </summary>
    public class WarriorWater : Drink, INotifyPropertyChanged
    {
        // backer variable for Ice
        private bool ice = true;
        // backer variable for Size
        private Size size = Size.Small;
        // backer variable for Lemon
        private bool lemon = false;
        /// <summary>
        /// Whether or not the drink should have ice.
        /// </summary>
        public bool Ice
        {
            get { return ice; }
            set { ice = value; 
                NotifyPropertyChanged("Ice");
                NotifyPropertyChanged("SpecialInstructions");
            }
        }//end Ice getter/setter
        /// <summary>
        /// Whether the drink is small, medium, or large.
        /// </summary>
        public override Size Size
        {
            get { return size; }
            set { size = value; NotifyPropertyChanged("Size"); }
        }//end Size getter/setter
        /// <summary>
        /// Whether or not the drink has added lemon.
        /// </summary>
        public bool Lemon
        {
            get { return lemon; }
            set { lemon = value; 
                NotifyPropertyChanged("Lemon");
                NotifyPropertyChanged("SpecialInstructions");
            }
        }//end Lemon getter/setter
        /// <summary>
        /// The Price of this drink, always free.
        /// </summary>
        public override double Price
        {
            get { return 0; }
        }//end Price getter
        /// <summary>
        /// The Calorie count of this drink, always 0.
        /// </summary>
        public override uint Calories
        {
            get { return 0; }
        }//end Calories getter
        /// <summary>
        /// The special instructions for this item.
        /// </summary>
        public override List<string> SpecialInstructions
        {
            get
            {
                List<string> specialIntructions = new List<string>();
                if(!Ice){ specialIntructions.Add("Hold ice"); }
                if(Lemon){ specialIntructions.Add("Add lemon"); }
                return specialIntructions;
            }//end SpecialInstructions getter
        }//end SpecialInstructions getter

        /// <summary>
        /// A description of this item
        /// </summary>
        public override string Description
        {
            get { return "It’s water. Just water."; }
        }//end Description

        /// <summary>
        /// The ToString() returns a string representation of this
        /// object, in this case the size and name of the item.
        /// </summary>
        /// <returns>A string representation of the item.</returns>
        public override string ToString()
        {
            return $"{size} Warrior Water";
        }//end ToString()
    }//end class
}//end namespace BleakwindBuffet.Data.Drink