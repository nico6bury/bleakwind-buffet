using BleakwindBuffet.Data.Drinks;
using BleakwindBuffet.Data.Entrees;
using BleakwindBuffet.Data.Enums;
using BleakwindBuffet.Data.Sides;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

/*
 * Author: Nicholas Sixbury
 * Class: Menu.cs
 * Purpose: To provide a list of available food items.
 */

namespace BleakwindBuffet.Data
{
    /// <summary>
    /// This class allows one to get information on all the items on
    /// the menu.
    /// </summary>
    public static class Menu
    {
        /// <summary>
        /// Returns a list of all available entrees
        /// </summary>
        /// <returns>List of all available entrees</returns>
        public static IEnumerable<IOrderItem> Entrees()
        {
            List<IOrderItem> entrees = new List<IOrderItem>();
            entrees.Add(new BriarheartBurger());
            entrees.Add(new DoubleDraugr());
            entrees.Add(new GardenOrcOmelette());
            entrees.Add(new PhillyPoacher());
            entrees.Add(new SmokehouseSkeleton());
            entrees.Add(new ThalmorTriple());
            entrees.Add(new ThugsTBone());
            return entrees;
        }//end Entrees()

        /// <summary>
        /// Returns a list of all available sides
        /// </summary>
        /// <returns>List of all available sides</returns>
        public static IEnumerable<IOrderItem> Sides()
        {
            List<IOrderItem> sides = new List<IOrderItem>();

            List<Size> sizes = new List<Size>();
            sizes.Add(Size.Small);
            sizes.Add(Size.Medium);
            sizes.Add(Size.Large);

            for (int i = 0; i < sizes.Count; i++)
            {
                DragonbornWaffleFries dwf = new DragonbornWaffleFries();
                dwf.Size = sizes[i];
                sides.Add(dwf);

                FriedMiraak fm = new FriedMiraak();
                fm.Size = sizes[i];
                sides.Add(fm);

                MadOtarGrits mog = new MadOtarGrits();
                mog.Size = sizes[i];
                sides.Add(mog);

                VokunSalad vs = new VokunSalad();
                vs.Size = sizes[i];
                sides.Add(vs);
            }//end looping for all sizes
            return sides;
        }//end Sides()

        /// <summary>
        /// Returns a list of all available drinks
        /// </summary>
        /// <returns>List of all available drinks</returns>
        public static IEnumerable<IOrderItem> Drinks()
        {
            List<IOrderItem> drinks = new List<IOrderItem>();

            List<Size> sizes = new List<Size>();
            sizes.Add(Size.Small);
            sizes.Add(Size.Medium);
            sizes.Add(Size.Large);

            List<SodaFlavor> flavors = new List<SodaFlavor>();
            flavors.Add(SodaFlavor.Blackberry);
            flavors.Add(SodaFlavor.Cherry);
            flavors.Add(SodaFlavor.Grapefruit);
            flavors.Add(SodaFlavor.Lemon);
            flavors.Add(SodaFlavor.Peach);
            flavors.Add(SodaFlavor.Watermelon);

            for (int i = 0; i < sizes.Count; i++)
            {
                AretinoAppleJuice aaj = new AretinoAppleJuice();
                aaj.Size = sizes[i];
                drinks.Add(aaj);

                CandlehearthCoffee chc1 = new CandlehearthCoffee();
                chc1.Size = sizes[i];
                chc1.Decaf = false;
                drinks.Add(chc1);
                CandlehearthCoffee chc2 = new CandlehearthCoffee();
                chc2.Size = sizes[i];
                chc2.Decaf = true;
                drinks.Add(chc2);

                MarkarthMilk mm = new MarkarthMilk();
                mm.Size = sizes[i];
                drinks.Add(mm);

                for (int j = 0; j < flavors.Count; j++)
                {
                    SailorSoda ss = new SailorSoda();
                    ss.Size = sizes[i];
                    ss.Flavor = flavors[j];
                    drinks.Add(ss);
                }//end looping for all flavors

                WarriorWater ww = new WarriorWater();
                ww.Size = sizes[i];
                drinks.Add(ww);
            }//end looping for all sizes
            return drinks;
        }//end Drinks()

