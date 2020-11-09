using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using BleakwindBuffet.Data.Drinks;
using BleakwindBuffet.Data.Entrees;
using BleakwindBuffet.Data.Enums;
using BleakwindBuffet.Data.Sides;
using BleakwindBuffet.Data;

/*
 * Author: Nicholas Sixbury
 * Class: MenuTests.cs
 * Purpose: To test the methods of the menu class and ensure they are
 * in working order.
 */

namespace BleakwindBuffet.DataTests.UnitTests
{
    public class MenuTests
    {
        [Fact]
        public void AllEntreesImplementIOrderItemInterface()
        {
            List<IOrderItem> ls = (List<IOrderItem>)Menu.Entrees();
            for(int i = 0; i < ls.Count; i++)
            {
                Assert.IsAssignableFrom<IOrderItem>(ls[i]);
            }//end looping over each element of ls
        }//end test

        [Fact]
        public void AllSidesImplementIOrderItemInterface()
        {
            List<IOrderItem> ls = (List<IOrderItem>)Menu.Sides();
            for (int i = 0; i < ls.Count; i++)
            {
                Assert.IsAssignableFrom<IOrderItem>(ls[i]);
            }//end looping over each element of ls
        }//end test

        [Fact]
        public void AllDrinksImplementIOrderItemInterface()
        {
            List<IOrderItem> ls = (List<IOrderItem>)Menu.Drinks();
            for (int i = 0; i < ls.Count; i++)
            {
                Assert.IsAssignableFrom<IOrderItem>(ls[i]);
            }//end looping over each element of ls
        }//end test

        [Fact]
        public void AllEntreesInheritFromEntreeClass()
        {
            List<IOrderItem> ls = (List<IOrderItem>)Menu.Entrees();
            for (int i = 0; i < ls.Count; i++)
            {
                Assert.IsAssignableFrom<Entree>(ls[i]);
            }//end looping over each element of ls
        }//end test

        [Fact]
        public void AllSidesInheritFromSideClass()
        {
            List<IOrderItem> ls = (List<IOrderItem>)Menu.Sides();
            for (int i = 0; i < ls.Count; i++)
            {
                Assert.IsAssignableFrom<Side>(ls[i]);
            }//end looping over each element of ls
        }//end test

        [Fact]
        public void AllDrinksInheritFromDrinkClass()
        {
            List<IOrderItem> ls = (List<IOrderItem>)Menu.Drinks();
            for (int i = 0; i < ls.Count; i++)
            {
                Assert.IsAssignableFrom<Drink>(ls[i]);
            }//end looping over each element of ls
        }//end test

        [Fact]
        public void EntreesMenuHasAllEntreeItems()
        {
            List<IOrderItem> ls = (List<IOrderItem>)Menu.Entrees();
            //7 assertions in total here
            Assert.Equal("Briarheart Burger", ls[0].ToString());
            Assert.Equal("Double Draugr", ls[1].ToString());
            Assert.Equal("Garden Orc Omelette", ls[2].ToString());
            Assert.Equal("Philly Poacher", ls[3].ToString());
            Assert.Equal("Smokehouse Skeleton", ls[4].ToString());
            Assert.Equal("Thalmor Triple", ls[5].ToString());
            Assert.Equal("Thugs T-Bone", ls[6].ToString());
        }//end test
        
        [Fact]
        public void SidesMenuHasAllSideItems()
        {
            List<IOrderItem> ls = (List<IOrderItem>)Menu.Sides();
            //12 assertions in total here
            Assert.Equal("Small Dragonborn Waffle Fries", ls[0].ToString());
            Assert.Equal("Small Fried Miraak", ls[1].ToString());
            Assert.Equal("Small Mad Otar Grits", ls[2].ToString());
            Assert.Equal("Small Vokun Salad", ls[3].ToString());
            
            Assert.Equal("Medium Dragonborn Waffle Fries", ls[4].ToString());
            Assert.Equal("Medium Fried Miraak", ls[5].ToString());
            Assert.Equal("Medium Mad Otar Grits", ls[6].ToString());
            Assert.Equal("Medium Vokun Salad", ls[7].ToString());
            
            Assert.Equal("Large Dragonborn Waffle Fries", ls[8].ToString());
            Assert.Equal("Large Fried Miraak", ls[9].ToString());
            Assert.Equal("Large Mad Otar Grits", ls[10].ToString());
            Assert.Equal("Large Vokun Salad", ls[11].ToString());
        }//end test

