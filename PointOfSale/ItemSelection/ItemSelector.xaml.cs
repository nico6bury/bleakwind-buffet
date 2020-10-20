using PointOfSale.Payment;
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
 * Class Name: ItemSelector.xaml.cs
 * Purpose: The purpose of this class is basically to coordinate
 * the change of visible pages on the left side of the main window
 * by placing various objects inside a border. Anything that wants
 * to switch pages or go to another screen on the left side of the
 * MainWindow will probably need to interact with this.
 */

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

        /// <summary>
        /// Allows the user to select a flavor for their soda
        /// </summary>
        public static FlavorSelector fs = new FlavorSelector();

        /// <summary>
        /// Allows the user to select whether or not they want to pay
        /// with cash or card
        /// </summary>
        public static PaymentOptions po = new PaymentOptions();

        /// <summary>
        /// Processes the cash and change that the customer will use to
        /// pay for their food.
        /// </summary>
        public static CashProcessing cp = new CashProcessing();

        /// <summary>
        /// this is the modelview for CashProcessing, and it contains a bunch
        /// of logic and stuff.
        /// </summary>
        public static CashProcessingModelView cpmv = new CashProcessingModelView();

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