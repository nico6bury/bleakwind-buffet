/*
 * Author: Zachery Brunner
 * Class: PhillyPoacherTests.cs
 * Purpose: Test the PhillyPoacher.cs class in the Data library
 */
using Xunit;

using BleakwindBuffet.Data;
using BleakwindBuffet.Data.Entrees;

namespace BleakwindBuffet.DataTests.UnitTests.EntreeTests
{
    public class PhillyPoacherTests
    {
        [Fact]
        public void ShouldInlcudeSirloinByDefault()
        {
            PhillyPoacher pp = new PhillyPoacher();
            Assert.True(pp.Sirloin);
        }//end test

        [Fact]
        public void ShouldInlcudeOnionByDefault()
        {
            PhillyPoacher pp = new PhillyPoacher();
            Assert.True(pp.Onion);
        }//end test

        [Fact]
        public void ShouldInlcudeRollByDefault()
        {
            PhillyPoacher pp = new PhillyPoacher();
            Assert.True(pp.Roll);
        }//end test

        [Fact]
        public void ShouldBeAbleToSetSirloin()
        {
            PhillyPoacher pp = new PhillyPoacher();
            pp.Sirloin = false;
            Assert.False(pp.Sirloin);
        }//end test

        [Fact]
        public void ShouldBeAbleToSetOnions()
        {
            PhillyPoacher pp = new PhillyPoacher();
            pp.Onion = false;
            Assert.False(pp.Onion);
        }//end test

        [Fact]
        public void ShouldBeAbleToSetRoll()
        {
            PhillyPoacher pp = new PhillyPoacher();
            pp.Roll = false;
            Assert.False(pp.Roll);
        }//end test

        [Fact]
        public void ShouldReturnCorrectPrice()
        {
            PhillyPoacher pp = new PhillyPoacher();
            double price = 7.23;
            Assert.Equal(price, pp.Price);
        }//end test

        [Fact]
        public void ShouldReturnCorrectCalories()
        {
            PhillyPoacher pp = new PhillyPoacher();
            uint calories = 784;
            Assert.Equal(calories, pp.Calories);
        }//end test

        [Theory]
        [InlineData(true, true, true)]
        [InlineData(false, false, false)]
        public void ShouldReturnCorrectSpecialInstructions(bool sirloin, bool onion,
                                                            bool roll)
        {
            PhillyPoacher pp = new PhillyPoacher();
            pp.Sirloin = sirloin;
            pp.Onion = onion;
            pp.Roll = roll;
            if (!sirloin) Assert.Contains("Hold sirloin", pp.SpecialInstructions);
            if (sirloin) Assert.DoesNotContain("Hold sirloin", pp.SpecialInstructions);
            if (!onion) Assert.Contains("Hold onions", pp.SpecialInstructions);
            if (onion) Assert.DoesNotContain("Hold onions", pp.SpecialInstructions);
            if (!roll) Assert.Contains("Hold roll", pp.SpecialInstructions);
            if (roll) Assert.DoesNotContain("Hold roll", pp.SpecialInstructions);
        }//end test

        [Fact]
        public void ShouldReturnCorrectToString()
        {
            PhillyPoacher pp = new PhillyPoacher();
            string name = "Philly Poacher";
            Assert.Equal(name, pp.ToString());
        }//end test
    }//end class
}//end namespace