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
    /// Interaction logic for DrinkSelector.xaml
    /// </summary>
    public partial class DrinkSelector : UserControl
    {
        public DrinkSelector()
        {
            InitializeComponent();
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
        /// VokunSalad event handler
        /// </summary>
        public void GetVokunSalad(object sender, RoutedEventArgs e)
        {

        }//end GetVokunSalad event handler

        /// <summary>
        /// FriedMiraak event handler
        /// </summary>
        public void GetFriedMiraak(object sender, RoutedEventArgs e)
        {

        }//end GetFriedMiraak event handler

        /// <summary>
        /// MadOtarGrits event handler
        /// </summary>
        public void GetMadOtarGrits(object sender, RoutedEventArgs e)
        {

        }//end GetMadOtarGrits event handler

        /// <summary>
        /// DragonbornWaffleFries event handler
        /// </summary>
        public void GetDragonbornWaffleFries(object sender, RoutedEventArgs e)
        {

        }//end GetDragonbornWaffleFries event handler
    }//end partial class
}//end namespace