        /// <summary>
        /// Returns a list of all available items
        /// </summary>
        /// <returns>List of all available items</returns>
        public static IEnumerable<IOrderItem> FullMenu()
        {
            List<IOrderItem> entrees = (List<IOrderItem>)Entrees();
            List<IOrderItem> sides = (List<IOrderItem>)Sides();
            List<IOrderItem> drinks = (List<IOrderItem>)Drinks();
            List<IOrderItem> full = new List<IOrderItem>();

            for (int i = 0; i < entrees.Count; i++)
            {
                full.Add(entrees[i]);
            }//end looping to add entrees to full
            for (int i = 0; i < sides.Count; i++)
            {
                full.Add(sides[i]);
            }//end looping to add sides to full
            for (int i = 0; i < drinks.Count; i++)
            {
                full.Add(drinks[i]);
            }//end looping to add drinks to full

            return full;
        }//end FullMenu()

        /// <summary>
        /// Finds all items with a certain string of text present within their ToString().
        /// </summary>
        /// <param name="items">The collection of IOrderItems to search through</param>
        /// <param name="terms">the string you want to search for</param>
        /// <returns>Returns a filtered list as an IEnumerable</returns>
        public static IEnumerable<IOrderItem> Search(IEnumerable<IOrderItem> items, string terms)
        {
            if (terms == null) return items;
            else
            {
                List<IOrderItem> results = new List<IOrderItem>();

                foreach (IOrderItem item in Menu.FullMenu())
                {
                    if (item.ToString().ToLower().Contains(terms.ToLower())) results.Add(item);
                }//end looping foreach item on the menu

                return results;
            }//end else we can go ahead and search
        }//end Search(terms)

        /// <summary>
        /// Finds all the items that have one of a certain list of order types. The valid types
        /// are "Entrees", "Sides", and "Drinks".
        /// </summary>
        /// <param name="items">The collection of IOrderItems to search through</param>
        /// <param name="types">the list of types that you want items to have</param>
        /// <returns>Returns a filtered list as an IEnumerable</returns>
        public static IEnumerable<IOrderItem> FilterByOrderType(IEnumerable<IOrderItem> items, IEnumerable<string> types)
        {
            if (types.Count() == 0) return items;
            else
            {
                List<IOrderItem> results = new List<IOrderItem>();
                foreach (IOrderItem item in items)
                {
                    foreach (string type in types)
                    {
                        switch (type)
                        {
                            case "Entrees":
                                if (item is Entree && !results.Contains(item))
                                    results.Add(item);
                                break;
                            case "Sides":
                                if (item is Side && !results.Contains(item))
                                    results.Add(item);
                                break;
                            case "Drinks":
                                if (item is Drink && !results.Contains(item))
                                    results.Add(item);
                                break;
                            default:
                                // How exceptional:
                                throw new Exception("I'm the exception!");
                        }//end switch case
                    }//end looping foreach type
                }//end looping foreach item

                return results;
            }//end else
        }//end FilterByOrderType

        /// <summary>
        /// Finds all the items in a collection of IOrderItems whose calorie counts are between
        /// a certain specified range
        /// </summary>
        /// <param name="items">the collection of items to filter</param>
        /// <param name="CalMin">the minimum calorie count</param>
        /// <param name="CalMax">the maximum calories count</param>
        /// <returns>Returns a filtered collection of IOrderItems</returns>
        public static IEnumerable<IOrderItem> FilterByCalories(IEnumerable<IOrderItem> items, int CalMin, int CalMax)
        {
            if (CalMin > CalMax) return items;
            else
            {
                List<IOrderItem> results = new List<IOrderItem>();

                foreach (IOrderItem item in Menu.FullMenu())
                {
                    if (item.Calories >= CalMin && item.Calories <= CalMax)
                        results.Add(item);
                }//end testing each item in menu

                return results;
            }//end else we need to filter things
        }//end FilterByCalories(CalMin, CalMax)

        /// <summary>
        /// Finds all the items in a collection of IOrderItems whose Price is between
        /// a certain specified range
        /// </summary>
        /// <param name="items">the collection to filter</param>
        /// <param name="PriceMin">the minimum price</param>
        /// <param name="PriceMax">the maximum price</param>
        /// <returns>Returns a filtered collection</returns>
        public static IEnumerable<IOrderItem> FilterByPrice(IEnumerable<IOrderItem> items, double PriceMin, double PriceMax)
        {
            if (PriceMin > PriceMax) return items;
            else
            {
                List<IOrderItem> results = new List<IOrderItem>();

                foreach (IOrderItem item in Menu.FullMenu())
                {
                    if (item.Price >= PriceMin && item.Price <= PriceMax)
                        results.Add(item);
                }//end testing each item in menu

                return results;
            }//end else we need to filter things
        }//end FilterByPrice
    }//end class
}//end namespace