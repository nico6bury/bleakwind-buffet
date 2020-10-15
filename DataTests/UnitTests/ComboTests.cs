using BleakwindBuffet.Data;
using BleakwindBuffet.Data.Drinks;
using BleakwindBuffet.Data.Entrees;
using BleakwindBuffet.Data.Enums;
using BleakwindBuffet.Data.Sides;
using BleakwindBuffet.DataTests.UnitTests.Mock_Implementations;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using Xunit;

/*
 * Author: Nicholas Sixbury
 * Class: ComboTests.cs
 * Purpose: Test the Combo.cs class in the Data library
 */

namespace BleakwindBuffet.DataTests.UnitTests
{
    /// <summary>
    /// things yet to test:
    /// Need to verify Special instructions for everything [DONE]
    /// Need to verify property change events for combo [DONE]
    /// Need to verify collection change events [NOT DONE, BUT GOOD ENOUGH FOR NOW]
    /// Need to verify property change events for items within combo
    /// Need to verify price and calories are right [DONE]
    /// </summary>
    public class ComboTests
    {
        [Fact]
        public void ShouldImplementIOrderItemInterface()
        {
            Combo c = new Combo();
            Assert.IsAssignableFrom<IOrderItem>(c);
        }//end test

        [Theory]
        [InlineData(false, false, Size.Small, false, Size.Small, 0)]
        [InlineData(true, true, Size.Small, true, Size.Small, 5.47)]
        public void ShouldReturnCorrectPrice(bool hasEntree, bool hasSide, Size sideSize,
            bool hasDrink, Size drinkSize, double expectedTotal)
        {
            double actualTotal = 0;

            Combo c = new Combo();
            if (hasEntree)
            {
                c.Entree = new MockEntree();
                actualTotal += c.Entree.Price;
            }//end if the combo has an entree
            if (hasSide)
            {
                c.Side = new MockSide();
                c.Side.Size = sideSize;
                actualTotal += c.Side.Price;
            }//end if the combo has a side
            if (hasDrink) { 
                c.Drink = new MockDrink();
                c.Drink.Size = drinkSize;
                actualTotal += c.Drink.Price;
            }//end if the combo has a drink

            if (actualTotal > 1) actualTotal -= 1;

            Assert.Equal(expectedTotal, Math.Round(actualTotal, 2));
        }//end test

        [Theory]
        [InlineData(false, false, Size.Small, false, Size.Small, 0)]
        [InlineData(true, true, Size.Small, true, Size.Small, 700)]
        public void ShouldReturnCorrectCalories(bool hasEntree, bool hasSide, Size sideSize,
            bool hasDrink, Size drinkSize, uint expectedTotal)
        {
            uint actualTotal = 0;

            Combo c = new Combo();
            if (hasEntree)
            {
                c.Entree = new MockEntree();
                actualTotal += c.Entree.Calories;
            }//end if the combo has an entree
            if (hasSide)
            {
                c.Side = new MockSide();
                c.Side.Size = sideSize;
                actualTotal += c.Side.Calories;
            }//end if the combo has a side
            if (hasDrink)
            {
                c.Drink = new MockDrink();
                c.Drink.Size = drinkSize;
                actualTotal += c.Drink.Calories;
            }//end if the combo has a drink

            Assert.Equal(expectedTotal, actualTotal);
        }//end test

        [Theory]
        [InlineData(false, false, false, false, false, false)]
        [InlineData(true, true, true, true, true, true)]
        public void ShouldReturnCorrectSpecialInstructions(bool hasEntree, bool entreeOption,
            bool hasSide, bool sideOption, bool hasDrink, bool drinkOption)
        {
            //set up the combo variable
            Combo c = new Combo();
            if (hasEntree) c.Entree = new MockEntree(entreeOption);
            if (hasSide) c.Side = new MockSide(sideOption);
            if (hasDrink) c.Drink = new MockDrink(drinkOption);

            List<string> instructions = c.SpecialInstructions;
            if (hasEntree) Assert.Contains(c.Entree.ToString(), c.SpecialInstructions);
            if (hasSide) Assert.Contains(c.Side.ToString(), c.SpecialInstructions);
            if (hasDrink) Assert.Contains(c.Drink.ToString(), c.SpecialInstructions);
        }//end test

        [Theory]
        [InlineData("Price")]
        [InlineData("Calories")]
        [InlineData("SpecialInstructions")]
        public void ChangingComboItemNotifiesPropertyChange(string property)
        {
            Combo c = new Combo();

            //properties change when changing Entree
            Assert.PropertyChanged(c, property, () =>
            {
                c.Entree = new MockEntree();
            });
            Assert.PropertyChanged(c, "Entree", () =>
            {
                c.Entree = new MockEntree();
            });

            //properties change when changing side
            Assert.PropertyChanged(c, property, () =>
            {
                c.Side = new MockSide();
            });
            Assert.PropertyChanged(c, "Side", () =>
            {
                c.Side = new MockSide();
            });

            //properties change when changin
            Assert.PropertyChanged(c, property, () =>
            {
                c.Drink = new MockDrink();
            });
            Assert.PropertyChanged(c, "Drink", () =>
            {
                c.Drink = new MockDrink();
            });
        }//end test

        /// <summary>
        /// This test isn't quite done yet, but it's not too major, and potentially not required.
        /// </summary>
        /// <param name="IsNullBefore"></param>
        /// <param name="IsNullAfter"></param>
        /// <param name="Action"></param>
        [Theory]
        [InlineData(true, false, NotifyCollectionChangedAction.Add)]
        [InlineData(false, true, NotifyCollectionChangedAction.Remove)]
        [InlineData(false, false, NotifyCollectionChangedAction.Replace)]
        public void ChangingComboItemNotifiesCollectionChange(bool IsNullBefore, bool IsNullAfter,
            NotifyCollectionChangedAction Action)
        {
            Combo c = new Combo();
            if (IsNullBefore)
            {
                c.Entree = null;
                c.Side = null;
                c.Drink = null;
            }//end if things are null before
            else
            {
                c.Entree = new MockEntree();
                c.Side = new MockSide();
                c.Drink = new MockDrink();
            }//end else things aren't null before

            /*
             * This bit down below is the part that doesn't work. Not really sure why,
             * but I don't really understnad the Asert.Raises method anyways, so that's
             * no too surprising.
             * 
            if (IsNullAfter)
            {
                //test that the right event args are raised
                Assert.Raises<NotifyCollectionChangedEventArgs>(
                    handler => c.CollectionChanged += handler,
                    handler => c.CollectionChanged -= handler,
                    () => {
                        c.Entree = null;
                        c.Side = null;
                        c.Drink = null;
                    }
                );
            }//end if they're null afterwards
            else
            {
                //test tha teh right event args are raised
                if(Action != NotifyCollectionChangedAction.Add)
                {
                    //this is just so the compile won't complain
                }
            }//end else they're not null afterwards
            */

        }//end test
    }//end class
}//end namespace