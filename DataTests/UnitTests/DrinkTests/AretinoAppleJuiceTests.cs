/*
 * Author: Zachery Brunner
 * Class: AretinoAppleJuiceTests.cs
 * Purpose: Test the AretinoAppleJuice.cs class in the Data library
 */
using Xunit;

using BleakwindBuffet.Data;
using BleakwindBuffet.Data.Enums;
using BleakwindBuffet.Data.Drinks;

namespace BleakwindBuffet.DataTests.UnitTests.DrinkTests
{
    public class AretinoAppleJuiceTests
    {
        [Fact]
        public void ShouldNotIncludeIceByDefault()
        {
            AretinoAppleJuice aaj = new AretinoAppleJuice();
            Assert.False(aaj.Ice);
        }//end test

        [Fact]
        public void ShouldBeSmallByDefault()
        {
            AretinoAppleJuice aaj = new AretinoAppleJuice();
            Assert.Equal(Size.Small, aaj.Size);
        }//end test

        [Fact]
        public void ShouldBeAbleToSetIce()
        {
            AretinoAppleJuice aaj = new AretinoAppleJuice();
            aaj.Ice = true;
            Assert.True(aaj.Ice);
        }//end test

        [Fact]
        public void ShouldBeAbleToSetSize()
        {
            AretinoAppleJuice aaj = new AretinoAppleJuice();
            aaj.Size = Size.Medium;
            Assert.Equal(Size.Medium, aaj.Size);
        }//end test

        [Theory]
        [InlineData(Size.Small, 0.62)]
        [InlineData(Size.Medium, 0.87)]
        [InlineData(Size.Large, 1.01)]
        public void ShouldHaveCorrectPriceForSize(Size size, double price)
        {
            AretinoAppleJuice aaj = new AretinoAppleJuice();
            aaj.Size = size;
            Assert.Equal(price, aaj.Price);
        }//end test

        [Theory]
        [InlineData(Size.Small, 44)]
        [InlineData(Size.Medium, 88)]
        [InlineData(Size.Large, 132)]
        public void ShouldHaveCorrectCaloriesForSize(Size size, uint cal)
        {
            AretinoAppleJuice aaj = new AretinoAppleJuice();
            aaj.Size = size;
            Assert.Equal(cal, aaj.Calories);
        }//end test

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void ShouldHaveCorrectSpecialInstructions(bool ice)
        {
            AretinoAppleJuice aaj = new AretinoAppleJuice();
            aaj.Ice = ice;
            if (ice) Assert.Contains("Add ice", aaj.SpecialInstructions);
            if (!ice) Assert.DoesNotContain("Add ice", aaj.SpecialInstructions);
        }//end test

        [Theory]
        [InlineData(Size.Small, "Small Aretino Apple Juice")]
        [InlineData(Size.Medium, "Medium Aretino Apple Juice")]
        [InlineData(Size.Large, "Large Aretino Apple Juice")]
        public void ShouldReturnCorrectToStringBasedOnSize(Size size, string name)
        {
            AretinoAppleJuice aaj = new AretinoAppleJuice();
            aaj.Size = size;
            Assert.Equal(name, aaj.ToString());
        }//end test

        [Theory]
        [InlineData("Ice")]
        [InlineData("SpecialInstructions")]
        public void ChangingIceNotifiesProperties(string property)
        {
            var aaj = new AretinoAppleJuice();
            Assert.PropertyChanged(aaj, property, () =>
            {
                aaj.Ice = false;
            });
            Assert.PropertyChanged(aaj, property, () =>
            {
                aaj.Ice = true;
            });
        }//end test

        [Theory]
        [InlineData("Size")]
        [InlineData("Price")]
        [InlineData("Calories")]
        public void ChangingSizeNotifiesProperties(string property)
        {
            var aaj = new AretinoAppleJuice();
            Assert.PropertyChanged(aaj, property, () =>
            {
                aaj.Size = Size.Medium;
            });
            Assert.PropertyChanged(aaj, property, () =>
            {
                aaj.Size = Size.Large;
            });
        }//end test

    }//end class
}//end namespace