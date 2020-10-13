using BleakwindBuffet.Data;
using BleakwindBuffet.Data.Enums;
using BleakwindBuffet.Data.Sides;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

/*
 * Author: Nicholas Sixbury
 * Class: MockSide.cs
 * Purpose: To serve as a mock implementation of all sides
 */

namespace BleakwindBuffet.DataTests.UnitTests.Mock_Implementations
{
    /// <summary>
    /// A mock implementation for the Side class
    /// </summary>
    public class MockSide : Side, IOrderItem
    {
        /// <summary>
        /// an event to call when the properties change
        /// </summary>
        public event PropertyChangedEventHandler PropertyChangedM;

        private Size size = Size.Small;
        /// <summary>
        /// the side of this item
        /// </summary>
        public override Size Size
        {
            get { return size; }
            set
            {
                if(size != value)
                {
                    size = value;
                    PropertyChangedM?.Invoke(this, new PropertyChangedEventArgs("Size"));
                    PropertyChangedM?.Invoke(this, new PropertyChangedEventArgs("Price"));
                    PropertyChangedM?.Invoke(this, new PropertyChangedEventArgs("Calories"));
                }//end if the property actually changed
            }//end setter
        }//end Size

        /// <summary>
        /// the price of this item
        /// </summary>
        public override double Price
        {
            get
            {
                switch (Size)
                {
                    case Size.Small:
                        return .99;
                    case Size.Medium:
                        return 1.49;
                    case Size.Large:
                        return 1.99;
                    default:
                        throw new NotImplementedException("Side not implmented");
                }//end switch case
            }//end getter
        }//end Price

        /// <summary>
        /// the number of calories of energy this item contains
        /// </summary>
        public override uint Calories
        {
            get
            {
                switch (Size)
                {
                    case Size.Small:
                        return 100;
                    case Size.Medium:
                        return 200;
                    case Size.Large:
                        return 300;
                    default:
                        throw new NotImplementedException("Side not implmented");
                }//end switch case
            }//end getter
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
                if (genericOption != value)
                {
                    genericOption = value;
                    PropertyChangedM?.Invoke(this, new PropertyChangedEventArgs("GenericOption"));
                    PropertyChangedM?.Invoke(this, new PropertyChangedEventArgs("SpecialInstructions"));
                }//end if the property is actually changing
            }//end setter
        }//end GenericOption

        /// <summary>
        /// returns a list of special instructions for this item
        /// </summary>
        public override List<string> SpecialInstructions
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
        public MockSide()
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
        public MockSide(bool GenericOption)
        {
            this.GenericOption = GenericOption;
        }//end 1-arg constructor

        /// <summary>
        /// returns a string representation of this object
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "MockSide";
        }//end ToString()
    }//end class
}//end namespace