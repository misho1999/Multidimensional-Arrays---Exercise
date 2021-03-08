using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
    public interface IPet : IBirthable
    {
        string Name { get; }
    }
}
