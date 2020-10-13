using BleakwindBuffet.Data;
using BleakwindBuffet.Data.Drinks;
using BleakwindBuffet.Data.Entrees;
using BleakwindBuffet.Data.Sides;
using BleakwindBuffet.DataTests.UnitTests.Mock_Implementations;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

/*
 * Author: Nicholas Sixbury
 * Class: ComboTests.cs
 * Purpose: Test the Combo.cs class in the Data library
 */

namespace BleakwindBuffet.DataTests.UnitTests
{
    /// <summary>
    /// things yet to test:
    /// Need to verify Special instructions for everything
    /// Need to verify property change events
    /// Need to verify collection change events
    /// Need to verify property change events for items within combo
    /// 
    /// </summary>
    public class ComboTests
    {
        [Fact]
        public void ShouldImplementIOrderItemInterface()
        {
            Combo c = new Combo();
            Assert.IsAssignableFrom<IOrderItem>(c);
        }//end test

        [Theory]
        [InlineData(false, false, false, false, false, false)]
        [InlineData(true, true, true, true, true, true)]
        public void ShouldReturnCorrectSpecialInstructions(bool hasEntree, bool entreeOption,
            bool hasSide, bool sideOption, bool hasDrink, bool drinkOption)
        {
            Combo c = new Combo();
            if (hasEntree) c.Entree = new MockEntree(entreeOption);
        }//end test
    }//end class
}//end namespace