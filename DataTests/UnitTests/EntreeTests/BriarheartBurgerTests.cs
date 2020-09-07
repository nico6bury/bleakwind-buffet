/*
 * Author: Zachery Brunner
 * Class: BriarheartBurgerTests.cs
 * Purpose: Test the BriarheartBurger.cs class in the Data library
 */
using Xunit;

using BleakwindBuffet.Data;
using BleakwindBuffet.Data.Entrees;

namespace BleakwindBuffet.DataTests.UnitTests.EntreeTests
{
    public class BriarheartBurgerTests
    {
        
        [Fact]
        public void ShouldIncludeBunByDefault()
        {
            BriarheartBurger bb = new BriarheartBurger();
            Assert.True(bb.Bun);
        }//end test

        [Fact]
        public void ShouldIncludeKetchupByDefault()
        {
            BriarheartBurger bb = new BriarheartBurger();
            Assert.True(bb.Ketchup);
        }//end test

        [Fact]
        public void ShouldIncludeMustardByDefault()
        {
            BriarheartBurger bb = new BriarheartBurger();
            Assert.True(bb.Mustard);
        }//end test

        [Fact]
        public void ShouldIncludePickleByDefault()
        {
            BriarheartBurger bb = new BriarheartBurger();
            Assert.True(bb.Pickle);
        }//end test

        [Fact]
        public void ShouldIncludeCheeseByDefault()
        {
            BriarheartBurger bb = new BriarheartBurger();
            Assert.True(bb.Cheese);
        }//end test

        [Fact]
        public void ShouldBeAbleToSetBun()
        {
            BriarheartBurger bb = new BriarheartBurger();
            bb.Bun = false;
            Assert.False(bb.Bun);
        }//end test

        [Fact]
        public void ShouldBeAbleToSetKetchup()
        {
            BriarheartBurger bb = new BriarheartBurger();
            bb.Ketchup = false;
            Assert.False(bb.Ketchup);
        }//end test

        [Fact]
        public void ShouldBeAbleToSetMustard()
        {
            BriarheartBurger bb = new BriarheartBurger();
            bb.Mustard = false;
            Assert.False(bb.Mustard);
        }//end test

        [Fact]
        public void ShouldBeAbleToSetPickle()
        {
            BriarheartBurger bb = new BriarheartBurger();
            bb.Pickle = false;
            Assert.False(bb.Pickle);
        }//end test

        [Fact]
        public void ShouldBeAbleToSetCheese()
        {
            BriarheartBurger bb = new BriarheartBurger();
            bb.Cheese = false;
            Assert.False(bb.Cheese);
        }//end test

        [Fact]
        public void ShouldReturnCorrectPrice()
        {
            BriarheartBurger bb = new BriarheartBurger();
            double price = 6.32;
            Assert.Equal(price, bb.Price);
        }//end test

        [Fact]
        public void ShouldReturnCorrectCalories()
        {
            BriarheartBurger bb = new BriarheartBurger();
            uint calories = 743;
            Assert.Equal(calories, bb.Calories);
        }//end test

        [Theory]
        [InlineData(true, true, true, true, true)]
        [InlineData(false, false, false, false, false)]
        public void ShouldReturnCorrectSpecialInstructions(bool bun, bool ketchup, bool mustard,
                                                                    bool pickle, bool cheese)
        {
            BriarheartBurger bb = new BriarheartBurger();
            bb.Bun = bun;
            bb.Ketchup = ketchup;
            bb.Mustard = mustard;
            bb.Pickle = pickle;
            bb.Cheese = cheese;
            if (!bun) Assert.Contains("Hold bun", bb.SpecialInstructions);
            if (bun) Assert.DoesNotContain("Hold bun", bb.SpecialInstructions);
            if (!ketchup) Assert.Contains("Hold ketchup", bb.SpecialInstructions);
            if (ketchup) Assert.DoesNotContain("Hold ketchup", bb.SpecialInstructions);
            if (!mustard) Assert.Contains("Hold mustard", bb.SpecialInstructions);
            if (mustard) Assert.DoesNotContain("Hold mustard", bb.SpecialInstructions);
            if (!pickle) Assert.Contains("Hold pickle", bb.SpecialInstructions);
            if (pickle) Assert.DoesNotContain("Hold pickle", bb.SpecialInstructions);
            if (!cheese) Assert.Contains("Hold cheese", bb.SpecialInstructions);
            if (cheese) Assert.DoesNotContain("Hold cheese", bb.SpecialInstructions);
        }//end test

        [Fact]
        public void ShouldReturnCorrectToString()
        {
            BriarheartBurger bb = new BriarheartBurger();
            string name = "Briarheart Burger";
            Assert.Equal(name, bb.ToString());
        }//end test
    }//end class
}//end namespace