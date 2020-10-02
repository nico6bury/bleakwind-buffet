using BleakwindBuffet.Data;
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
            list.orderListCustName.Text = "Customer Name " + (curIndex+1);
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

        public static void AddItem(IOrderItem item)
        {
            lists[curIndex].items.Add(item);
            lists[curIndex].UpdateItems();
        }//end AddItem(item)

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