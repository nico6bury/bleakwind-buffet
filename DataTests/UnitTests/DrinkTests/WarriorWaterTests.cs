using BleakwindBuffet.Data.Drinks;
using BleakwindBuffet.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

/*
 * Author Nicholas Sixbury
 * Class: WarriorWaterTests.cs
 * Purpose: Test the WarriorWater.cs class in the Data library
 */

namespace BleakwindBuffet.DataTests.UnitTests.DrinkTests
{
    public class WarriorWaterTests
    {
        [Fact]
        public void ShouldIncludeIceByDefault()
        {
            WarriorWater ww = new WarriorWater();
            Assert.True(ww.Ice);
        }//end test

        [Fact]
        public void ShouldBeSmallByDefault()
        {
            WarriorWater ww = new WarriorWater();
            Assert.Equal(Size.Small, ww.Size);
        }//end test

        [Fact]
        public void ShouldNotIncludeLemonByDefault()
        {
            WarriorWater ww = new WarriorWater();
            Assert.False(ww.Lemon);
        }//end test

        [Fact]
        public void ShouldBeAbleToSetIce()
        {
            WarriorWater ww = new WarriorWater();
            ww.Ice = false;
            Assert.False(ww.Ice);
        }//end test

        [Theory]
        [InlineData(Size.Small)]
        [InlineData(Size.Medium)]
        [InlineData(Size.Large)]
        public void ShouldBeAbleToSetSize(Size size)
        {
            WarriorWater ww = new WarriorWater();
            ww.Size = size;
            Assert.Equal(size, ww.Size);
        }//end test

        [Fact]
        public void ShouldHaveCorrectPrice()
        {
            WarriorWater ww = new WarriorWater();
            uint price = 0;
            Assert.Equal(price, ww.Price);
        }//end test

        [Fact]
        public void ShouldHaveCorrectCalories()
        {
            WarriorWater ww = new WarriorWater();
            uint calories = 0;
            Assert.Equal(calories, ww.Calories);
        }//end test

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void ShouldHaveCorrectSpecialInstructions(bool ice, bool lemon)
        {
            WarriorWater ww = new WarriorWater();
            ww.Ice = ice;
            ww.Lemon = lemon;
            if (ice) Assert.DoesNotContain("Hold ice", ww.SpecialInstructions);
            if (!ice) Assert.Contains("Hold ice", ww.SpecialInstructions);
            if (lemon) Assert.Contains("Add lemon", ww.SpecialInstructions);
            if (!lemon) Assert.DoesNotContain("Add lemon", ww.SpecialInstructions);
        }//end test

        [Theory]
        [InlineData(Size.Small,"Small Warrior Water")]
        [InlineData(Size.Medium, "Medium Warrior Water")]
        [InlineData(Size.Large, "Large Warrior Water")]
        public void ShouldReturnCorrectToStringBasedOnSize(Size size, string name)
        {
            WarriorWater ww = new WarriorWater();
            ww.Size = size;
            Assert.Equal(name, ww.ToString());
        }//end test

        [Fact]
        public void ChangingIceNotifiesIceProperty()
        {
            var ww = new WarriorWater();
            Assert.PropertyChanged(ww, "Ice", () =>
            {
                ww.Ice = false;
            });
            Assert.PropertyChanged(ww, "Ice", () =>
            {
                ww.Ice = true;
            });
        }//end test

        [Fact]
        public void ChangingSizeNotifiesSizeProperty()
        {
            var ww = new WarriorWater();
            Assert.PropertyChanged(ww, "Size", () =>
            {
                ww.Size = Size.Medium;
            });
            Assert.PropertyChanged(ww, "Size", () =>
            {
                ww.Size = Size.Large;
            });
        }//end test

        [Fact]
        public void ChangingLemonNotifiesLemonProperty()
        {
            var ww = new WarriorWater();
            Assert.PropertyChanged(ww, "Lemon", () =>
            {
                ww.Lemon = true;
            });
            Assert.PropertyChanged(ww, "Lemon", () =>
            {
                ww.Lemon = false;
            });
        }//end test
    }//end class
}//end namespace