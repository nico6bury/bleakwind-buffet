using BleakwindBuffet.Data;
using PointOfSale.ItemSelection;
using PointOfSale.ShopingCart;
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
 * Class Name: Cart.xaml.cs
 * Purpose: Holds all the OrderLists and allows the user to juggle between
 * several orders instead of just having one, if they so desire
 */

namespace PointOfSale
{
    /// <summary>
    /// Interaction logic for Cart.xaml
    /// Cart.xaml is the Usercontrol that handles all the cart orders
    /// </summary>
    public partial class Cart : UserControl
    {
        /// <summary>
        /// Holds all the orders for different customers
        /// </summary>
        static List<OrderList> lists = new List<OrderList>();

        /// <summary>
        /// Holds which index of lists is currently displayed
        /// </summary>
        static int curIndex = 0;

        public Cart()
        {
            InitializeComponent();
            AddNewOrder(null, null);
            UpdateOrderListNumber();
            EnableOrDisableButtons();
        }//end constructor

        /// <summary>
        /// Adds a new order to the lists object
        /// </summary>
        void AddNewOrder(object sender, RoutedEventArgs e)
        {
            var list = new OrderList();
            curIndex = lists.Count;
            lists.Add(list);
            orderBorder.Child = list;
            list.orderListCustName.Text = "Order " + list.order.Number; //(curIndex+1);
            EnableOrDisableButtons();
            UpdateOrderListNumber();
        }//end AddNewOrder event handler

        /// <summary>
        /// Goes back to the previous order in the list
        /// </summary>
        void PriorOrder(object sender, RoutedEventArgs e)
        {
            if (lists.Count == 0) return;
            curIndex--;
            if (curIndex < 0) curIndex = 0;
            orderBorder.Child = lists[curIndex];
            EnableOrDisableButtons();
            UpdateOrderListNumber();
        }//end AddNewOrder event handler

        /// <summary>
        /// Goes forward to the next order in the list
        /// </summary>
        void NextOrder(object sender, RoutedEventArgs e)
        {
            if (lists.Count == 0) return;
            curIndex++;
            if (curIndex > lists.Count - 1) curIndex = lists.Count - 1;
            orderBorder.Child = lists[curIndex];
            EnableOrDisableButtons();
            UpdateOrderListNumber();
        }//end AddNewOrder event handler

        /// <summary>
        /// Adds an IOrderItem item to the current OrderList
        /// </summary>
        /// <param name="item">The item to be added</param>
        public static void AddItem(IOrderItem item)
        {
            lists[curIndex].order.Add(item);
            lists[curIndex].UpdateItems();
        }//end AddItem(item)
        
        /// <summary>
        /// Removes current order from the list
        /// </summary>
        public void RemoveOrder(object sender, RoutedEventArgs e)
        {
            if(lists.Count <= 1)
            {
                lists[curIndex].order.Clear();
                lists[curIndex].UpdateItems();
                lists[curIndex].UpdateTotal();
            }//end if there's only one order
            else
            {
                lists.RemoveAt(curIndex);
                curIndex--;
                if (curIndex < 0) curIndex = 0;
                if (lists.Count < 1) AddNewOrder(null, null);
                UpdateOrderListNumber();
                EnableOrDisableButtons();
                orderBorder.Child = lists[curIndex];
            }//end else we can go ahead and remove one
        }//end RemoveOrder event handler

        /// <summary>
        /// Checks out the current order and allows the customer to
        /// initiate payment
        /// </summary>
        private void CheckoutOrder(object sender, RoutedEventArgs e)
        {
            //set up the next screen and switch screens
            ItemSelector.po.PreparePage(
                (UserControl)ItemSelector.itemSelector.Child,
                lists[curIndex].order);

            //change screens
            ItemSelector.itemSelector.Child = ItemSelector.po;
        }//end CheckoutOrder

        /// <summary>
        /// Enables or Disables the priorButton and nextButton objects
        /// so that it is clear to the user whether they can go forward
        /// or back.
        /// </summary>
        void EnableOrDisableButtons()
        {
            if (lists.Count <= 1)
            {
                priorButton.IsEnabled = false;
                nextButton.IsEnabled = false;
            }//end if we only have one list
            else if (curIndex == 0)
            {
                priorButton.IsEnabled = false;
                nextButton.IsEnabled = true;
            }//end else if we're at the beginning
            else if (curIndex == lists.Count - 1)
            {
                priorButton.IsEnabled = true;
                nextButton.IsEnabled = false;
            }//end else if we're at the end
            else
            {
                priorButton.IsEnabled = true;
                nextButton.IsEnabled = true;
            }//end else we're in the middle
        }//end EnableOrDisableButtons()

        /// <summary>
        /// Just a helper method to update the displayed number of orders
        /// </summary>
        public void UpdateOrderListNumber()
        {
            
            StringBuilder sb = new StringBuilder();
            sb.Append("Order ");
            sb.Append(curIndex + 1);
            sb.Append("/");
            sb.Append(lists.Count);
            orderNumberTextBlock.Text = sb.ToString();
        }//end UpdateOrderListNumber
    }//end partial class
}//end namespace