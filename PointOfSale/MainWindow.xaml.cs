using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
 * Class Name: MainWindow.xaml.cs
 * Purpose: Holds all the other components together. Who knows, that
 * might be all it does. 
 */

namespace PointOfSale
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// This is the Cart that is always to the right of the main window.
        /// I shoe-horned it in here because I couldn't figure out a better
        /// way to access it from a child of ItemSelector without a major rework
        /// of the class. One of the requirements for this assignment went a bit
        /// outside my expectations of what I'd need back when I was first 
        /// designing things, so this is my solution.
        /// </summary>
        public static Cart Cart = new Cart();

        public MainWindow()
        {
            InitializeComponent();
            CartBorder.Child = Cart;
        }//end constructor
    }//end partial class
}//end namespace