/*
 * Author: Zachery Brunner
 * Class: CandlehearthCoffeeTests.cs
 * Purpose: Test the CandlehearthCoffee.cs class in the Data library
 */
using Xunit;

using BleakwindBuffet.Data;
using BleakwindBuffet.Data.Enums;

namespace BleakwindBuffet.DataTests.UnitTests.DrinkTests
{
    public class CandlehearthCoffeeTests
    {
        [Fact]
        public void ShouldNotIncludeIceByDefault()
        {

        }//end test

        [Fact]
        public void ShouldNotBeDecafByDefault()
        {

        }//end test

        [Fact]
        public void ShouldNotHaveRoomForCreamByDefault()
        {

        }//end test

        [Fact]
        public void ShouldBeSmallByDefault()
        {

        }//end test

        [Fact]
        public void ShouldBeAbleToSetIce()
        {

        }//end test

        [Fact]
        public void ShouldBeAbleToSetDecaf()
        {

        }//end test

        [Fact]
        public void ShouldBeAbleToSetRoomForCream()
        {

        }//end test

        [Fact]
        public void ShouldBeAbleToSetSize()
        {

        }//end test

        [Theory]
        [InlineData(Size.Small, 0.75)]
        [InlineData(Size.Medium, 1.25)]
        [InlineData(Size.Large, 1.75)]
        public void ShouldHaveCorrectPriceForSize(Size size, double price)
        {

        }//end test

        [Theory]
        [InlineData(Size.Small, 7)]
        [InlineData(Size.Medium, 10)]
        [InlineData(Size.Large, 20)]
        public void ShouldHaveCorrectCaloriesForSize(Size size, uint cal)
        {

        }//end test

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void ShouldHaveCorrectSpecialInstructions(bool includeIce, bool includeCream)
        {

        }//end test

        [Theory]
        [InlineData(true, Size.Small, "Small Decaf Candlehearth Coffee")]
        [InlineData(true, Size.Medium, "Medium Decaf Candlehearth Coffee")]
        [InlineData(true, Size.Large, "Large Decaf Candlehearth Coffee")]
        [InlineData(false, Size.Small, "Small Candlehearth Coffee")]
        [InlineData(false, Size.Medium, "Medium Candlehearth Coffee")]
        [InlineData(false, Size.Large, "Large Candlehearth Coffee")]
        public void ShouldReturnCorrectToStringBasedOnSize(bool decaf, Size size, string name)
        {

        }//end test
    }//end class
}//end namespace