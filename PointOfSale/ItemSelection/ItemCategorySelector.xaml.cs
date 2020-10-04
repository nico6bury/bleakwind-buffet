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
        public ItemCategorySelector()
        {
            InitializeComponent();
        }//end constructor

        void SelectDrink(object sender, RoutedEventArgs e)
        {

            ItemSelector.itemSelector.Child = ItemSelector.ds;
        }//end SelectDrink event handler

        void SelectEntree(object sender, RoutedEventArgs e)
        {
            ItemSelector.itemSelector.Child = ItemSelector.es;
        }//end SelectDrink event handler

        void SelectSide(object sender, RoutedEventArgs e)
        {
            ItemSelector.itemSelector.Child = ItemSelector.ss;
        }//end SelectDrink event handler
    }//end partial class
}//end namespace