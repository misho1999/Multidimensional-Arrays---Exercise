using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters
{
    public class Priest : Character, IHealer
    {
        public Priest(string name)
            : base(name, 50, 25, 40, new Backpack())
        {
        }

        public override void Attack(Character character)
        {
            throw new ArgumentException(ExceptionMessages.AttackFail);
        }

        public override void Heal(Character character)
        {
            if (this.IsAlive == false || character.IsAlive == false)
            {
                return;
            }
            character.Health += this.AbilityPoints;
        }
    }
}
