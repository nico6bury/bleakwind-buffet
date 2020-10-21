using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Windows;
using RoundRegister;

/*
 * Author: Nicholas Sixbury
 * Class: CashProcessingModelView.cs
 * Purpose: To serve as an intermediary class between CashProcessing.xaml.cs
 * and RoundRegister.CashDrawer. Apparently, RoundRegister is the Model, 
 * this class is the ModelView, and CashProcessing.xaml.cs is the View.
 */

namespace PointOfSale.Payment
{
    /// <summary>
    /// the intermediary class between RoundRegister and CashProcessing
    /// 
    /// This class is supposed to provide properties for the GUI to bind.
    /// These properties will include:
    /// 1. Properties to represent the quantity of each kind of currency
    /// in the drawer
    /// 2. Properties to represent the quantity of each kind of currency
    /// the customer is using to pay
    /// 3. Properties to represent the quantity of each kind of currency that
    /// should be provided to the customer as charge for the transaction.
    /// 
    /// This class also needs to incorporate logic for making appropriate change,
    /// so basically what coins and bills to provide the customer after they pay.
    /// 
    /// This class also needs a method for finalizing the transaction which
    /// invokes the CashDrawer.Open() method, adds the quantity of currency the
    /// customer paid to the CashDrawer's fields, and deducts the quantity given
    /// as change.
    /// </summary>
    public class CashProcessingModelView
    {
        public class CurrencyInfo
        {
            /// <summary>
            /// the amount this item is worth as legal tender
            /// </summary>
            public decimal Value { get; private set; }

            /// <summary>
            /// the number of this type of currency available
            /// </summary>
            public int Number { get; set; }

            /// <summary>
            /// initializes the variables
            /// </summary>
            /// <param name="Value">the amount this item is worth
            /// as legal tender</param>
            /// <param name="Number">the number of this type of 
            /// currency available</param>
            public CurrencyInfo(decimal Value, int Number)
            {
                this.Value = Value;
                this.Number = Number;
            }//end 2-arg constructor
        }//end CurrencyInfo inner class

        /// <summary>
        /// a list of the coins and bills that are in the cash drawer
        /// </summary>
        public List<CurrencyInfo> InDrawer;

        /// <summary>
        /// a list of the coins and bills the customer is paying
        /// </summary>
        public List<CurrencyInfo> FromCust;

        /// <summary>
        /// a list of the coins and bills the customer should be provided
        /// as change
        /// </summary>
        public List<CurrencyInfo> ToCust;

        /// <summary>
        /// all the values for currencies that there are
        /// </summary>
        decimal[] currencyValues = {.01M, 0.05M, .1M, .25M, .5M, 1, 1, 2, 5, 10, 20, 50, 100};

        /// <summary>
        /// the change owed to the customer, as calculated by the last
        /// time the relevant method was called
        /// </summary>
        public decimal changeOwed = 0M;

        public CashProcessingModelView()
        {
            InDrawer = new List<CurrencyInfo>();
            FromCust = new List<CurrencyInfo>();
            ToCust = new List<CurrencyInfo>();

            for (int i = 0; i < currencyValues.Length; i++)
            {
                InDrawer.Add(new CurrencyInfo(currencyValues[i], 0));
                FromCust.Add(new CurrencyInfo(currencyValues[i], 0));
                ToCust.Add(new CurrencyInfo(currencyValues[i], 0));
            }//end setting up all the lists

            UpdateDrawer();
        }//end constructor

        /// <summary>
        /// Sums up the total amount contained in a list of CurrencyInfos
        /// </summary>
        /// <param name="currencies">the list of CurrencyInfos</param>
        /// <returns>returns the total amount of all the currencies</returns>
        public static decimal SumUpCurrencyAmounts(List<CurrencyInfo> currencies)
        {
            decimal total = 0;

            for(int i = 0; i < currencies.Count; i++)
            {
                total += (currencies[i].Number * currencies[i].Value);
            }//end looping for each currency

            return total;
        }//end SumUpCurrencyAmounts(currencies)

        /// <summary>
        /// takes information from FromCust and updates the ToCust
        /// list to tell you what change you should give to the customer
        /// </summary>
        /// <param name="amount">the total amount that the change
        /// needs to add up to</param>
        /// <returns>returns true if the cash drawer has sufficient
        /// funds to give the customer change, and false otherwise</returns>
        public bool UpdateToCust(decimal amount)
        {
            //make a new list to put all the drawer information in
            List<CurrencyInfo> drawer = new List<CurrencyInfo>();
            UpdateDrawer();
            for(int i = 0; i < InDrawer.Count; i++)
            {
                drawer.Add(new CurrencyInfo(InDrawer[i].Value, InDrawer[i].Number));
            }//end looping foreach item in InDrawer

            //reset ToCust so we don't have ridiculous errors
            for(int i = 0; i < ToCust.Count; i++)
            {
                ToCust[i].Number = 0;
            }//end looping to reset ToCust

            //actually do those calculations
            for(int i = currencyValues.Length-1; i >= 0; i--)
            {
                for(int j = 0; drawer[i].Number > 0 && drawer[i].Value <= amount; j++)
                {
                    //take one from the drawer and give it to the customer
                    drawer[i].Number--;
                    ToCust[i].Number++;

                    //update amount now that we have less to gibe
                    amount -= drawer[i].Value;
                }//end looping to add coins to cust for each currency type
            }//end looping over each currency type

            changeOwed = SumUpCurrencyAmounts(ToCust);
            return (amount < 0.01M) && (amount > -0.01M);
        }//end UpdateToCust()
        
        /// <summary>
        /// adds coins in FromCust back into CashDrawer
        /// </summary>
        public void AddToDrawer()
        {
            CashDrawer.OpenDrawer();

            FieldInfo[] allFields = typeof(CashDrawer).GetFields();
            List<FieldInfo> allCurrencies = new List<FieldInfo>();
            for(int i = 0; i < allFields.Length; i++)
            {
                if (allFields[i].Name != "Total") allCurrencies.Add(allFields[i]);
            }//end looping for each field in all fields of CashDrawer

            for(int i = 0; i < FromCust.Count; i++)
            {
                //supposedly null can be used to set the value of static classes
                
                //gets the current number of this i-th currency
                int cur = (int)allCurrencies[i].GetValue(null);
                int soon = cur + FromCust[i].Number;

                //actually sets the property to the value
                allCurrencies[i].SetValue(null, soon);
            }//end looping for each type of currency in CashDrawer
        }//end AddToDrawer

        /// <summary>
        /// Updates the InDrawer List to be consistence with
        /// RoundRegister's cash drawer in terms of coinage quantity
        /// </summary>
        public void UpdateDrawer()
        {
            //gets the fields of CashDrawer
            FieldInfo[] allFields = typeof(CashDrawer).GetFields();
            List<FieldInfo> allCurrencies = new List<FieldInfo>();
            for (int i = 0; i < allFields.Length; i++)
            {
                if (allFields[i].Name != "Total") allCurrencies.Add(allFields[i]);
            }//end looping for each field in all fields of CashDrawer

            //actually updates the InDrawer list
            for(int i = 0; i < allCurrencies.Count; i++)
            {
                InDrawer[i].Number = (int)allCurrencies[i].GetValue(null);
            }//end looping over each currency type
        }//end UpdateDrawer()
    }//end class
}//end namespace