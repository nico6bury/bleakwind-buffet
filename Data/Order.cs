using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Text;

/*
 * Author: Nicholas Sixbury
 * Class Name: Order.cs
 * Purpose: It's basically just a list of IOrderItems with a few extra bells and
 * whistles.
 */

namespace BleakwindBuffet.Data
{
    /// <summary>
    /// Represents a collection of IOrderItems
    /// </summary>
    class Order : ICollection<IOrderItem>, INotifyCollectionChanged, INotifyPropertyChanged
    {
        /// <summary>
        /// event that is called when the collection changes
        /// </summary>
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        
        /// <summary>
        /// event that is called when one of this object's properties changes
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// this list holds all the data within the order. I know I might be 
        /// able to optimize it by making it an array and doing a bunch of extra
        /// work, but this is way easier, so this is what I'm going to do.
        /// </summary>
        private List<IOrderItem> data;

        /// <summary>
        /// keeps track of what the next order number will be
        /// </summary>
        private static int nextOrderNumber = 1;

        public int Number;

        /// <summary>
        /// This order is editable
        /// </summary>
        public bool IsReadOnly => false;

        private double salesTaxRate;        
        /// <summary>
        /// the decimal that gets multiplied by the total to give you your tax.
        /// </summary>
        public double SalesTaxRate {
            get
            {
                return salesTaxRate;
            }//end getter
            set
            {
                if(salesTaxRate != value)
                {
                    salesTaxRate = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SalesTaxRate"));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Tax"));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Total"));
                }//end if salesTaxRate changed
            }//end setter
        }//end SalesTaxRate property

        /// <summary>
        /// The tax on all the items in this order
        /// </summary>
        public double Tax
        {
            get
            {
                return Math.Round(SalesTaxRate * Total, 2);
            }//end getter
        }//end property

        /// <summary>
        /// The total of all the items in this order before tax
        /// </summary>
        public double Subtotal
        {
            get
            {
                double totalPrice = 0;
                foreach(IOrderItem item in data)
                {
                    totalPrice += item.Price;
                }//end adding price up foreach item
                return Math.Round(totalPrice, 2);
            }//end getter
        }//end property

        /// <summary>
        /// The true total price of all the items in this order, including tax
        /// </summary>
        public double Total
        {
            get
            {
                return Math.Round(Subtotal + Tax, 2);
            }//end getter
        }//end property

        /// <summary>
        /// Total number of calories of all things in order
        /// </summary>
        public uint Calories
        {
            get
            {
                uint cals = 0;
                foreach(IOrderItem item in data)
                {
                    cals += item.Calories;
                }//end counting calories foreach item in data
                return cals;
            }//end getter
        }//end property

        public int Count { get; private set; } = 0;

        public Order()
        {
            SalesTaxRate = 0.12;
            data = new List<IOrderItem>();
            Number = nextOrderNumber;
            nextOrderNumber++;
        }//end no-arg constructor

        public void Add(IOrderItem item)
        {
            data.Add(item);
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Subtotal"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Tax"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Total"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Calories"));
        }//end Add(item)

        public void Clear()
        {
            data.Clear();
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Subtotal"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Tax"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Total"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Calories"));
        }//end Clear()

        public bool Contains(IOrderItem item)
        {
            return data.Contains(item);
        }//end Contains(item)

        public void CopyTo(IOrderItem[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }//end CopyTo(array, arrayIndex)

        public bool Remove(IOrderItem item)
        {
            bool outcome = data.Remove(item);
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Subtotal"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Tax"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Total"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Calories"));
            return outcome;
        }//end Remove(item)

        /// <summary>
        /// event handler for a collection change
        /// </summary>
        void CollectionChangedListener(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach(IOrderItem item in e.NewItems)
                    {
                        item.PropertyChanged += CollectionItemChangedListener;
                    }//end adding event foreach item
                    break;
                case NotifyCollectionChangedAction.Remove:
                    foreach(IOrderItem item in e.OldItems)
                    {
                        //must remove event because otherwise memory leaks could occur
                        item.PropertyChanged -= CollectionItemChangedListener;
                    }//end removing event foreach item
                    break;
                case NotifyCollectionChangedAction.Reset:
                    //we'll need to remove everything
                    //functionally similar to Remove, but hey, it's a more correct enum val
                    foreach(IOrderItem item in e.OldItems)
                    {
                        item.PropertyChanged -= CollectionItemChangedListener;
                    }//ennd removing event foreach item
                    break;
                case NotifyCollectionChangedAction.Replace:
                    //we don't care
                    break;
                default:
                    throw new NotImplementedException("NotifyCollectionChangedAction." + 
                        e.Action + " not supported.");
            }
        }//end CollectionChangedListener event handler

        /// <summary>
        /// event handler for when the properties of one of the items in 
        /// <paramref name="data"/> is changed in a way that affects this object
        /// </summary>
        void CollectionItemChangedListener(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "Size")
            {
                //call the propertychanged events for the item that changed
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Subtotal"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Tax"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Total"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Calories"));

                //notify that the collection changed
                CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace));
            }//end if property is size
        }//end CollectionItemChangedListener event handler

        public IEnumerator<IOrderItem> GetEnumerator()
        {
            return data.GetEnumerator();
        }//end GetEnumerator

        IEnumerator IEnumerable.GetEnumerator()
        {
            return data.GetEnumerator();
        }//end GetEnumerator
    }//end class
}//end namespace