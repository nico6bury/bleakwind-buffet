using BleakwindBuffet.Data;
using BleakwindBuffet.Data.Entrees;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

/*
 * Author: Nicholas Sixbury
 * Class: MockEntree.cs
 * Purpose: To serve as a mock implementation of all entrees
 */

namespace BleakwindBuffet.DataTests.UnitTests.Mock_Implementations
{
    /// <summary>
    /// A mock implementation for the entree class
    /// </summary>
    public class MockEntree : IOrderItem
    {
        /// <summary>
        /// event called when one of this item's properties changes
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// the price of this item
        /// </summary>
        public double Price
        {
            get { return 3.99; }
        }//end Price

        /// <summary>
        /// the calories of this item
        /// </summary>
        public uint Calories
        {
            get { return 400; }
        }//end Calories

        private bool genericOption = true;
        /// <summary>
        /// a generic option in order to showcase SpecialInstructions
        /// </summary>
        public bool GenericOption
        {
            get { return genericOption; }
            set
            {
                if(genericOption != value)
                {
                    genericOption = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("GenericOption"));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SpecialInstructions"));
                }//end if the property is actually changing
            }//end setter
        }//end GenericOption

        /// <summary>
        /// the special instructions for this item
        /// </summary>
        public List<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new List<string>();
                if (!GenericOption) instructions.Add("Hold genericOption");
                return instructions;
            }//end getter
        }//end SpecialInstructions

        /// <summary>
        /// this constructor doesn't do anything
        /// </summary>
        public MockEntree()
        {
            //this does nothing
        }//end no-arg constructor

        /// <summary>
        /// this constructor allows you to set up 
        /// <paramref name="GenericOption"/> as you 
        /// initialize the object
        /// </summary>
        /// <param name="GenericOption">the value passed 
        /// into GenericOption</param>
        public MockEntree(bool GenericOption)
        {
            this.GenericOption = GenericOption;
        }//end 1-arg constructor

        /// <summary>
        /// returns a string representation of this object
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "MockEntree";
        }//end ToString()
    }//end GenericEntree
}//end namespace