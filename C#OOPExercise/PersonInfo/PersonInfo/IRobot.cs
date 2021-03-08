using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
   public interface IRobot : IIdentifiable
    {
        string Model { get; }
    }
}
