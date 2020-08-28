using BleakwindBuffet.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BleakwindBuffet.Data.Drink
{
    public class WarriorWater
    {
        private bool ice = true;
        private Size size = Size.Small;
        private bool lemon = false;
        /// <summary>
        /// Whether or not the drink should have ice.
        /// </summary>
        public bool Ice
        {
            get { return ice; }
            set { ice = value; }
        }//end Ice getter/setter
        /// <summary>
        /// Whether the drink is small, medium, or large.
        /// </summary>
        public Size Size
        {
            get { return size; }
            set { size = value; }
        }//end Size getter/setter
        /// <summary>
        /// Whether or not the drink has added lemon.
        /// </summary>
        public bool Lemon
        {
            get { return lemon; }
            set { lemon = value; }
        }//end Lemon getter/setter
        /// <summary>
        /// The Price of this drink, always free.
        /// </summary>
        public double Price
        {
            get { return 0; }
        }//end Price getter
        /// <summary>
        /// The Calorie count of this drink, always 0.
        /// </summary>
        public uint Calories
        {
            get { return 0; }
        }//end Calories getter
        /// <summary>
        /// The special instructions for this item.
        /// </summary>
        public List<string> SpecialInstructions
        {
            get
            {
                List<string> specialIntructions = new List<string>();
                if(!ice){ specialIntructions.Add("Hold ice"); }
                if(lemon){ specialIntructions.Add("Add lemon"); }
                return specialIntructions;
            }//end SpecialInstructions getter
        }//end SpecialInstructions getter

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