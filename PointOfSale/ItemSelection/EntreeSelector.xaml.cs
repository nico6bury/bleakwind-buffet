using BleakwindBuffet.Data.Entrees;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

/*
 * Author: Nicholas Sixbury
 * Class Name: EntreeSelector.xaml.cs
 * Purpose: Allows the user to select an entree
 */

namespace PointOfSale.ItemSelection
{
    /// <summary>
    /// Interaction logic for EntreeSelector.xaml
    /// </summary>
    public partial class EntreeSelector : UserControl
    {
        public EntreeSelector()
        {
            InitializeComponent();
            bbButton.T = typeof(BriarheartBurger);
            ddButton.T = typeof(DoubleDraugr);
            ttButton.T = typeof(ThalmorTriple);
            ssButton.T = typeof(SmokehouseSkeleton);
            gooButton.T = typeof(GardenOrcOmelette);
            ppButton.T = typeof(PhillyPoacher);
            ttbButton.T = typeof(ThugsTBone);
        }//end constructor

        /// <summary>
        /// Click event handler that sends the visible page to the
        /// previous menu
        /// </summary>
        public void GoBack(object sender, RoutedEventArgs e)
        {
            ItemSelector.itemSelector.Child = ItemSelector.ics;
        }//end GoBack

        /// <summary>
        /// EventHandler for one of the ItemButtons to get its item
        /// added to ItemCustomizer so that it can be customized.
        /// </summary>
        public void GetSelectedItem(object sender, RoutedEventArgs e)
        {
            if(sender is ItemButton button)
            {
                //go ahead and change screens and stuff i guess
                dynamic item;
                switch (button.Content)
                {
                    case "Briarheart Burger":
                        item = new BriarheartBurger();
                        break;
                    case "Double Draugr":
                        item = new DoubleDraugr();
                        break;
                    case "Thalmor Triple":
                        item = new ThalmorTriple();
                        break;
                    case "Smokehouse Skeleton":
                        item = new SmokehouseSkeleton();
                        break;
                    case "Garden Orc Omelette":
                        item = new GardenOrcOmelette();
                        break;
                    case "Philly Poacher":
                        item = new PhillyPoacher();
                        break;
                    case "Thugs T-Bone":
                        item = new ThugsTBone();
                        break;
                    default:
                        throw new NotImplementedException("That button isn't fully " +
                            "implemented yet. See source of error for more detail.");
                }//end switch case to determine item type

                //send item to ItemCustomizer
                SendToCustomizer(item);

                //Switch Screens
                ItemSelector.itemSelector.Child = ItemSelector.ic;
            }//end if sender is right type
        }//end GetSelectedItem event handler

        private void SendToCustomizer(dynamic item)
        {
            ItemSelector.ic.GetBooleanVars(item, false, this);
        }//end SendToCustomizer(item)
    }//end partial class
}//end namespace