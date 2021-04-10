using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;
        private int capacity;
        private int comfort;
        private List<IDecoration> decorations;
        private List<IFish> fish;
        public Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.decorations = new List<IDecoration>();
            this.fish = new List<IFish>();
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }

                this.name = value;
            }
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
            private set
            {
                this.capacity = value;
            }
        }

        public int Comfort
        {
            get
            {
                return this.comfort;
            }
            private set
            {
                this.comfort = this.decorations.Sum(d => d.Comfort);
            }
        }

        public ICollection<IDecoration> Decorations
        {
            get
            {
                return this.decorations;
            }
            private set
            {
                this.Decorations = value;
            }
        }

        public ICollection<IFish> Fish
        {
            get
            {
                return this.fish;
            }
            private set
            {
                this.Fish = value;
            }
        }

        public void AddDecoration(IDecoration decoration)
        {
            this.decorations.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            if (this.Capacity == this.fish.Count)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }
            this.fish.Add(fish);
        }

        public void Feed()
        {
            foreach (var item in this.fish)
            {
                item.Eat();
            }
        }

        public string GetInfo()
        {
            var output = string.Join(", ", fish);
            if (this.fish.Count == 0)
            {
                return $"{this.Name} ({this.GetType().Name}):\r\n" + "none\r\n" + $"Decorations: { this.decorations.Count}\r\n" + $"Comfort: { this.Comfort}\r\n";
                 //Fish: { fishName1}, { fishName2}, { fishName3} (…) / none
            }
            return $"{this.Name} ({this.GetType().Name}):\r\n" + output +$"Decorations: { this.decorations.Count}\r\n" + $"Comfort: { this.Comfort}\r\n";
        }

        public bool RemoveFish(IFish fish)
        {
           bool isRemove = false;
            foreach (var item in this.fish)
            {
                if (item == fish)
                {
                    isRemove = true;
                }
            }
            if (isRemove)
            {
                this.fish.Remove(fish);
            }
            return isRemove;
        }
    }
}
