/*
 * Author: Zachery Brunner
 * Class: DoubleDraugrTests.cs
 * Purpose: Test the DoubleDraugr.cs class in the Data library
 */
using Xunit;

using BleakwindBuffet.Data;
using BleakwindBuffet.Data.Entrees;

namespace BleakwindBuffet.DataTests.UnitTests.EntreeTests
{
    public class DoubleDraugrTests
    {   
        [Fact]
        public void ShouldIncludeBunByDefault()
        {
            DoubleDraugr dd = new DoubleDraugr();
            Assert.True(dd.Bun);
        }//end test

        [Fact]
        public void ShouldIncludeKetchupByDefault()
        {
            DoubleDraugr dd = new DoubleDraugr();
            Assert.True(dd.Ketchup);
        }//end test

        [Fact]
        public void ShouldIncludeMustardByDefault()
        {
            DoubleDraugr dd = new DoubleDraugr();
            Assert.True(dd.Mustard);
        }//end test

        [Fact]
        public void ShouldIncludePickleByDefault()
        {
            DoubleDraugr dd = new DoubleDraugr();
            Assert.True(dd.Pickle);
        }//end test

        [Fact]
        public void ShouldIncludeCheeseByDefault()
        {
            DoubleDraugr dd = new DoubleDraugr();
            Assert.True(dd.Cheese);
        }//end test

        [Fact]
        public void ShouldIncludeTomatoByDefault()
        {
            DoubleDraugr dd = new DoubleDraugr();
            Assert.True(dd.Tomato);
        }//end test

        [Fact]
        public void ShouldIncludeLettuceByDefault()
        {
            DoubleDraugr dd = new DoubleDraugr();
            Assert.True(dd.Lettuce);
        }//end test

        [Fact]
        public void ShouldIncludeMayoByDefault()
        {
            DoubleDraugr dd = new DoubleDraugr();
            Assert.True(dd.Mayo);
        }//end test

        [Fact]
        public void ShouldBeAbleToSetBun()
        {
            DoubleDraugr dd = new DoubleDraugr();
            dd.Bun = false;
            Assert.False(dd.Bun);
        }//end test

        [Fact]
        public void ShouldBeAbleToSetKetchup()
        {
            DoubleDraugr dd = new DoubleDraugr();
            dd.Ketchup = false;
            Assert.False(dd.Ketchup);
        }//end test

        [Fact]
        public void ShouldBeAbleToSetMustard()
        {
            DoubleDraugr dd = new DoubleDraugr();
            dd.Mustard = false;
            Assert.False(dd.Mustard);
        }//end test

        [Fact]
        public void ShouldBeAbleToSetPickle()
        {
            DoubleDraugr dd = new DoubleDraugr();
            dd.Pickle = false;
            Assert.False(dd.Pickle);
        }//end test

        [Fact]
        public void ShouldBeAbleToSetCheese()
        {
            DoubleDraugr dd = new DoubleDraugr();
            dd.Cheese = false;
            Assert.False(dd.Cheese);
        }//end test

        [Fact]
        public void ShouldBeAbleToSetTomato()
        {
            DoubleDraugr dd = new DoubleDraugr();
            dd.Tomato = false;
            Assert.False(dd.Tomato);
        }//end test

        [Fact]
        public void ShouldBeAbleToSetLettuce()
        {
            DoubleDraugr dd = new DoubleDraugr();
            dd.Lettuce = false;
            Assert.False(dd.Lettuce);
        }//end test

        [Fact]
        public void ShouldBeAbleToSetMayo()
        {
            DoubleDraugr dd = new DoubleDraugr();
            dd.Mayo = false;
            Assert.False(dd.Mayo);
        }//end test

        [Fact]
        public void ShouldReturnCorrectPrice()
        {
            DoubleDraugr dd = new DoubleDraugr();
            double price = 7.32;
            Assert.Equal(price, dd.Price);
        }//end test

        [Fact]
        public void ShouldReturnCorrectCalories()
        {
            DoubleDraugr dd = new DoubleDraugr();
            uint calories = 843;
            Assert.Equal(calories, dd.Calories);
        }//end test

        [Theory]
        [InlineData(true, true, true, true, true, true, true, true)]
        [InlineData(false, false, false, false, false, false, false, false)]
        public void ShouldReturnCorrectSpecialInstructions(bool bun, bool ketchup, bool mustard,
                                                                    bool pickle, bool cheese, bool tomato,
                                                                    bool lettuce, bool mayo)
        {
            DoubleDraugr dd = new DoubleDraugr();
            dd.Bun = bun;
            dd.Ketchup = ketchup;
            dd.Mustard = mustard;
            dd.Pickle = pickle;
            dd.Cheese = cheese;
            dd.Tomato = tomato;
            dd.Lettuce = lettuce;
            dd.Mayo = mayo;
            if (!bun) Assert.Contains("Hold bun", dd.SpecialInstructions);
            if (bun) Assert.DoesNotContain("Hold bun", dd.SpecialInstructions);
            if (!ketchup) Assert.Contains("Hold ketchup", dd.SpecialInstructions);
            if (ketchup) Assert.DoesNotContain("Hold ketchup", dd.SpecialInstructions);
            if (!mustard) Assert.Contains("Hold mustard", dd.SpecialInstructions);
            if (mustard) Assert.DoesNotContain("Hold mustard", dd.SpecialInstructions);
            if (!pickle) Assert.Contains("Hold pickle", dd.SpecialInstructions);
            if (pickle) Assert.DoesNotContain("Hold pickle", dd.SpecialInstructions);
            if (!cheese) Assert.Contains("Hold cheese", dd.SpecialInstructions);
            if (cheese) Assert.DoesNotContain("Hold cheese", dd.SpecialInstructions);
            if (!tomato) Assert.Contains("Hold tomato", dd.SpecialInstructions);
            if (tomato) Assert.DoesNotContain("Hold tomato", dd.SpecialInstructions);
            if (!lettuce) Assert.Contains("Hold lettuce", dd.SpecialInstructions);
            if (lettuce) Assert.DoesNotContain("Hold lettuce", dd.SpecialInstructions);
            if (!mayo) Assert.Contains("Hold mayo", dd.SpecialInstructions);
            if (mayo) Assert.DoesNotContain("Hold mayo", dd.SpecialInstructions);
        }//end test

        [Fact]
        public void ShouldReturnCorrectToString()
        {
            DoubleDraugr dd = new DoubleDraugr();
            string name = "Double Draugr";
            Assert.Equal(name, dd.ToString());
        }//end test
    }//end class
}//end namespace