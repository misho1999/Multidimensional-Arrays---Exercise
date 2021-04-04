using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public class Bag : IBag
    {
        private List<Item> CopyItems;
        private int capacity = 100;
        private int load;

        public Bag(int capacity)
        {
            this.Capacity = capacity;
            this.CopyItems = new List<Item>();


        }
        public int Capacity
        {
            get
            {
                return this.capacity;
            }
            set
            {

                this.capacity = value;
            }
        }

        public int Load
        {
            get
            {
                return this.load;
            }
            private set
            {

               value = this.Items.Sum(w => w.Weight);
                this.load = value;
            }
        }


        //public ReadOnlyCollection<Bar> Bars {get { return _bars.AsReadOnly; }}
        public IReadOnlyCollection<Item> Items { get { return CopyItems; } private set { this.Items = value; } }


        public void AddItem(Item item)
        {
            if (this.Load + item.Weight > capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.ExceedMaximumBagCapacity);
            }
            this.Load += item.Weight;
            CopyItems.Add(item);


        }

        public Item GetItem(string name)
        {
            if (CopyItems.Count <= 0)
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            }
            bool item = CopyItems.Any(n => n.GetType().FullName.Contains(name));
            if (!item)
            {
                throw new InvalidOperationException(ExceptionMessages.ItemNotFoundInBag);
            }
            Item removedItem = CopyItems.Find(f => f.GetType().FullName.Contains(name));
            CopyItems.Remove(removedItem);
            this.Load -= removedItem.Weight;
            return removedItem;
        }
    }
}
