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
using PointOfSale.ItemSelection;

/*
 * Author: Nicholas Sixbury
 * Class Name: ItemCategorySelector.xaml.cs
 * Purpose: Allows the user to select from one of the three
 * main categories of items, Entrees, Drinks, or Sides. It then
 * uses ItemSelector to redirect the user there
 */

namespace PointOfSale.ItemSelection
{
    /// <summary>
    /// Interaction logic for ItemCategorySelector.xaml
    /// </summary>
    public partial class ItemCategorySelector : UserControl
    {
        /// <summary>
        /// whether or not we're currently building a combo
        /// </summary>
        bool ComboCurrent = false;

        public ItemCategorySelector()
        {
            InitializeComponent();
            HideComboButtons();
        }//end constructor

        void SelectDrink(object sender, RoutedEventArgs e)
        {
            ItemSelector.itemSelector.Child = ItemSelector.ds;
            if (!ComboCurrent)
            {
                ItemSelector.ds.IsCombo = false;
            }//end if we don't want a combo
            else
            {

                ItemSelector.ds.IsCombo = true;
                DrinkButton.IsEnabled = false;
            }//end else it is a combo
        }//end SelectDrink event handler

        void SelectEntree(object sender, RoutedEventArgs e)
        {
            ItemSelector.itemSelector.Child = ItemSelector.es;
            if (!ComboCurrent)
            {
                ItemSelector.es.IsCombo = false;
            }//end if we don't want a combo
            else
            {

                ItemSelector.es.IsCombo = true;
                EntreeButton.IsEnabled = false;
            }//end else it is a combo
        }//end SelectDrink event handler

        void SelectSide(object sender, RoutedEventArgs e)
        {
            ItemSelector.itemSelector.Child = ItemSelector.ss;
            if (!ComboCurrent)
            {
                ItemSelector.ss.IsCombo = false;
            }//end if we don't want a combo
            else
            {

                ItemSelector.ss.IsCombo = true;
                SideButton.IsEnabled = false;
            }//end else it is a combo
        }//end SelectDrink event handler

        void SelectCombo(object sender, RoutedEventArgs e)
        {
            if (!ComboCurrent)
            {
                ComboCurrent = true;
                ComboButton.Background = Brushes.ForestGreen;
                ItemSelector.CurCombo = new Combo();
            }//end if we don't want a combo
            else
            {
                ComboCurrent = false;
                SetButtonEnablement(true);
                ComboButton.Background = Brushes.Azure;
                ClearCombo(null, null);
            }//end else we should switch combos off
        }//end SelectCombo event listener (these are actually event listners, aren't they?)

        public void ComboChanged()
        {
            int numNotNull = 0;

            if (ItemSelector.CurCombo.Entree != null)
            {
                numNotNull++;
                TextBlock blocky = new TextBlock
                {
                    Text = ItemSelector.CurCombo.Entree.ToString(),
                    TextWrapping = TextWrapping.Wrap,
                    FontSize = 30
                };
                EntreeButton.Content = blocky;
            }//end if the combo has an entree
            else
            {
                EntreeButton.Content = "Entree";
            }//end else it isn't there

            if (ItemSelector.CurCombo.Side != null)
            {
                numNotNull++;
                TextBlock blocky = new TextBlock
                {
                    Text = ItemSelector.CurCombo.Side.ToString(),
                    TextWrapping = TextWrapping.Wrap,
                    FontSize = 30
                };
                SideButton.Content = blocky;
            }//end if the combo has a side
            else
            {
                SideButton.Content = "Side";
            }//end else it isn't there

            if (ItemSelector.CurCombo.Drink != null)
            {
                numNotNull++;
                TextBlock blocky = new TextBlock
                {
                    Text = ItemSelector.CurCombo.Drink.ToString(),
                    TextWrapping = TextWrapping.Wrap,
                    FontSize = 30
                };
                DrinkButton.Content = blocky;
            }//end if the combo has a drink
            else
            {
                DrinkButton.Content = "Drink";
            }//end else it isn't there

            if (numNotNull > 0)
            {
                ShowComboButtons();
            }//end if we should break out the buttons
            else
            {
                HideComboButtons();
            }//end else we should put the buttons away
        }//end ComboChanged()

        private void HideComboButtons()
        {
            ComboClearButton.Visibility = Visibility.Collapsed;
            ComboFinalizeButton.Visibility = Visibility.Collapsed;
            Grid.SetColumn(ComboButton, 0);
            Grid.SetColumnSpan(ComboButton, 3);
        }//end HideComboButtons

        private void ShowComboButtons()
        {
            ComboClearButton.Visibility = Visibility.Visible;
            ComboFinalizeButton.Visibility = Visibility.Visible;
            Grid.SetColumn(ComboButton, 1);
            Grid.SetColumnSpan(ComboButton, 1);
        }//end ShowComboButtons

        /// <summary>
        /// clears the current combo
        /// </summary>
        private void ClearCombo(object sender, RoutedEventArgs e)
        {
            ItemSelector.CurCombo = new Combo();
            HideComboButtons();
            EntreeButton.Content = "Entree";
            SideButton.Content = "Side";
            DrinkButton.Content = "Drink";
            ComboButton.Background = Brushes.Azure;
            EntreeButton.IsEnabled = true;
            SideButton.IsEnabled = true;
            DrinkButton.IsEnabled = true;
            ComboCurrent = false;
        }//end ClearCombo event listener?

        /// <summary>
        /// adds the current combo to the order
        /// </summary>
        private void FinalizeCombo(object sender, RoutedEventArgs e)
        {
            MainWindow.Cart.AddItem(ItemSelector.CurCombo);
            ClearCombo(null, null);
        }//end FinalizeCombo event listener?

        void SetButtonEnablement(bool enabled)
        {
            SideButton.IsEnabled = enabled;
            DrinkButton.IsEnabled = enabled;
            EntreeButton.IsEnabled = enabled;
        }//end SetButtonEnablement(enabled)
    }//end partial class
}//end namespace