/*
 * Author: Zachery Brunner
 * Class: GardenOrcOmeletteTests.cs
 * Purpose: Test the GardenOrcOmelette.cs class in the Data library
 */
using Xunit;
using BleakwindBuffet.Data;
using BleakwindBuffet.Data.Entrees;

namespace BleakwindBuffet.DataTests.UnitTests.EntreeTests
{
    public class GardenOrcOmeletteTests
    {
        [Fact]
        public void ShouldInlcudeBroccoliByDefault()
        {
            GardenOrcOmelette goo = new GardenOrcOmelette();
            Assert.True(goo.Broccoli);
        }//end test

        [Fact]
        public void ShouldInlcudeMushroomsByDefault()
        {
            GardenOrcOmelette goo = new GardenOrcOmelette();
            Assert.True(goo.Mushrooms);
        }//end test

        [Fact]
        public void ShouldInlcudeTomatoByDefault()
        {
            GardenOrcOmelette goo = new GardenOrcOmelette();
            Assert.True(goo.Tomato);
        }//end test

        [Fact]
        public void ShouldInlcudeCheddarByDefault()
        {
            GardenOrcOmelette goo = new GardenOrcOmelette();
            Assert.True(goo.Cheddar);
        }//end test

        [Fact]
        public void ShouldBeAbleToSetBroccoli()
        {
            GardenOrcOmelette goo = new GardenOrcOmelette();
            goo.Broccoli = false;
            Assert.False(goo.Broccoli);
        }//end test

        [Fact]
        public void ShouldBeAbleToSetMushrooms()
        {
            GardenOrcOmelette goo = new GardenOrcOmelette();
            goo.Mushrooms = false;
            Assert.False(goo.Mushrooms);
        }//end test

        [Fact]
        public void ShouldBeAbleToSetTomato()
        {
            GardenOrcOmelette goo = new GardenOrcOmelette();
            goo.Tomato = false;
            Assert.False(goo.Tomato);
        }//end test

        [Fact]
        public void ShouldBeAbleToSetCheddar()
        {
            GardenOrcOmelette goo = new GardenOrcOmelette();
            goo.Cheddar = false;
            Assert.False(goo.Cheddar);
        }//end test

        [Fact]
        public void ShouldReturnCorrectPrice()
        {
            GardenOrcOmelette goo = new GardenOrcOmelette();
            double price = 4.57;
            Assert.Equal(price, goo.Price);
        }//end test

        [Fact]
        public void ShouldReturnCorrectCalories()
        {
            GardenOrcOmelette goo = new GardenOrcOmelette();
            uint calories = 404;
            Assert.Equal(calories, goo.Calories);
        }//end test

        [Theory]
        [InlineData(true, true, true, true)]
        [InlineData(false, false, false, false)]
        public void ShouldReturnCorrectSpecialInstructions(bool broccoli, bool mushrooms,
                                                            bool tomato, bool cheddar)
        {
            GardenOrcOmelette goo = new GardenOrcOmelette();
            goo.Broccoli = broccoli;
            goo.Mushrooms = mushrooms;
            goo.Tomato = tomato;
            goo.Cheddar = cheddar;
            if (!broccoli) Assert.Contains("Hold broccoli", goo.SpecialInstructions);
            if (broccoli) Assert.DoesNotContain("Hold broccoli", goo.SpecialInstructions);
            if (!mushrooms) Assert.Contains("Hold mushrooms", goo.SpecialInstructions);
            if (mushrooms) Assert.DoesNotContain("Hold mushrooms", goo.SpecialInstructions);
            if (!tomato) Assert.Contains("Hold tomato", goo.SpecialInstructions);
            if (tomato) Assert.DoesNotContain("Hold tomato", goo.SpecialInstructions);
            if (!cheddar) Assert.Contains("Hold cheddar", goo.SpecialInstructions);
            if (cheddar) Assert.DoesNotContain("Hold cheddar", goo.SpecialInstructions);
        }//end test

        [Fact]
        public void ShouldReturnCorrectToString()
        {
            GardenOrcOmelette goo = new GardenOrcOmelette();
            string name = "Garden Orc Omelette";
            Assert.Equal(name, goo.ToString());
        }//end test
    }//end class
}//end namespace