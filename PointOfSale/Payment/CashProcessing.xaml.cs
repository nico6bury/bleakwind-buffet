using BleakwindBuffet.Data;
using PointOfSale.ItemSelection;
using RoundRegister;
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
using static PointOfSale.Payment.CashProcessingModelView;

/*
 * Author: Nicholas Sixbury
 * Class: CashProcessing.xaml.cs
 * Purpose: To process change and cash combinations for the customer
 * to pay for their order.
 */

namespace PointOfSale.Payment
{
    /// <summary>
    /// Interaction logic for CashProcessing.xaml
    /// </summary>
    public partial class CashProcessing : UserControl
    {
        /// <summary>
        /// This list holds all the textblocks that show which column is what.
        /// </summary>
        List<TextBlock> CurrencyLabels;

        /// <summary>
        /// These textboxes allow the user to input what the customer has given
        /// them to pay for their meal
        /// </summary>
        List<TextBox> MoneyFromCust;

        /// <summary>
        /// These textblocks show the user what change to give back to the 
        /// customer
        /// </summary>
        List<TextBlock> ChangeToCust;

        /// <summary>
        /// what will be displayed as the total amount still due from the customer
        /// </summary>
        string AmountDue
        {
            get { return amountDue.Text; }
            set { amountDue.Text = value; }
        }//end AmountDue

        /// <summary>
        /// what will be displayed as the total amount of change that should be
        /// given to the customer
        /// </summary>
        string ChangeOwed
        {
            get { return changeOwed.Text; }
            set { changeOwed.Text = value; }
        }//end ChangeOwed

        /// <summary>
        /// the list in the ModelView that represents a list of the coins 
        /// and bills that are in the cash drawer
        /// </summary>
        List<CurrencyInfo> InDrawer
        {
            get
            {
                if (ItemSelector.cpmv != null) return ItemSelector.cpmv.InDrawer;
                else return null;
            }//end getter
            set { if(ItemSelector.cpmv != null) ItemSelector.cpmv.InDrawer = value; }
        }//end InDrawer

        /// <summary>
        /// the list in the ModelView that represents a list of the coins 
        /// and bills the customer is paying
        /// </summary>
        List<CurrencyInfo> FromCust
        {
            get
            {
                if (ItemSelector.cpmv != null) return ItemSelector.cpmv.FromCust;
                else return null;
            }//end getter
            set { if(ItemSelector.cpmv != null) ItemSelector.cpmv.FromCust = value; }
        }//end FromCust

        /// <summary>
        /// the list in the ModelView that represents a list of the coins
        /// and bills the customer should be provided as change
        /// </summary>
        List<CurrencyInfo> ToCust
        {
            get
            {
                if (ItemSelector.cpmv != null) return ItemSelector.cpmv.ToCust;
                else return null;
            }//end getter
            set { if(ItemSelector.cpmv != null) ItemSelector.cpmv.ToCust = value; }
        }//end ToCust

        /// <summary>
        /// the order we're getting change and payment for
        /// </summary>
        public Order order;

        private bool FinishedCalculations = false;

        public CashProcessing()
        {
            InitializeComponent();
            order = new Order();
        }//end constructor

