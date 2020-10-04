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
        public event PropertyChangedEventHandler PropertyChanged;
        
        /// <summary>
        /// indicates which page the user was on when they were sent here.
        /// For the current implementation, this should be Side, Drink, or 
        /// Entree
        /// </summary>
        public string cameFrom;
        /// <summary>
        /// holds all the boolean variables for item
        /// </summary>
        List<PropertyInfo> allBools;

        dynamic item;

        List<CheckBox> checkBoxes;
        
        public ItemCustomizer()
        {
            InitializeComponent();
            checkBoxes = new List<CheckBox>();
        }//end constructor

        public void GetBooleanVars(ItemButton sender)
        {
            PropertyInfo[] allFields = sender.T.GetProperties();
            item = Activator.CreateInstance(sender.T);
            List<PropertyInfo> tempBools = new List<PropertyInfo>();
            for(int i = 0; i < allFields.Length; i++)
            {
                
                if(allFields[i].PropertyType.Name == "Boolean")
                {
                    tempBools.Add(allFields[i]);
                }//end if current Field is of type bool
            }//end looping to get all bools from allFields
            allBools = tempBools;
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
        public void GoBack(object sender, RoutedEventArgs e)
        {
            switch (cameFrom)
            {
                case "Side":
                    ItemSelector.itemSelector.Child = ItemSelector.ss;
                    break;
                case "Drink":
                    ItemSelector.itemSelector.Child = ItemSelector.ds;
                    break;
                case "Entree":
                    ItemSelector.itemSelector.Child = ItemSelector.es;
                    break;
                default:
                    ItemSelector.itemSelector.Child = ItemSelector.ics;
                    MessageBox.Show("Error: Previous Page is unidentified, returning" +
                        " to main menu.", "Unidentified Source", MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    break;
            }//end leaving to other pages depending on where we came from
        }//end GoBack event handler

        /// <summary>
        /// Event handler for the Add item button, adds the item you're
        /// currently on to the 
        /// </summary>
        public void AddItem(object sender, RoutedEventArgs e)
        {

        }//end AddItem event handler

        public T GetInstance<T>(string type)
        {
            return (T)Activator.CreateInstance(Type.GetType(type));
        }//end GetInstance

        ///make methods to handle the names and values of the bools
    }//end partial class
}//end namespace