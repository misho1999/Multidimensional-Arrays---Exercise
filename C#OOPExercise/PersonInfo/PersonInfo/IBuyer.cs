using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
    public interface IBuyer
    {
        int Food { get; }
        void BuyFood();
    }
}
