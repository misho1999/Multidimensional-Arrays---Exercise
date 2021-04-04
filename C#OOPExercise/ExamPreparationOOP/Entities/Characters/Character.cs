using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        // TODO: Implement the rest of the class.
        private string name;
        private double health;
        private double armor;


        public virtual double BaseHealth { get; set; }
        public virtual double BaseArmor { get; set; }
        public double AbilityPoints { get; set; }
        public Bag Bag { get; set; }
        
        public Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            this.Name = name;
            this.Health = health;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
            
        }
        public double Armor
        {
            get
            {
                return this.armor;
            }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                this.armor = value;
            }
        }
        public double Health
        {
            get 
            {
                return this.health;
            }
            set
            {
                if (value >= BaseHealth)
                {
                    value = BaseHealth;
                }
                if (value <= 0)
                {
                    value = 0;
                }
                this.health = value;
            }
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
                    throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
                }
                this.name = value;
            }
        }
        public bool IsAlive { get; set; } = true;

		protected void EnsureAlive()
		{
			if (!this.IsAlive)
			{
				throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
			}
		}
        public void TakeDamage(double hitPoints) 
        {
            if (IsAlive == false)
            {
                return;
            }
            if (this.Armor >= hitPoints)
            {
                this.Armor -= hitPoints;
            }
            if (this.Armor < hitPoints)
            {
                hitPoints -= this.Armor;
                health -= hitPoints;
            }
            if (health <= 0)
            {
                IsAlive = false;
            }

        }
        public void UseItem(Item item)
        {
            if (IsAlive == false)
            {
                return;
            }
            item.AffectCharacter(this);
        }

    }
}