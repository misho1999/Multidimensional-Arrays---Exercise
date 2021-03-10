using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Druid : BaseHero
    {
        public Druid(string name)
        {
            this.Name = name;

        }
        public override string Name { get; }

        public override int Power => 80;


        public override string CastAbility()
        {
            return $"{GetType().Name} - {this.Name} healed for {this.Power}";
        }
    }
}
