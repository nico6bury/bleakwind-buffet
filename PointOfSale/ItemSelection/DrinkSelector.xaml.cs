using BleakwindBuffet.Data.Drinks;
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
 * Class Name: DrinkSelector.xaml.cs
 * Purpose: Allows the user to select a drink
 */

namespace PointOfSale.ItemSelection
{
    /// <summary>
    /// Interaction logic for DrinkSelector.xaml
    /// </summary>
    public partial class DrinkSelector : UserControl
    {
        List<Button> SizeButtons;

        ItemButton mostRecentButton;

        public DrinkSelector()
        {
            InitializeComponent();
            //set up Drink Buttons
            ssButton.T = typeof(SailorSoda);
            mmButton.T = typeof(MarkarthMilk);
            aajButton.T = typeof(AretinoAppleJuice);
            chcButton.T = typeof(CandlehearthCoffee);
            wwButton.T = typeof(WarriorWater);

            //Set up the SizeButtons List
            SizeButtons = new List<Button>();
            List<BleakwindBuffet.Data.Enums.Size> names = new List<BleakwindBuffet.Data.Enums.Size>();
            foreach (BleakwindBuffet.Data.Enums.Size s in Enum.GetValues(typeof(BleakwindBuffet.Data.Enums.Size)))
                names.Add(s);
            
            foreach (BleakwindBuffet.Data.Enums.Size s in names)
            {
                Button button = new Button
                {
                    FontSize = 20,
                    Content = s,
                    Visibility = Visibility.Hidden
                };
                Grid.SetColumnSpan(button, 1);
                button.Click += new RoutedEventHandler(GotSize);
                drinkGrid.Children.Add(button);

                SizeButtons.Add(button);
            }//end adding button to SizeButtons for each Size
        }//end constructor

        /// <summary>
        /// Click event handler that sends the visible page to the
        /// previous menu
        /// </summary>
        public void GoBack(object sender, RoutedEventArgs e)
        {
            ItemSelector.itemSelector.Child = ItemSelector.ics;
            ResetButtons();
        }//end GoBack

        /// <summary>
        /// Event handler for bringing up the size buttons for any
        /// particular drink once the button is pressesd
        /// </summary>
        public void GetSelectedItem(object sender, RoutedEventArgs e)
        {
            if(sender is ItemButton button)
            {
                ResetButtons();
                GetSize(button);
            }//end if sender is button
        }//end GetSelectedItem


        /// <summary>
        /// This helper method allows me to quickly pop up buttons in the
        /// right spot and returns which size the user selected, all in one
        /// neet package.
        /// </summary>
        /// <param name="replacement">the button that these buttons will 
        /// cover up</param>
        public void GetSize(ItemButton replacement)
        {
            mostRecentButton = replacement;
            for(int i = 0; i < SizeButtons.Count; i++)
            {
                SizeButtons[i].Visibility = Visibility.Visible;
                int columnNow = Grid.GetColumn(replacement);
                Grid.SetColumn(SizeButtons[i], columnNow+i);
                Grid.SetRow(SizeButtons[i], Grid.GetRow(replacement));
            }//end setting up properties for each button in SizeButtons
            replacement.Visibility = Visibility.Hidden;
        }//end GetSize(replacement)

        /// <summary>
        /// Event handler for the size buttons
        /// </summary>
        public void GotSize(object sender, RoutedEventArgs e)
        {
            if(sender is Button button)
            {
                //we'll want to do two things here
                //1. Create the IOrderItem object we want to send
                dynamic item;
                switch (mostRecentButton.Content)
                {
                    case "Sailor's Soda":
                        item = new SailorSoda();
                        break;
                    case "Markarth Milk":
                        item = new MarkarthMilk();
                        break;
                    case "Aretino Apple Juice":
                        item = new AretinoAppleJuice();
                        break;
                    case "Candlehearth Coffee":
                        item = new CandlehearthCoffee();
                        break;
                    case "Warrior Water":
                        item = new WarriorWater();
                        break;
                    default:
                        throw new NotImplementedException("That button isn't " +
                            "fully implemented yet. See source of error.");
                }//end switch case to determine type of item
                item.Size = (BleakwindBuffet.Data.Enums.Size)button.Content;

                //2. Send that object to ItemCustomizer and switch screens
                // to show ItemCustomizer
                //send object to ItemCustomizer
                SendToCustomizer(mostRecentButton);

                //Switch Screens
                ItemSelector.itemSelector.Child = ItemSelector.ic;

                //Reset the buttons here, now that we've switched screens
                ResetButtons();
            }//end if the right type sent the event
        }//end GotSize event handler

        /// <summary>
        /// Resets button state after an additional button is clicked
        /// </summary>
        private void ResetButtons()
        {
            ssButton.Visibility = Visibility.Visible;
            mmButton.Visibility = Visibility.Visible;
            aajButton.Visibility = Visibility.Visible;
            chcButton.Visibility = Visibility.Visible;
            wwButton.Visibility = Visibility.Visible;
            foreach(Button button in SizeButtons)
            {
                button.Visibility = Visibility.Hidden;
            }//end setting visibility to hidden for each size button
        }//end ResetButtons()

        private void SendToCustomizer(ItemButton sender)
        {
            ItemSelector.ic.cameFrom = "Drink";
            ItemSelector.ic.GetBooleanVars(sender);
            ItemSelector.ic.PopulateCheckBoxes();
        }//end SendToCustomizer()
    }//end partial class
}//end namespace