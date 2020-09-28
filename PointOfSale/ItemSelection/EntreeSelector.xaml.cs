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
    /// Interaction logic for EntreeSelector.xaml
    /// </summary>
    public partial class EntreeSelector : UserControl
    {
        public EntreeSelector()
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
    }//end partial class
}//end namespace