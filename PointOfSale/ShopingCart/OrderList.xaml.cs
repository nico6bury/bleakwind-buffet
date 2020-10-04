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
    /// </summary>
    public partial class OrderList : UserControl
    {
        public List<IOrderItem> items;

        public OrderList()
        {
            InitializeComponent();
            items = new List<IOrderItem>();
            UpdateItems();
        }//end constructor

        /// <summary>
        /// updates the items shown in orderItems to be that
        /// of the items in the items list
        /// </summary>
        public void UpdateItems()
        {
            List<string> updated = new List<string>();
            foreach(IOrderItem item in items)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(item.ToString());
                sb.Append("\t"); // the space between the item name and its calories
                
                //sb.Append(item.Calories);
                //sb.Append("calories");
                //sb.Append(" "); // the space between the item calories and its price
                sb.Append("$");
                sb.Append(item.Price);
                updated.Add(sb.ToString());
            }//end putting each item from items into updated

            orderItems.Items.Clear();
            foreach(string item in updated)
            {
                orderItems.Items.Add(item);
            }//end adding updated items to orderItems

            UpdateTotal();
        }//end AddItem(item)

        public void UpdateTotal()
        {
            decimal total = 0M;
            foreach(IOrderItem item in items)
            {
                total += (decimal)item.Price;
            }//end adding item prices to total

            orderTotalTextBlock.Text = "Order Total: " + total.ToString("C2");
        }//end UpdateTotal()

        public void RemoveItem(object sender, RoutedEventArgs e)
        {
            int index = orderItems.SelectedIndex;
            items.RemoveAt(index);
            UpdateItems();
        }//end RemoveItem event handler
    }//end partial class
}//end namespace