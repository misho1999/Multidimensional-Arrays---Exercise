using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Paladin : BaseHero
    {
        public Paladin(string name)
        {
            this.Name = name;
        }
        public override string Name { get; }

        public override int Power => 100;

        public override string CastAbility()
        {
            return $"{GetType().Name} - {this.Name} healed for {this.Power}";
        }
    }
}
