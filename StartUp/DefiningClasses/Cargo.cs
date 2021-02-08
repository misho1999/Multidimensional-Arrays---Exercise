using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Cargo
    {
        public string type;
        public   int weight;

        public Cargo(string type, int weight)
        {
            this.type = type;
            this.weight = weight;
        }
    }
}
