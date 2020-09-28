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