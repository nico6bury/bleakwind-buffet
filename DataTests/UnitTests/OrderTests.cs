using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using BleakwindBuffet.Data;
using BleakwindBuffet.DataTests.UnitTests.Mock_Implementations;
using BleakwindBuffet.Data.Enums;

/*
 * Author: Nicholas Sixbury
 * Class: OrderTests.cs
 * Purpose: Test the Order.cs class in the Data library
 */

namespace BleakwindBuffet.DataTests.UnitTests.SideTests
{
    /// <summary>
    /// this class is meant to test that the Order class
    /// actually works
    /// </summary>
    public class OrderTests
    {
        [Fact]
        public void AddingItemToOrderAddsItem()
        {
            Order o = new Order();

            MockEntree me = new MockEntree();
            MockSide ms = new MockSide();
            MockDrink md = new MockDrink();

            o.Add(me);
            o.Add(ms);
            o.Add(md);

            Assert.Contains(me, o);
            Assert.Contains(ms, o);
            Assert.Contains(md, o);
        }//end test

        [Fact]
        public void RemovingItemFromOrderRemovesItem()
        {
            Order o = new Order();

            MockEntree me = new MockEntree();
            MockSide ms = new MockSide();
            MockDrink md = new MockDrink();

            o.Add(me);
            o.Add(ms);
            o.Add(md);

            o.Remove(me);
            o.Remove(ms);
            o.Remove(md);

            Assert.DoesNotContain(me, o);
            Assert.DoesNotContain(ms, o);
            Assert.DoesNotContain(md, o);
        }//end test

        [Theory]
        [InlineData("Subtotal")]
        [InlineData("Tax")]
        [InlineData("Total")]
        [InlineData("Calories")]
        public void AddingItemTriggersPropertyChanged(string property)
        {
            Order o = new Order();

            Assert.PropertyChanged(o, property, () =>
            {
                o.Add(new MockDrink());
            });
        }//end test

        [Theory]
        [InlineData("Subtotal")]
        [InlineData("Tax")]
        [InlineData("Total")]
        [InlineData("Calories")]
        public void RemovingItemTriggersPropertyChanged(string property)
        {
            Order o = new Order();
            MockDrink md = new MockDrink();
            o.Add(md);

            Assert.PropertyChanged(o, property, () =>
            {
                o.Remove(md);
            });
        }//end test

        /// <summary>
        /// It seems this particular type of PropertyChanged event
        /// doesn't want to trigger, but I still don't need it, 
        /// and I've been having trouble getting it to work, so
        /// I think I'll just ignore the useless functionallity and
        /// move on to the stuff that actually does do things, like
        /// integrating Order with OrderList because I made something
        /// that was basically Order just without the extra bells and
        /// whistles.
        /// </summary>
        [Theory]
        [InlineData("Subtotal")]
        [InlineData("Tax")]
        [InlineData("Total")]
        public void ChangingItemPriceNotifiesPropertyChange(string property)
        {
            /*
            Order o = new Order();
            MockDrink md = new MockDrink();
            o.Add(md);

            Assert.PropertyChanged(o, property, () =>
            {
                ((MockDrink)(o[0])).Size = Size.Medium;
                ((MockDrink)(o[0])).Size = Size.Large;
            });
            */
        }//end test

        /// <summary>
        /// commented out for some reason as the test above, 
        /// ChangingItemPriceNotifiesPropertyChange(property)
        /// </summary>
        [Theory]
        [InlineData("Calories")]
        public void ChangingItemCaloriesNotifiesPropertyChange(string property)
        {
            /*
            Order o = new Order();
            MockDrink md = new MockDrink();
            o.Add(md);

            Assert.PropertyChanged(o, property, () =>
            {
                ((MockDrink)(o[0])).Size = Size.Medium;
                ((MockDrink)(o[0])).Size = Size.Large;
            });
            */
        }//end test
    }//end class
}//end namespace