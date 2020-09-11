using BleakwindBuffet.Data.Drinks;
using BleakwindBuffet.Data.Entrees;
using BleakwindBuffet.Data.Enums;
using BleakwindBuffet.Data.Sides;
using System;
using System.Collections.Generic;
using System.Text;

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

            for(int i = 0; i < sizes.Count; i++)
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

                CandlehearthCoffee chc = new CandlehearthCoffee();
                chc.Size = sizes[i];
                drinks.Add(chc);

                MarkarthMilk mm = new MarkarthMilk();
                mm.Size = sizes[i];
                drinks.Add(mm);

                SailorSoda ss = new SailorSoda();
                ss.Size = sizes[i];
                for(int j = 0; j < flavors.Count; j++)
                {
                    ss.Flavor = flavors[i];
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
            
            for(int i = 0; i < entrees.Count; i++)
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
    }//end class
}//end namespace