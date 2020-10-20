using BleakwindBuffet.Data;
using BleakwindBuffet.Data.Sides;
using BleakwindBuffet.Data.Entrees;
using BleakwindBuffet.Data.Drinks;
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
 * Class Name: OrderList.xaml.cs
 * Purpose: Holds the information for one particular
 * order, as well as all the items stored within.
 */

namespace PointOfSale.ShopingCart
{
    /// <summary>
    /// Interaction logic for OrderList.xaml
    /// TODO:
    /// Allow the user to customize items after they've been entered
    /// </summary>
    public partial class OrderList : UserControl
    {
        public Order order;

        public OrderList()
        {
            InitializeComponent();
            order = new Order();
            UpdateItems();
        }//end constructor

        /// <summary>
        /// updates the items shown in orderItems to be that
        /// of the items in the items list
        /// </summary>
        public void UpdateItems()
        {
            List<string> updated = new List<string>();
            foreach(IOrderItem item in order)
            {
                updated.Add(order.BuildString(item));
            }//end putting each item from items into updated

            orderItems.Items.Clear();
            foreach(string item in updated)
            {
                orderItems.Items.Add(item);
            }//end adding updated items to orderItems

            UpdateTotal();
        }//end AddItem(item)

        /// <summary>
        /// Update the total to be correct
        /// </summary>
        public void UpdateTotal()
        {
            StringBuilder totalBuilder = new StringBuilder();
            totalBuilder.Append("Subtotal: ");
            totalBuilder.Append(order.Subtotal.ToString("C2"));
            totalBuilder.Append("\nTax: ");
            totalBuilder.Append(order.Tax.ToString("C2"));
            totalBuilder.Append("\nTotal: ");
            totalBuilder.Append(order.Total.ToString("C2"));

            orderTotalTextBlock.Text = totalBuilder.ToString();
        }//end UpdateTotal()

        /// <summary>
        /// Removes the selected item
        /// </summary>
        public void RemoveItem(object sender, RoutedEventArgs e)
        {
            //crashes if user hits button again without selecting other item
            try
            {
                int index = orderItems.SelectedIndex;
                order.RemoveAt(index);
                UpdateItems();
            }//end try
            catch(ArgumentException)
            {
                MessageBox.Show("It seems you have clicked the \"remove selected index" +
                    "\" button without selecting anything. Please actually select " +
                    "something.", "You didn't select anything.", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }//end catch
        }//end RemoveItem event handler

        /// <summary>
        /// Allows the user to edit the selected item
        /// </summary>
        public void EditItem(object sender, RoutedEventArgs e)
        {
            //crashes if user hits button again without selecting other item
            try
            {
                //grab the item
                int index = orderItems.SelectedIndex;
                dynamic item = order[index];

                ItemSelector.ic.GetBooleanVars(item, false, (UserControl)ItemSelector.itemSelector.Child);
                ItemSelector.itemSelector.Child = ItemSelector.ic;

                order.Remove(item);
                UpdateTotal();
                UpdateItems();
            }//end try
            catch (ArgumentException)
            {
                MessageBox.Show("It seems you have clicked the \"remove selected index" +
                    "\" button without selecting anything. Please actually select " +
                    "something.", "You didn't select anything.", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }//end catch
        }//end EditItem event handler
    }//end partial class
}//end namespace