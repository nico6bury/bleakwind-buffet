/*
 * Author: Zachery Brunner
 * Class: ThalmorTripleTests.cs
 * Purpose: Test the ThalmorTriple.cs class in the Data library
 */
using Xunit;

using BleakwindBuffet.Data;
using BleakwindBuffet.Data.Entrees;

namespace BleakwindBuffet.DataTests.UnitTests.EntreeTests
{
    public class ThalmorTripleTests
    {
        [Fact]
        public void ShouldIncludeBunByDefault()
        {
            ThalmorTriple tt = new ThalmorTriple();
            Assert.True(tt.Bun);
        }//end test

        [Fact]
        public void ShouldIncludeKetchupByDefault()
        {
            ThalmorTriple tt = new ThalmorTriple();
            Assert.True(tt.Ketchup);
        }//end test

        [Fact]
        public void ShouldIncludeMustardByDefault()
        {
            ThalmorTriple tt = new ThalmorTriple();
            Assert.True(tt.Mustard);
        }//end test

        [Fact]
        public void ShouldIncludePickleByDefault()
        {
            ThalmorTriple tt = new ThalmorTriple();
            Assert.True(tt.Pickle);
        }//end test

        [Fact]
        public void ShouldIncludeCheeseByDefault()
        {
            ThalmorTriple tt = new ThalmorTriple();
            Assert.True(tt.Cheese);
        }//end test

        [Fact]
        public void ShouldIncludeTomatoByDefault()
        {
            ThalmorTriple tt = new ThalmorTriple();
            Assert.True(tt.Tomato);
        }//end test

        [Fact]
        public void ShouldIncludeLettuceByDefault()
        {
            ThalmorTriple tt = new ThalmorTriple();
            Assert.True(tt.Lettuce);
        }//end test

        [Fact]
        public void ShouldIncludeMayoByDefault()
        {
            ThalmorTriple tt = new ThalmorTriple();
            Assert.True(tt.Mayo);
        }//end test

        [Fact]
        public void ShouldIncludeBaconByDefault()
        {
            ThalmorTriple tt = new ThalmorTriple();
            Assert.True(tt.Bacon);
        }//end test

        [Fact]
        public void ShouldIncludeEggByDefault()
        {
            ThalmorTriple tt = new ThalmorTriple();
            Assert.True(tt.Egg);
        }//end test

        [Fact]
        public void ShouldBeAbleToSetBun()
        {
            ThalmorTriple tt = new ThalmorTriple();
            tt.Bun = false;
            Assert.False(tt.Bun);
        }//end test

        [Fact]
        public void ShouldBeAbleToSetKetchup()
        {
            ThalmorTriple tt = new ThalmorTriple();
            tt.Ketchup = false;
            Assert.False(tt.Ketchup);
        }//end test

        [Fact]
        public void ShouldBeAbleToSetMustard()
        {
            ThalmorTriple tt = new ThalmorTriple();
            tt.Mustard = false;
            Assert.False(tt.Mustard);
        }//end test

        [Fact]
        public void ShouldBeAbleToSetPickle()
        {
            ThalmorTriple tt = new ThalmorTriple();
            tt.Pickle = false;
            Assert.False(tt.Pickle);
        }//end test

        [Fact]
        public void ShouldBeAbleToSetCheese()
        {
            ThalmorTriple tt = new ThalmorTriple();
            tt.Cheese = false;
            Assert.False(tt.Cheese);
        }//end test

        [Fact]
        public void ShouldBeAbleToSetTomato()
        {
            ThalmorTriple tt = new ThalmorTriple();
            tt.Tomato = false;
            Assert.False(tt.Tomato);
        }//end test

        [Fact]
        public void ShouldBeAbleToSetLettuce()
        {
            ThalmorTriple tt = new ThalmorTriple();
            tt.Lettuce = false;
            Assert.False(tt.Lettuce);
        }//end test

        [Fact]
        public void ShouldBeAbleToSetMayo()
        {
            ThalmorTriple tt = new ThalmorTriple();
            tt.Mayo = false;
            Assert.False(tt.Mayo);
        }//end test

        [Fact]
        public void ShouldBeAbleToSetBacon()
        {
            ThalmorTriple tt = new ThalmorTriple();
            tt.Bacon = false;
            Assert.False(tt.Bacon);
        }//end test

        [Fact]
        public void ShouldBeAbleToSetEgg()
        {
            ThalmorTriple tt = new ThalmorTriple();
            tt.Egg = false;
            Assert.False(tt.Egg);
        }//end test

