using System;
using System.Collections.Generic;
using System.Text;

namespace Generics
{
    public class Box<T>
        where T : IComparable
    {
        public Box(T value)
        {
            this.Value = value;
        }
        public T Value { get; set; }


        public override string ToString()
        {
            return $"{this.Value.GetType().FullName}: {Value}";
        }


    }
}
