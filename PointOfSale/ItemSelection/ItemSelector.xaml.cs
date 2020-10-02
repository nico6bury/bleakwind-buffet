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

namespace PointOfSale.ItemSelection
{
    /// <summary>
    /// Interaction logic for ItemSelector.xaml
    /// This class holds the border which holds various
    /// item selection pages
    /// </summary>
    public partial class ItemSelector : UserControl
    {
        /// <summary>
        /// This is where different parts of the item selection 
        /// process will be shown, with each page becoming the 
        /// child when that page is shown to the user. Logic for 
        /// that page switching is done through this class
        /// </summary>
        public static Border itemSelector;

        /// <summary>
        /// the ics page that will be shown in the ItemSelector
        /// </summary>
        public static ItemCategorySelector ics = new ItemCategorySelector();

        /// <summary>
        /// Holds the drink selector page that will be shown in 
        /// ItemSelector
        /// </summary>
        public static DrinkSelector ds = new DrinkSelector();

        /// <summary>
        /// Holds the entree selector page that will be shown in 
        /// ItemSelector
        /// </summary>
        public static EntreeSelector es = new EntreeSelector();

        /// <summary>
        /// Holds the side selector page that will be shown in 
        /// ItemSelector
        /// </summary>
        public static SideSelector ss = new SideSelector();

        /// <summary>
        /// Allows the user to customize their selected item
        /// </summary>
        public static ItemCustomizer ic = new ItemCustomizer();

        public ItemSelector()
        {
            InitializeComponent();
            itemSelector = new Border();
            itemSelectionGrid.Children.Add(itemSelector);
            itemSelector.BorderBrush = Brushes.SlateGray;
            itemSelector.BorderThickness = new Thickness(2);
            itemSelector.Child = ics;
        }//end constructor

    }//end partial class
}//end namespace