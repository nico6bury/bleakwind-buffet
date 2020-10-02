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
        /// </summary>
        Button mostRecentButton;
        
        /// <summary>
        /// whether or not the size change has been read or not,
        /// likely redundant
        /// </summary>
        bool unreadSizeChange;

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
                    //button.Name = $"{names[i]}Button";
                    Content = names[i]
                };
                Grid.SetColumnSpan(button, 1);
                button.Click += new RoutedEventHandler(GotSize);
                sideSelectionGrid.Children.Add(button);

                SizeButtons.Add(button);
            }//end looping over names to add Buttons to SizeButtons
            
            unreadSizeChange = false;
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
        /// Event handler for going ahead to start customizing Vokun Salad
        /// </summary>
        public void AddVokunSalad(object sender, RoutedEventArgs e)
        {
            if (unreadSizeChange)
            {
                ItemSelector.itemSelector.Child = ItemSelector.ic;
                ItemCustomizer.item = new VokunSalad();
                ItemCustomizer.GetBooleanVars<VokunSalad>();
                ItemCustomizerCheckUp();
                ResetButtons();
            }//end if we have the size already
            else
            {
                ResetButtons();
                GetSize(vsButton);
            }//end else we need to get size
        }//end AddVokunSalad event handler

        /// <summary>
        /// Event handler for going ahead to start customizing FriedMiraak
        /// </summary>
        public void AddFriedMiraak(object sender, RoutedEventArgs e)
        {
            if (unreadSizeChange)
            {
                ItemSelector.itemSelector.Child = ItemSelector.ic;
                ItemCustomizer.item = new FriedMiraak();
                ItemCustomizer.GetBooleanVars<FriedMiraak>();
                ItemCustomizerCheckUp();
                ResetButtons();
            }//end if we have the size already
            else
            {
                ResetButtons();
                GetSize(fmButton);
            }//end else we need to get size
        }//end AddFriedMiraak event handler

        /// <summary>
        /// Event handler for going ahead to start customizing Mad Otar Grits
        /// </summary>
        public void AddMadOtarGrits(object sender, RoutedEventArgs e)
        {
            if (unreadSizeChange)
            {
                ItemSelector.itemSelector.Child = ItemSelector.ic;
                ItemCustomizer.item = new MadOtarGrits();
                ItemCustomizer.GetBooleanVars<MadOtarGrits>();
                ItemCustomizerCheckUp();
                ResetButtons();
            }//end if we have the size already
            else
            {
                ResetButtons();
                GetSize(mogButton);
            }//end else we need to get size
        }//end AddMadOtarGrits event handler

        /// <summary>
        /// Event handler for going ahead to start customizing Dragonborn 
        /// Waffle Fries
        /// </summary>
        public void AddDragonbornWaffleFries(object sender, RoutedEventArgs e)
        {
            if (unreadSizeChange)
            {
                ItemSelector.itemSelector.Child = ItemSelector.ic;
                ItemCustomizer.item = new DragonbornWaffleFries();
                ItemCustomizer.GetBooleanVars<DragonbornWaffleFries>();
                ItemCustomizerCheckUp();
                ResetButtons();
            }//end if we have the size already
            else
            {
                ResetButtons();
                GetSize(dwfButton);
            }//end else we need to get size
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
        /// <returns>The Size that the user selected</returns>
        private void GetSize(Button replacement)
        {
            mostRecentButton = replacement;

            int W1a2 = (int)replacement.ActualWidth / 3;
            double W3 = (replacement.ActualWidth) - (2 * (replacement.ActualWidth / 3));
            SizeButtons[0].Width = W1a2;
            SizeButtons[0].MinWidth = W1a2;
            SizeButtons[1].Width = W1a2;
            SizeButtons[1].MinWidth = W1a2;
            SizeButtons[2].Width = W3;
            SizeButtons[2].MinWidth = W3;
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
                Cart.AddItem(item);

                //Switch screens
                ItemSelector.itemSelector.Child = ItemSelector.ics;

                //Reset the buttons after we switch screens
                ResetButtons();
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

            unreadSizeChange = false;
        }//end ResetButtons

        private void ItemCustomizerCheckUp()
        {
            ItemCustomizer.cameFrom = "Side";
            ItemCustomizer.PopulateCheckBoxes();
        }//end ItemCustomizerCheckUp()
    }//end partial class
}//end namespace