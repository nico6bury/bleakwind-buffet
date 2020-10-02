using BleakwindBuffet.Data;
using BleakwindBuffet.Data.Entrees;
using System;
using System.Collections.Generic;
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

namespace PointOfSale.ItemSelection
{
    /// <summary>
    /// Interaction logic for ItemCustomizer.xaml
    /// </summary>

    public partial class ItemCustomizer : UserControl
    {
        /// <summary>
        /// the item which holds all the properties we're sending around
        /// </summary>
        public static IOrderItem item;
        /// <summary>
        /// indicates which page the user was on when they were sent here.
        /// For the current implementation, this should be Side, Drink, or 
        /// Entree
        /// </summary>
        public static string cameFrom;
        /// <summary>
        /// holds all the boolean variables for item
        /// </summary>
        static List<FieldInfo> allBools;
        
        ListBox customizerListBox;

        public ItemCustomizer()
        {
            InitializeComponent();
            customizerListBox = new ListBox();
            customizerListBox.FontSize = 15;
            customDockPanel.Children.Add(customizerListBox);
            DockPanel.SetDock(customizerListBox, Dock.Top);
        }//end constructor

        public static void GetBooleanVars<T>()
        {
            FieldInfo[] allFields = typeof(T).GetFields();
            List<FieldInfo> tempBools = new List<FieldInfo>();
            for(int i = 0; i < allFields.Length; i++)
            {
                if(allFields[i].GetType() == typeof(bool))
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
        /// <param name="bools">the list of boolean FIeldInfo
        /// properties</param>
        public static void PopulateCheckBoxes()
        {
            ListBox customizerListBox = new ListBox();
            customizerListBox.Items.Clear();
            for (int i = 0; i < allBools.Count; i++)
            {
                customizerListBox.Items.Add(allBools[i].Name);
                MessageBox.Show(allBools[i].Name);
            }//end looping over all bools
        }//end PopulateCheckBoxes

        ///make methods to handle the names and values of the bools
    }//end partial class
}//end namespace