using BleakwindBuffet.Data;
using BleakwindBuffet.Data.Entrees;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
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
 * Class Name: ItemCustomizer.xaml.cs
 * Purpose: This page allows a user to customize boolean properties on a particular
 * item that has them.
 */

namespace PointOfSale.ItemSelection
{
    /// <summary>
    /// Interaction logic for ItemCustomizer.xaml
    /// </summary>

    public partial class ItemCustomizer : UserControl
    {        
        /// <summary>
        /// indicates which page the user was on when they were sent here.
        /// The object that gets sent will probably have been initializaed in
        /// ItemSelector
        /// </summary>
        public UserControl cameFrom;
        /// <summary>
        /// holds all the boolean variables for item
        /// </summary>
        List<PropertyInfo> allBools;

        /// <summary>
        /// the IOrderItem item that gets passed around all over the place.
        /// </summary>
        dynamic item;

        /// <summary>
        /// The list of checkboxes which get dynamically displayed
        /// </summary>
        List<CheckBox> checkBoxes;

        /// <summary>
        /// if true, addItem will return user to the main menu screen, otherwise
        /// the user will be returned to cameFrom
        /// </summary>
        bool returnToMenu;
        
        public ItemCustomizer()
        {
            InitializeComponent();
            checkBoxes = new List<CheckBox>();
        }//end constructor

        /// <summary>
        /// constructor that also calls GetBooleanVars along with setting everything else up
        /// </summary>
        /// <param name="item">the item to customize</param>
        /// <param name="returnToMenu">whether or not you should return to the main
        /// menu after adding the item or not</param>
        /// <param name="cameFrom">the screen that you came from before switching to
        /// this screen</param>
        public ItemCustomizer(dynamic item, bool returnToMenu, UserControl cameFrom)
        {
            InitializeComponent();
            checkBoxes = new List<CheckBox>();
            GetBooleanVars(item, returnToMenu, cameFrom);
        }//end 3-arg constructor

        /// <summary>
        /// Gets everything set up with the specified item.
        /// </summary>
        /// <param name="item">the item to customize</param>
        /// <param name="returnToMenu">whether or not you should return to the main
        /// menu after adding the item or not</param>
        /// <param name="cameFrom">the screen that you came from before switching to
        /// this screen</param>
        public void GetBooleanVars(dynamic item, bool returnToMenu, UserControl cameFrom)
        {
            this.returnToMenu = returnToMenu;
            this.cameFrom = cameFrom;

            PropertyInfo[] allFields = item.GetType().GetProperties();//sender.T.GetProperties();
            this.item = item;//Activator.CreateInstance(sender.T);
            List<PropertyInfo> tempBools = new List<PropertyInfo>();
            for(int i = 0; i < allFields.Length; i++)
            {
                
                if(allFields[i].PropertyType.Name == "Boolean")
                {
                    tempBools.Add(allFields[i]);
                }//end if current Field is of type bool
            }//end looping to get all bools from allFields
            allBools = tempBools;

            PopulateCheckBoxes();
        }//end GetBooleanVars(objs)

        /// <summary>
        /// populates the page with check boxes for all the 
        /// boolean properties
        /// </summary>
        public void PopulateCheckBoxes()
        {
            //we need to clear dockpanel children before we do anything else
            propertyPanel.Children.Clear();

            //we maybe probably I think need to clear this?
            checkBoxes.Clear();

            for(int i = 0; i < allBools.Count; i++)
            {
                checkBoxes.Add(new CheckBox());
                DockPanel.SetDock(checkBoxes[i], Dock.Top);
                bool propertyValue = (bool)allBools[i].GetValue(item);
                checkBoxes[i].IsChecked = propertyValue;
                checkBoxes[i].Content = allBools[i].Name;
                //go ahead and add this guy in
                propertyPanel.Children.Add(checkBoxes[i]);
            }//end setting up all properties and everything for each checkbox
        }//end PopulateCheckBoxes

        /// <summary>
        /// Event hander for back button, take you back to last page
        /// you were at.
        /// </summary>
        private void GoBack(object sender, RoutedEventArgs e)
        {
            ItemSelector.itemSelector.Child = cameFrom;
        }//end GoBack event handler

        /// <summary>
        /// Event handler for the Add item button, adds the item you're
        /// currently on to the orderlist. But before it does that, it
        /// takes information from all the checkboxes and then sets the
        /// properties of item to be equal to what the user set, all in
        /// a super cool way using reflection. 
        /// </summary>
        private void AddItem(object sender, RoutedEventArgs e)
        {
            //update the item with the correct property values
            for(int i = 0; i < allBools.Count; i++)
            {
                allBools[i].SetValue(item, checkBoxes[i].IsChecked);
            }//end setting property of item for each property in allBools

            //actually ship the item over to the correct OrderList
            Cart.AddItem(item);

            //switch screens back to the main window
            ItemSelector.itemSelector.Child = ItemSelector.ics;
        }//end AddItem event handler
    }//end partial class
}//end namespace