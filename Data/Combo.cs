using BleakwindBuffet.Data.Drinks;
using BleakwindBuffet.Data.Entrees;
using BleakwindBuffet.Data.Sides;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Text;

/*
 * Author: Nicholas Sixbury
 * Class Name: Combo.cs
 * Purpose: represents a combination of Drink, Side, and Entree
 */

namespace BleakwindBuffet.Data
{
    /// <summary>
    /// represents a combination of a drink, side, and entree
    /// </summary>
    public class Combo : IOrderItem, INotifyCollectionChanged
    {
        /// <summary>
        /// event called when one of this object's prpperties changes
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// event called when the collection changes
        /// </summary>
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        private Entree entree;
        /// <summary>
        /// The entree for this combo
        /// </summary>
        public Entree Entree
        {
            get
            {
                return entree;
            }//end getter
            set
            {
                if(entree != value)
                {
                    if(entree == null && value != null)
                    {
                        CollectionChanged?.Invoke(this, 
                            new NotifyCollectionChangedEventArgs(
                                NotifyCollectionChangedAction.Add));
                    }//end if we're adding an item
                    else if(entree != null && value == null)
                    {
                        CollectionChanged?.Invoke(this, 
                            new NotifyCollectionChangedEventArgs(
                                NotifyCollectionChangedAction.Remove));
                    }//end if we're removing an item
                    else if(entree != null && value != null)
                    {
                        CollectionChanged?.Invoke(this,
                            new NotifyCollectionChangedEventArgs(
                                NotifyCollectionChangedAction.Replace));
                    }//end if we're replacing an item

                    entree = value;

                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Entree"));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Price"));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Calories"));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SpecialInstructions"));
                }//end if the property actually changed
            }//end setter
        }//end property

        private Side side;
        /// <summary>
        /// the side for this combo
        /// </summary>
        public Side Side
        {
            get
            {
                return side;
            }//end getter
            set
            {
                if(side != value)
                {
                    if (side == null && value != null)
                    {
                        CollectionChanged?.Invoke(this,
                            new NotifyCollectionChangedEventArgs(
                                NotifyCollectionChangedAction.Add));
                    }//end if we're adding an item
                    else if (side != null && value == null)
                    {
                        CollectionChanged?.Invoke(this,
                            new NotifyCollectionChangedEventArgs(
                                NotifyCollectionChangedAction.Remove));
                    }//end if we're removing an item
                    else if (side != null && value != null)
                    {
                        CollectionChanged?.Invoke(this,
                            new NotifyCollectionChangedEventArgs(
                                NotifyCollectionChangedAction.Replace));
                    }//end if we're replacing an item

                    side = value;

                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Side"));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Price"));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Calories"));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SpecialInstructions"));
                }//end if the property actually changed
            }//end setter
        }//end property

        private Drink drink;
        /// <summary>
        /// the drink for this combo
        /// </summary>
        public Drink Drink
        {
            get
            {
                return drink;
            }//end getter
            set
            {
                if(drink != value)
                {
                    if (drink == null && value != null)
                    {
                        CollectionChanged?.Invoke(this,
                            new NotifyCollectionChangedEventArgs(
                                NotifyCollectionChangedAction.Add));
                    }//end if we're adding an item
                    else if (drink != null && value == null)
                    {
                        CollectionChanged?.Invoke(this,
                            new NotifyCollectionChangedEventArgs(
                                NotifyCollectionChangedAction.Remove));
                    }//end if we're removing an item
                    else if (drink != null && value != null)
                    {
                        CollectionChanged?.Invoke(this,
                            new NotifyCollectionChangedEventArgs(
                                NotifyCollectionChangedAction.Replace));
                    }//end if we're replacing an item

                    drink = value;

                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Drink"));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Price"));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Calories"));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SpecialInstructions"));
                }//end if the property actually changed
            }//end setter
        }//end property

        /// <summary>
        /// The total price of this combo, including a $1 discount
        /// </summary>
        public double Price
        {
            get
            {
                double total = 0;
                
                //add item prices to total if they're initialized
                if (Entree != null) total += Entree.Price;
                if (Side != null) total += Side.Price;
                if (Drink != null) total += Drink.Price;
                
                //apply discount as long as it isn't negative
                if (total > 1) total -= 1;
                
                return Math.Round(total, 2);
            }//end getter
        }//end property

        /// <summary>
        /// the total calories of all items in this combo
        /// </summary>
        public uint Calories
        {
            get
            {
                uint cals = 0;

                //add calories to total amount if item initialized
                if (Entree != null) cals += Entree.Calories ;
                if (Side != null) cals += Side.Calories;
                if (Drink != null) cals += Drink.Calories;

                return cals;
            }//end getter
        }//end property

        /// <summary>
        /// the special instructions of all items in this combo, with the item's
        /// name before its instructions
        /// </summary>
        public List<string> SpecialInstructions
        {
            get
            {
                List<string> specialInstructions = new List<string>();

                if(Entree != null)
                {
                    specialInstructions.Add(Entree.ToString());
                    foreach(string instruction in Entree.SpecialInstructions)
                    {
                        specialInstructions.Add(instruction);
                    }//end adding instruction foreach SpecialInstruction in Entree
                }//end if Entree isn't null
                if (Side != null)
                {
                    specialInstructions.Add(Side.ToString());
                    foreach (string instruction in Side.SpecialInstructions)
                    {
                        specialInstructions.Add(instruction);
                    }//end adding instruction foreach SpecialInstruction in Entree
                }//end if Side isn't null
                if (Drink != null)
                {
                    specialInstructions.Add(Drink.ToString());
                    foreach (string instruction in Drink.SpecialInstructions)
                    {
                        specialInstructions.Add(instruction);
                    }//end adding instruction foreach SpecialInstruction in Entree
                }//end if Drink isn't null

                return specialInstructions;
            }//end getter
        }//end property

        /// <summary>
        /// the description of this item
        /// </summary>
        public string Description
        {
            get { return "A combo meal"; }
        }//end Description

        /// <summary>
        /// Initializes the components of the combo as null
        /// </summary>
        public Combo()
        {
            Entree = null;
            Side = null;
            Drink = null;
        }//end no-arg constructor

        /// <summary>
        /// Initializes the components of the combo along with the combo
        /// </summary>
        /// <param name="Entree">This combo's entree</param>
        /// <param name="Side">This combo's side</param>
        /// <param name="Drink">This combo's drink</param>
        public Combo(Entree Entree, Side Side, Drink Drink)
        {
            this.Entree = Entree;
            this.Side = Side;
            this.Drink = Drink;
        }//end 3-arg constructor

        /// <summary>
        /// event handler to trigger events when component properties are changed
        /// </summary>
        void ComboItemChangedListener(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "Size")
            {
                //calories, price, and the item which changed are changed
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Price"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Calories"));
            }//end if the Size changed
            if(e.PropertyName == "SpecialInstructions")
            {
                //specialInstructions is all that changes
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SpecialInstructions"));
            }//end if the SpecialInstructionsChanged
        }//end ComboItemChangedListener event handler

        /// <summary>
        /// adds the event handler for dealing with component property changes
        /// to each item when they are added and removes the event handler when the
        /// item is removed
        /// </summary>
        void ComboChangedListener(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach(IOrderItem item in e.NewItems)
                    {
                        item.PropertyChanged += ComboItemChangedListener;
                    }//end adding event foreach item
                    break;
                case NotifyCollectionChangedAction.Remove:
                    foreach (IOrderItem item in e.OldItems)
                    {
                        item.PropertyChanged -= ComboItemChangedListener;
                    }//end removing event foreach item
                    break;
                case NotifyCollectionChangedAction.Replace:
                    foreach (IOrderItem item in e.OldItems)
                    {
                        item.PropertyChanged -= ComboItemChangedListener;
                    }//end removing event foreach item
                    foreach (IOrderItem item in e.NewItems)
                    {
                        item.PropertyChanged += ComboItemChangedListener;
                    }//end adding event foreach item
                    break;
                default:
                    throw new NotImplementedException("NotufyCollectionChangedAction." +
                        e.Action + " not supported.");
            }//end switch case
        }//end ComboChangedListener event handler
    }//end class
}//end namespace