        /// <summary>
        /// This sets up the properties of the class. It needs to run after
        /// the constructor for ItemSelector has run, so that's why it's here
        /// </summary>
        public void SetUpClass(Order order)
        {
            this.order = order;
            AmountDue = order.Total.ToString("C2");

            FieldInfo[] allFields = typeof(CashDrawer).GetFields();
            List<FieldInfo> allCurrencies = new List<FieldInfo>();
            for (int i = 0; i < allFields.Length; i++)
            {
                if (allFields[i].Name != "Total") allCurrencies.Add(allFields[i]);
            }//end looping for each field in all fields of CashDrawer

            CurrencyLabels = new List<TextBlock>();
            MoneyFromCust = new List<TextBox>();
            ChangeToCust = new List<TextBlock>();

            for (int i = 0; i < InDrawer.Count; i++)
            {
                //set up the currency labels
                TextBlock currency = new TextBlock
                {
                    FontSize = 15,
                    TextAlignment = TextAlignment.Center,
                    Text = allCurrencies[i].Name
                };
                Grid.SetRow(currency, i + 1);
                Grid.SetColumn(currency, 0);
                CashGrid.Children.Add(currency);
                CurrencyLabels.Add(currency);

                //set up money from the customer textboxes
                TextBox fromCust = new TextBox
                {
                    FontSize = 15
                };
                Grid.SetRow(fromCust, i + 1);
                Grid.SetColumn(fromCust, 1);
                CashGrid.Children.Add(fromCust);
                fromCust.TextChanged += RecalculateChange;
                MoneyFromCust.Add(fromCust);

                //set up the change for the customer textblocks
                TextBlock toCust = new TextBlock
                {
                    FontSize = 15
                };
                Grid.SetRow(toCust, i + 1);
                Grid.SetColumn(toCust, 2);
                CashGrid.Children.Add(toCust);
                ChangeToCust.Add(toCust);
            }//end looping to set up controls

            FinishedCalculations = false;
        }//end SetUpClass()

        /// <summary>
        /// when the text of the textboxes changed, then stuff gets fed into
        /// the ModelView and the change gets calculated
        /// </summary>
        public void RecalculateChange(object sender, TextChangedEventArgs e)
        {
            for (int i = 0; i < MoneyFromCust.Count; i++)
            {
                try
                {
                    FromCust[i].Number = Convert.ToInt32(MoneyFromCust[i].Text);
                }//end try to convert everything
                catch (FormatException)
                {
                    //we'll just assume it's 0
                    FromCust[i].Number = 0;
                }//end catching the format exceptions
            }//end looping over each of the textboxes
            
            //FromCust should be updated now
            decimal total = SumUpCurrencyAmounts(FromCust);
            total = total - (decimal)order.Total;

            //we should check to make sure there's enough
            if(total < 0)
            {
                string msg = "insufficient ";
                for(int i = 0; i < msg.Length; i++)
                {
                    ChangeToCust[i].Text = msg[i].ToString();
                }//end looping over each char of msg

                ChangeOwed = "$0.00";

                //I don't want to do anything else yet
                return;
            }//end if the customer hasn't paid enough yet

            //if it isn't successful, then just stop
            if (!ItemSelector.cpmv.UpdateToCust(total)) return;

            //hopefully ToCust is updated now, so let's update ChangeOwed
            decimal change = SumUpCurrencyAmounts(ToCust);
            ChangeOwed = change.ToString("C2");

            //it'd be a good idea to update AmountDue as well
            //double due = order.Total - change;
            //AmountDue = due.ToString("C2"); actually maybe not

            //let's also update the right textblocks
            for(int i = 0; i < ChangeToCust.Count; i++)
            {
                ChangeToCust[i].Text = ToCust[i].Number.ToString();
            }//end looping for each currency

            FinishedCalculations = true;
        }//end RecalculateChange event handler

        /// <summary>
        /// goes back to the last screen
        /// </summary>
        public void GoBack(object sender, RoutedEventArgs e)
        {
            //switch screens
            ItemSelector.itemSelector.Child = ItemSelector.po;
        }//end GoBack event handler

        /// <summary>
        /// finalizes the sale
        /// </summary>
        public void FinalizeSale(object sender, RoutedEventArgs e)
        {
            if (FinishedCalculations)
            {
                //go ahead and switch screens
                ItemSelector.itemSelector.Child = ItemSelector.po;

                //call the method in PaymentOptions to print the reciept
                //and generally finish things up
                ItemSelector.po.FinishCashProcessing();
            }//end if we're good to finish up our calculations
            else
            {
                MessageBox.Show("The calculations haven't been finished " +
                    "yet. This probably means the customer hasn't paid " +
                    "for all of their order yet, so go ahead and get that" +
                    " done please...", "Calculations not Finished",
                    MessageBoxButton.OK, MessageBoxImage.Hand);
            }//end else we haven't finished yet
        }//end FinalizeSale event handler

        private void ResetEverything()
        {
            AmountDue = "";
            ChangeOwed = "";
        }//end ResetEverything
    }//end partial class
}//end namespace