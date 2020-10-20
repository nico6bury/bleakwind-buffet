using BleakwindBuffet.Data;
using PointOfSale.ItemSelection;
using RoundRegister;
using System;
using System.Collections.Generic;
using System.IO;
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
 * Class: PaymentOptions.xaml.cs
 * Purpose: To allow the user to choose how they want to pay for
 * their meal
 */

namespace PointOfSale.Payment
{
    /// <summary>
    /// Interaction logic for PaymentOptions.xaml
    /// </summary>
    public partial class PaymentOptions : UserControl
    {
        /// <summary>
        /// the screen the user was at before they got sent here
        /// </summary>
        private UserControl cameFrom;

        /// <summary>
        /// the order that the customer is paying for
        /// </summary>
        private Order order;

        /// <summary>
        /// the first part of the reciept, specifically the following:
        /// the order number,
        /// date and time the order was finished
        /// complete list of all items in order, including price and SP
        /// subtotal for the order
        /// tax for the order
        /// total for the order
        /// 
        /// It does not include the following:
        /// payment method
        /// change owed
        /// </summary>
        private string recieptStart
        {
            get
            {
                //build the first part of the reciept
                StringBuilder sb = new StringBuilder();

                //add the order number to reciept
                sb.Append("Order Number: ");
                sb.Append(order.Number);
                sb.Append("\n");

                //add the current data and time to the order
                sb.Append(DateTime.Now);
                sb.Append("\n");

                //add list of all the items in the order, using BuildString()
                sb.Append("Your Order:\n");
                foreach (IOrderItem item in order)
                {
                    sb.Append(order.BuildString(item));
                    sb.Append("\n");
                }//end building string foreach item

                //add price information
                sb.Append("Subtotal: ");
                sb.Append(order.Subtotal);
                sb.Append("\n");

                sb.Append("Tax: ");
                sb.Append(order.Tax);
                sb.Append("\n");

                sb.Append("Total: ");
                sb.Append(order.Total);
                sb.Append("\n");

                //actually add the string we've built to the right variable
                return sb.ToString();
            }//end getter
        }//end recieptStart

        /// <summary>
        /// default constructor for this object. Doesn't 
        /// set up variables
        /// </summary>
        public PaymentOptions()
        {
            InitializeComponent();
        }//end constructor

        public void PreparePage(UserControl cameFrom, Order order)
        {
            //set a few variables up
            this.cameFrom = cameFrom;
            this.order = order;
        }//end PreparePage()

        /// <summary>
        /// Initiates sequence of events for the customer to pay with
        /// card. This method will likely not change the visible screen.
        /// 
        /// Something to note is that the total variable needs to have 
        /// been set first
        /// </summary>
        private void PayCard(object sender, RoutedEventArgs e)
        {
            var CardReaderResult = CardReader.RunCard(order.Total);
            
            if(CardReaderResult == CardTransactionResult.Approved)
            {
                //start building the string to add
                StringBuilder sb = new StringBuilder();
                
                //recieptStart should have a \n at the end
                sb.Append(recieptStart);

                sb.Append("Payment Method: Card\n");

                sb.Append("Change Owed: $0.00");

                //print receipt
                PrintReciept(sb.ToString());

                //change screens back to the menu
                ItemSelector.itemSelector.Child = ItemSelector.ics;

                //remove the right order
                MainWindow.Cart.RemoveOrder(null, null);
            }//end if we should continue
            else MessageBox.Show($"Card {CardReaderResult}");
        }//end PayCard event handler

        /// <summary>
        /// Initiates sequence of events for the customer to pay with
        /// cash. This method will likely change the visible screen
        /// </summary>
        private void PayCash(object sender, RoutedEventArgs e)
        {
            //set up CashProcessing
            ItemSelector.cp.SetUpClass(order);

            //switch screens
            ItemSelector.itemSelector.Child = ItemSelector.cp;
        }//end PayCash event handler
        
        /// <summary>
        /// called by CashProcessing to finish up the process of...
        /// paying for the order... with cash... yeah, the name of
        /// the method sorta gives it away.
        /// </summary>
        public void FinishCashProcessing()
        {
            decimal change = ItemSelector.cpmv.changeOwed;

            StringBuilder sb = new StringBuilder();

            //recieptStart should have a \n at the end of it
            sb.Append(recieptStart);

            sb.Append("Payment Method: Cash\n");

            sb.Append("Change Owed: ");

            sb.Append(change.ToString("C2"));

            PrintReciept(sb.ToString());

            //change screens back to the main menu
            ItemSelector.itemSelector.Child = ItemSelector.ics;

            //remove the (hopefully) right order
            MainWindow.Cart.RemoveOrder(null, null);
        }//end FinishCashProcessing()

        /// <summary>
        /// Prints out a particulat string to the reciept and cuts the tape
        /// </summary>
        /// <param name="message">the message to be printed on the 
        /// reciept</param>
        private void PrintReciept(string message)
        {
            StringBuilder sb = new StringBuilder();

            int lastNewLine = 0;
            for(int i = 0; i < message.Length; i++)
            {
                if (message[i] != '\n') lastNewLine++;
                else lastNewLine = 0;

                sb.Append(message[i]);
                if(lastNewLine >= 39)
                {
                    sb.Append('\n');
                    lastNewLine = 0;
                }//end if we need to add an extra \n character
            }//end looping for each index of message

            //actually gets that string printed out with all those newlines
            string output = sb.ToString();

            
            //write the reciept to the file
            File.Create("reciept.txt").Dispose();
            /*
            string fullPath = System.IO.Path.GetFullPath("reciept.txt");

            using(StreamWriter sw = File.CreateText(fullPath))
            {
                sw.WriteLine(output);
            }//end use of stream writer=
            */

            sb.Clear();
            for (int i = 0; i < output.Length; i++)
            {
                if(output[i] != '\n')
                {
                    sb.Append(output[i]);
                }//end if we have more to add to this line
                else
                {
                    //for some reason this seems to be printing to my reciept file. Why???
                    RecieptPrinter.PrintLine(sb.ToString());

                    sb.Clear();
                }//end else we want to print the line to the printer
            }//end looping to actually print out everything
            if (sb.Length > 0) RecieptPrinter.PrintLine(sb.ToString());

            //cuts off the end of the reciept so that it can detach
            RecieptPrinter.CutTape();
        }//end PrintReciept(card)

        /// <summary>
        /// Goes back to the previous screen
        /// </summary>
        private void GoBack(object sender, RoutedEventArgs e)
        {
            try
            {
                ItemSelector.itemSelector.Child = cameFrom;
            }//end try
            catch
            {
                ItemSelector.itemSelector.Child = ItemSelector.ics;
            }//end catch
        }//end GoBack event handler
    }//end partial class
}//end namespace