        [Fact]
        public void ShouldReturnCorrectPrice()
        {
            ThalmorTriple tt = new ThalmorTriple();
            double price = 8.32;
            Assert.Equal(price, tt.Price);
        }//end test

        [Fact]
        public void ShouldReturnCorrectCalories()
        {
            ThalmorTriple tt = new ThalmorTriple();
            uint calories = 943;
            Assert.Equal(calories, tt.Calories);
        }//end test

        [Theory]
        [InlineData(true, true, true, true, true, true, true, true, true, true)]
        [InlineData(false, false, false, false, false, false, false, false, false, false)]
        public void ShouldReturnCorrectSpecialInstructions(bool bun, bool ketchup, bool mustard,
                                                                    bool pickle, bool cheese, bool tomato,
                                                                    bool lettuce, bool mayo,
                                                                    bool bacon, bool egg)
        {
            ThalmorTriple tt = new ThalmorTriple();
            tt.Bun = bun;
            tt.Ketchup = ketchup;
            tt.Mustard = mustard;
            tt.Pickle = pickle;
            tt.Cheese = cheese;
            tt.Tomato = tomato;
            tt.Lettuce = lettuce;
            tt.Mayo = mayo;
            tt.Bacon = bacon;
            tt.Egg = egg;
            if (!bun) Assert.Contains("Hold bun", tt.SpecialInstructions);
            if (bun) Assert.DoesNotContain("Hold bun", tt.SpecialInstructions);
            if (!ketchup) Assert.Contains("Hold ketchup", tt.SpecialInstructions);
            if (ketchup) Assert.DoesNotContain("Hold ketchup", tt.SpecialInstructions);
            if (!mustard) Assert.Contains("Hold mustard", tt.SpecialInstructions);
            if (mustard) Assert.DoesNotContain("Hold mustard", tt.SpecialInstructions);
            if (!pickle) Assert.Contains("Hold pickle", tt.SpecialInstructions);
            if (pickle) Assert.DoesNotContain("Hold pickle", tt.SpecialInstructions);
            if (!cheese) Assert.Contains("Hold cheese", tt.SpecialInstructions);
            if (cheese) Assert.DoesNotContain("Hold cheese", tt.SpecialInstructions);
            if (!tomato) Assert.Contains("Hold tomato", tt.SpecialInstructions);
            if (tomato) Assert.DoesNotContain("Hold tomato", tt.SpecialInstructions);
            if (!lettuce) Assert.Contains("Hold lettuce", tt.SpecialInstructions);
            if (lettuce) Assert.DoesNotContain("Hold lettuce", tt.SpecialInstructions);
            if (!mayo) Assert.Contains("Hold mayo", tt.SpecialInstructions);
            if (mayo) Assert.DoesNotContain("Hold mayo", tt.SpecialInstructions);
            if (!bacon) Assert.Contains("Hold bacon", tt.SpecialInstructions);
            if (bacon) Assert.DoesNotContain("Hold bacon", tt.SpecialInstructions);
            if (!egg) Assert.Contains("Hold egg", tt.SpecialInstructions);
            if (egg) Assert.DoesNotContain("Hold egg", tt.SpecialInstructions);
        }//end test

        [Fact]
        public void ShouldReturnCorrectToString()
        {
            ThalmorTriple tt = new ThalmorTriple();
            string name = "Thalmor Triple";
            Assert.Equal(name, tt.ToString());
        }//end test

        [Theory]
        [InlineData("Bun")]
        [InlineData("Ketchup")]
        [InlineData("Mustard")]
        [InlineData("Pickle")]
        [InlineData("Cheese")]
        [InlineData("Tomato")]
        [InlineData("Lettuce")]
        [InlineData("Mayo")]
        [InlineData("Bacon")]
        [InlineData("Egg")]
        public void ChangingPropertiesNotifiesPropertiesChange(string property)
        {
            var tt = new ThalmorTriple();
            Assert.PropertyChanged(tt, property, () =>
            {
                tt.Bun = true;
                tt.Ketchup = true;
                tt.Mustard = true;
                tt.Pickle = true;
                tt.Cheese = true;
                tt.Tomato = true;
                tt.Lettuce = true;
                tt.Mayo = true;
                tt.Bacon = true;
                tt.Egg = true;
            });
            Assert.PropertyChanged(tt, property, () =>
            {
                tt.Bun = false;
                tt.Ketchup = false;
                tt.Mustard = false;
                tt.Pickle = false;
                tt.Cheese = false;
                tt.Tomato = false;
                tt.Lettuce = false;
                tt.Mayo = false;
                tt.Bacon = false;
                tt.Egg = false;
            });
        }//end test
    }//end class
}//end namespace