using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters
{
    public class Warrior : Character, IAttacker
    {
        private Bag bag;
        public Warrior(string name) : base(name, 100, 50, 400, new Satchel())
        {
            bag = new Satchel();
        }

        public void Attack(Character character)
        {
            double attackPower = this.AbilityPoints;
            
            if (this.IsAlive == false || character.IsAlive == false)
            {
                return;
            }
            if (this == character)
            {
                throw new InvalidOperationException(ExceptionMessages.CharacterAttacksSelf);
            }
            if (character.Armor >= attackPower)
            {
            character.Armor -= attackPower;
            }
            else if (character.Armor < attackPower)
            {
                attackPower -= character.Armor;
                character.Armor = 0;
                if (character.Health <= attackPower)
                {
                    character.IsAlive = false;
                    character.Health = 0;
                }
                character.Health -= attackPower;
            }
        }
    }
}
