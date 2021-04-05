using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Entities.Items
{
    public class FirePotion : Item
    {
        public FirePotion() : base(5)
        {
        }
        public override void AffectCharacter(Character character)
        {
            if (!character.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
            else if (character.Health <= 20)
            {
                character.IsAlive = false;
                character.Health = 0;
                return;
            }
            character.Health -= 20;

        }
    }
}
