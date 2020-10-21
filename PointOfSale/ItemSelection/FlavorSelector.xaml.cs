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
using BleakwindBuffet.Data;
using BleakwindBuffet.Data.Drinks;
using BleakwindBuffet.Data.Enums;
using PointOfSale.ItemSelection;

namespace PointOfSale
{
    /// <summary>
    /// Interaction logic for FlavorSelector.xaml
    /// </summary>
    public partial class FlavorSelector : UserControl
    {
        /// <summary>
        /// the item we got from DrinkSelector and will send to ItemCustomizer
        /// </summary>
        SailorSoda item;
        
        /// <summary>
        /// The list of all the buttons with flavors on them
        /// </summary>
        List<Button> flavorButtons;

        /// <summary>
        /// whether or not we're currently trying to do a combo
        /// </summary>
        public bool IsCombo = false;

        public FlavorSelector()
        {
            InitializeComponent();
            flavorButtons = new List<Button>();
            
            //generate list of all the soda flavors
            List<SodaFlavor> flavors = new List<SodaFlavor>();
            foreach (SodaFlavor f in Enum.GetValues(typeof(SodaFlavor)))
                flavors.Add(f);

            //generate all the buttons
            for(int i = 0; i < flavors.Count; i++)
            {
                Button button = new Button();
                button.Content = flavors[i];
                if(i % 2 == 0)
                {
                    Grid.SetColumn(button, 0);
                    Grid.SetRow(button, i / 2);
                }//end if i is even number
                else
                {
                    Grid.SetColumn(button, 1);
                    Grid.SetRow(button, i / 2);
                }//end else i is odd

                button.Click += SelectFlavor;
                flavorGrid.Children.Add(button);
            }//end looping for each button we need to generate
        }//end constructor

        /// <summary>
        /// Allows the Drink Selector to send its item to this class in
        /// a controlled manner
        /// </summary>
        /// <param name="soda">the item which have a Flavor property which
        /// this page will get the user to choose</param>
        public void InitializeItem(SailorSoda soda)
        {
            item = soda;
        }//end InitializeItem(soda)

        /// <summary>
        /// This event is meant to be called when one of the flavor buttons
        /// is clicked. It saves the flavor information to the item and sends
        /// the user to the ItemCustomizer
        /// </summary>
        public void SelectFlavor(object sender, RoutedEventArgs e)
        {
            if(sender is Button button)
            {
                //set the flavor of our item to the correct value
                item.Flavor = (SodaFlavor)button.Content;

                //Send the customizer all the information it needs
                SendToCustomizer();

                //switch screens to the item customizer
                ItemSelector.itemSelector.Child = ItemSelector.ic;

                //handle combo things
                if (IsCombo)
                {
                    ItemSelector.ic.IsCombo = true;
                    ItemSelector.ic.nextComboItem = "Drink";
                    }//end if this item is part of a combo
                else
                {
                    ItemSelector.ic.IsCombo = false;
                }//end else this item isn't part of a combo
            }//end if the event was sent by the correct type
        }//end SelectFlavor event handler

        /// <summary>
        /// Preps different variables and methods to be send to the next
        /// page. Only called once, but the method is here for readability
        /// </summary>
        private void SendToCustomizer()
        {
            ItemSelector.ic.GetBooleanVars(item, true, this);
        }//end SendToCustomizer

        /// <summary>
        /// Allows the back button to send the user back to the DrinkSelection
        /// screen in case they don't want sailor soda after all.
        /// </summary>
        public void GoBack(object sender, RoutedEventArgs e)
        {
            ItemSelector.itemSelector.Child = ItemSelector.ds;
        }//end GoBack event handler
    }//end partial class
}//end namespace