        [Fact]
        public void DrinksMenuHasAllDrinkItems()
        {
            List<IOrderItem> ls = (List<IOrderItem>)Menu.Drinks();
            //33 assertions in total here

            //test for small size
            Assert.Equal("Small Aretino Apple Juice", ls[0].ToString());
            
            Assert.Equal("Small Candlehearth Coffee", ls[1].ToString());
            Assert.Equal("Small Decaf Candlehearth Coffee", ls[2].ToString());
            
            Assert.Equal("Small Markarth Milk", ls[3].ToString());
            
            Assert.Equal("Small Blackberry Sailor Soda", ls[4].ToString());
            Assert.Equal("Small Cherry Sailor Soda", ls[5].ToString());
            Assert.Equal("Small Grapefruit Sailor Soda", ls[6].ToString());
            Assert.Equal("Small Lemon Sailor Soda", ls[7].ToString());
            Assert.Equal("Small Peach Sailor Soda", ls[8].ToString());
            Assert.Equal("Small Watermelon Sailor Soda", ls[9].ToString());

            Assert.Equal("Small Warrior Water", ls[10].ToString());

            //test for medium size
            Assert.Equal("Medium Aretino Apple Juice", ls[11].ToString());
            
            Assert.Equal("Medium Candlehearth Coffee", ls[12].ToString());
            Assert.Equal("Medium Decaf Candlehearth Coffee", ls[13].ToString());
            
            Assert.Equal("Medium Markarth Milk", ls[14].ToString());
            
            Assert.Equal("Medium Blackberry Sailor Soda", ls[15].ToString());
            Assert.Equal("Medium Cherry Sailor Soda", ls[16].ToString());
            Assert.Equal("Medium Grapefruit Sailor Soda", ls[17].ToString());
            Assert.Equal("Medium Lemon Sailor Soda", ls[18].ToString());
            Assert.Equal("Medium Peach Sailor Soda", ls[19].ToString());
            Assert.Equal("Medium Watermelon Sailor Soda", ls[20].ToString());

            Assert.Equal("Medium Warrior Water", ls[21].ToString());

            //test for large size
            Assert.Equal("Large Aretino Apple Juice", ls[22].ToString());
            
            Assert.Equal("Large Candlehearth Coffee", ls[23].ToString());
            Assert.Equal("Large Decaf Candlehearth Coffee", ls[24].ToString());
            
            Assert.Equal("Large Markarth Milk", ls[25].ToString());
            
            Assert.Equal("Large Blackberry Sailor Soda", ls[26].ToString());
            Assert.Equal("Large Cherry Sailor Soda", ls[27].ToString());
            Assert.Equal("Large Grapefruit Sailor Soda", ls[28].ToString());
            Assert.Equal("Large Lemon Sailor Soda", ls[29].ToString());
            Assert.Equal("Large Peach Sailor Soda", ls[30].ToString());
            Assert.Equal("Large Watermelon Sailor Soda", ls[31].ToString());
            
            Assert.Equal("Large Warrior Water", ls[32].ToString());
        }//end test

        [Fact]
        public void FullMenuIsCorrectSize()
        {
            List<IOrderItem> ls = (List<IOrderItem>)Menu.FullMenu();
            int expectedMenuSize = 52;
            Assert.Equal(expectedMenuSize, ls.Count);
        }//end test

        [Fact]
        public void FullMenuHasNoDuplicates()
        {
            List<IOrderItem> ls = (List<IOrderItem>)Menu.FullMenu();
            List<string> strings = new List<string>();
            foreach(IOrderItem item in ls)
            {
                strings.Add(item.ToString());
            }//end adding all strings to strings

            List<string> alreadySeen = new List<string>();
            bool foundDupe = false;
            for(int i = 0; i < strings.Count && !foundDupe; i++)
            {
                if (alreadySeen.Contains(strings[i]))
                {
                    //we found a dupe
                    foundDupe = true;
                }//end if we found a duplicate
                else
                {
                    alreadySeen.Add(strings[i]);
                }//end else we continue onwards
            }//end looping over each element in strings to find dupes

            Assert.False(foundDupe);
        }//end test

        [Theory]
        [InlineData("medium")]
        [InlineData("Soda")]
        public void SearchFilteredItemsContainSearchTerm(string term)
        {
            List<IOrderItem> filteredItems = (List<IOrderItem>)Menu.Search(Menu.FullMenu(), term);
            foreach(IOrderItem item in filteredItems)
            {
                Assert.Contains(term.ToLower(), item.ToString().ToLower());
            }//end looping foreach item in the list of filtered items
        }//end test

        [Theory]
        [InlineData("Soda")]
        [InlineData("medium")]
        public void SearchFilterIsNotCaseSensitive(string term)
        {
            string termLower = term.ToLower();
            string termUpper = term.ToUpper();
            List<IOrderItem> filteredItemsLower = (List<IOrderItem>)Menu.Search(Menu.FullMenu(), termLower);
            List<IOrderItem> filteredItemsUpper = (List<IOrderItem>)Menu.Search(Menu.FullMenu(), termUpper);
            for(int i = 0; i < filteredItemsLower.Count; i++)
            {
                Assert.Equal(filteredItemsLower[i].ToString(), filteredItemsUpper[i].ToString());
            }//end looping for each item
        }//end test

        [Theory]
        [InlineData(typeof(Entree))]
        [InlineData(typeof(Side))]
        [InlineData(typeof(Drink))]
        public void OrderTypeFilteredItemsAreRightType(Type type)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(type.Name);
            sb.Append("s");
            List<string> types = new List<string>();
            types.Add(sb.ToString());
            List<IOrderItem> items = (List<IOrderItem>)Menu.FilterByOrderType(Menu.FullMenu(), types);
            foreach(IOrderItem item in items)
            {
                Assert.IsAssignableFrom(type, item);
            }//end looping over each item
        }//end test

        [Theory]
        [InlineData(100, 200)]
        [InlineData(200, 400)]
        [InlineData(500, 900)]
        public void CaloriesFilteredItemsAreInRange(uint min, uint max)
        {
            List<IOrderItem> items = (List<IOrderItem>)Menu.FilterByCalories(Menu.FullMenu(), (int)min, (int)max);
            foreach(IOrderItem item in items)
            {
                Assert.InRange(item.Calories, min, max);
            }//end looping for each item
        }//end test

        [Theory]
        [InlineData(1.20, 2.40)]
        [InlineData(3.60, 4.80)]
        [InlineData(6.20, 9.40)]
        public void PriceFilteredItemsAreInRange(double min, double max)
        {
            foreach(IOrderItem item in Menu.FilterByPrice(Menu.FullMenu(), min, max))
            {
                Assert.InRange(item.Price, min, max);
            }//end looping over each filtered item
        }//end test
    }//end class
}//end namespace