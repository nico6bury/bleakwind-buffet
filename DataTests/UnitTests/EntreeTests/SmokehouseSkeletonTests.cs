/*
 * Author: Zachery Brunner
 * Class: SmokehouseSkeletonTests.cs
 * Purpose: Test the SmokehouseSkeleton.cs class in the Data library
 */
using Xunit;

using BleakwindBuffet.Data;
using BleakwindBuffet.Data.Entrees;

namespace BleakwindBuffet.DataTests.UnitTests.EntreeTests
{
    public class SmokehouseSkeletonTests
    {        
        [Fact]
        public void ShouldInlcudeSausageByDefault()
        {
            SmokehouseSkeleton ss = new SmokehouseSkeleton();
            Assert.True(ss.SausageLink);
        }//end test

        [Fact]
        public void ShouldInlcudeEggByDefault()
        {
            SmokehouseSkeleton ss = new SmokehouseSkeleton();
            Assert.True(ss.Egg);
        }//end test

        [Fact]
        public void ShouldInlcudeHashbrownsByDefault()
        {
            SmokehouseSkeleton ss = new SmokehouseSkeleton();
            Assert.True(ss.HashBrowns);
        }//end test

        [Fact]
        public void ShouldInlcudePancakeByDefault()
        {
            SmokehouseSkeleton ss = new SmokehouseSkeleton();
            Assert.True(ss.Pancake);
        }//end test

        [Fact]
        public void ShouldBeAbleToSetSausage()
        {
            SmokehouseSkeleton ss = new SmokehouseSkeleton();
            ss.SausageLink = false;
            Assert.False(ss.SausageLink);
        }//end test

        [Fact]
        public void ShouldBeAbleToSetEgg()
        {
            SmokehouseSkeleton ss = new SmokehouseSkeleton();
            ss.Egg = false;
            Assert.False(ss.Egg);
        }//end test

        [Fact]
        public void ShouldBeAbleToSetHashbrowns()
        {
            SmokehouseSkeleton ss = new SmokehouseSkeleton();
            ss.HashBrowns = false;
            Assert.False(ss.HashBrowns);
        }//end test

        [Fact]
        public void ShouldBeAbleToSetPancake()
        {
            SmokehouseSkeleton ss = new SmokehouseSkeleton();
            ss.Pancake = false;
            Assert.False(ss.Pancake);
        }//end test

        [Fact]
        public void ShouldReturnCorrectPrice()
        {
            SmokehouseSkeleton ss = new SmokehouseSkeleton();
            double price = 5.62;
            Assert.Equal(price, ss.Price);
        }//end test

        [Fact]
        public void ShouldReturnCorrectCalories()
        {
            SmokehouseSkeleton ss = new SmokehouseSkeleton();
            uint calories = 602;
            Assert.Equal(calories, ss.Calories);
        }//end test

        [Theory]
        [InlineData(true, true, true, true)]
        [InlineData(false, false, false, false)]
        public void ShouldReturnCorrectSpecialInstructions(bool sausage, bool egg,
                                                            bool hashbrowns, bool pancake)
        {
            SmokehouseSkeleton ss = new SmokehouseSkeleton();
            ss.SausageLink = sausage;
            ss.Egg = egg;
            ss.HashBrowns = hashbrowns;
            ss.Pancake = pancake;
            if (!sausage) Assert.Contains("Hold sausage", ss.SpecialInstructions);
            if (sausage) Assert.DoesNotContain("Hold sausage", ss.SpecialInstructions);
            if (!egg) Assert.Contains("Hold eggs", ss.SpecialInstructions);
            if (egg) Assert.DoesNotContain("Hold eggs", ss.SpecialInstructions);
            if (!hashbrowns) Assert.Contains("Hold hash browns", ss.SpecialInstructions);
            if (hashbrowns) Assert.DoesNotContain("Hold hash browns", ss.SpecialInstructions);
            if (!pancake) Assert.Contains("Hold pancakes", ss.SpecialInstructions);
            if (pancake) Assert.DoesNotContain("Hold pancakes", ss.SpecialInstructions);
        }//end test

        [Fact]
        public void ShouldReturnCorrectToString()
        {
            SmokehouseSkeleton ss = new SmokehouseSkeleton();
            string name = "Smokehouse Skeleton";
            Assert.Equal(name, ss.ToString());
        }//end test
    }//end class
}//end namespace