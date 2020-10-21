using BleakwindBuffet.Data.Sides;
using BleakwindBuffet.Data.Enums;
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

/*
 * Author: Nicholas Sixbury
 * Class Name: SideSelector.xaml.cs
 * Purpose: allows the user to select a side, at any size even. Users get here 
 * from the MainWindow
 */

namespace PointOfSale.ItemSelection
{
    /// <summary>
    /// Interaction logic for SideSelector.xaml
    /// </summary>
    public partial class SideSelector : UserControl
    {
        /// <summary>
        /// These are the buttons that appear which allow 
        /// the user to select the size of an item
        /// </summary>
        List<Button> SizeButtons;
        
        /// <summary>
        /// This holds the main button which was most recently pressed
        /// This is a vital variable that I don't know how I'd go without,
        /// event though it's only used like once.
        /// </summary>
        Button mostRecentButton;

        /// <summary>
        /// whether or not we're currently trying to do a combo
        /// </summary>
        public bool IsCombo = false;

        public SideSelector()
        {
            InitializeComponent();
            
            SizeButtons = new List<Button>();
            List<BleakwindBuffet.Data.Enums.Size> names = new List<BleakwindBuffet.Data.Enums.Size>();
            
            foreach (BleakwindBuffet.Data.Enums.Size s in Enum.GetValues(typeof(BleakwindBuffet.Data.Enums.Size)))
                names.Add(s);

            for(int i = 0; i < names.Count; i++)
            {
                Button button = new Button
                {
                    FontSize = 20,
                    Visibility = Visibility.Hidden,
                    Content = names[i]
                };
                Grid.SetColumnSpan(button, 1);
                button.Click += new RoutedEventHandler(GotSize);
                sideSelectionGrid.Children.Add(button);

                SizeButtons.Add(button);
            }//end looping over names to add Buttons to SizeButtons
        }//end constructor
        
        /// <summary>
        /// Click event handler that sends the visible page to the
        /// previous menu
        /// </summary>
        public void GoBack(object sender, RoutedEventArgs e)
        {
            ItemSelector.itemSelector.Child = ItemSelector.ics;
            ResetButtons();
            if (IsCombo)
            {
                ItemSelector.ics.SideButton.IsEnabled = true;
            }//end if we're doing a combo
        }//end GoBack

        /// <summary>
        /// Event handler for going ahead to start customizing Vokun Salad
        /// </summary>
        public void AddVokunSalad(object sender, RoutedEventArgs e)
        {
            ResetButtons();
            GetSize(vsButton);
        }//end AddVokunSalad event handler

        /// <summary>
        /// Event handler for going ahead to start customizing FriedMiraak
        /// </summary>
        public void AddFriedMiraak(object sender, RoutedEventArgs e)
        {
            ResetButtons();
            GetSize(fmButton);
        }//end AddFriedMiraak event handler

        /// <summary>
        /// Event handler for going ahead to start customizing Mad Otar Grits
        /// </summary>
        public void AddMadOtarGrits(object sender, RoutedEventArgs e)
        {
            ResetButtons();
            GetSize(mogButton);
        }//end AddMadOtarGrits event handler

        /// <summary>
        /// Event handler for going ahead to start customizing Dragonborn 
        /// Waffle Fries
        /// </summary>
        public void AddDragonbornWaffleFries(object sender, RoutedEventArgs e)
        {
            ResetButtons();
            GetSize(dwfButton);
        }//end AddDragonbornWaffleFries event handler

        /// <summary>
        /// This helper method allows me to quickly pop up buttons in the
        /// right spot and returns which size the user selected, all in one
        /// neet package.
        /// 
        /// [Note]: As currently implemented, the method is hard coded to only 
        /// make three buttons, so adjustment would need to be made if a new 
        /// size option was made available
        /// </summary>
        /// <param name="replacement">the button that these buttons
        /// will cover up</param>
        private void GetSize(Button replacement)
        {
            mostRecentButton = replacement;
            for (int i = 0; i < 3; i++)
            {
                SizeButtons[i].Visibility = Visibility.Visible;
                int columnNow = Grid.GetColumn(replacement);
                Grid.SetColumn(SizeButtons[i], columnNow+i);
                Grid.SetRow(SizeButtons[i], Grid.GetRow(replacement));
            }//end looping over the three Size buttons
            replacement.Visibility = Visibility.Hidden;
        }//end GetSize(column, row)

        /// <summary>
        /// method called when one of the size buttons is clicked. It gets things
        /// ready for the next size
        /// </summary>
        private void GotSize(object sender, RoutedEventArgs e)
        {
            if(sender is Button button)
            {

                //we'll want to do two things here
                //1. create the IOrderItem object we want to send
                dynamic item;
                switch (mostRecentButton.Content)
                {
                    case "Vokun Salad":
                        item = new VokunSalad();
                        break;
                    case "Fried Miraak":
                        item = new FriedMiraak();
                        break;
                    case "Mad Otar Grits":
                        item = new MadOtarGrits();
                        break;
                    case "Dragonborn Waffle Fries":
                        item = new DragonbornWaffleFries();
                        break;
                    default:
                        throw new NotImplementedException("That button isn't" +
                            " fully implemented yet. See source of error.");
                }//end setting up item object as right class

                item.Size = (BleakwindBuffet.Data.Enums.Size)button.Content;
                //2. send that object to the Cart and Switch screens
                //item sent to Cart
                if (!IsCombo)
                {
                    MainWindow.Cart.AddItem(item);
                }//end if this isn't a combo
                else
                {
                    ItemSelector.ics.ComboChanged();
                }//end else this is a combo

                //Switch screens
                ItemSelector.itemSelector.Child = ItemSelector.ics;

                //Reset the buttons after we switch screens
                ResetButtons();

                //tell ic whether or not we're dealing with a combo
                ItemSelector.ic.IsCombo = IsCombo;

                //handle combo things
                if (IsCombo)
                {
                    ItemSelector.ic.IsCombo = true;
                    ItemSelector.ic.nextComboItem = "Side";
                }//end if this item is part of a combo
                else
                {
                    ItemSelector.ic.IsCombo = false;
                }//end else this item isn't part of a combo
            }//end if the right thing sent the event
        }//end GotSize event handler

        private void ResetButtons()
        {
            vsButton.Visibility = Visibility.Visible;
            fmButton.Visibility = Visibility.Visible;
            mogButton.Visibility = Visibility.Visible;
            dwfButton.Visibility = Visibility.Visible;
            for (int i = 0; i < SizeButtons.Count; i++)
            {
                SizeButtons[i].Visibility = Visibility.Hidden;
            }//setting all size buttons to not be visible
        }//end ResetButtons
    }//end partial class
}//end namespace