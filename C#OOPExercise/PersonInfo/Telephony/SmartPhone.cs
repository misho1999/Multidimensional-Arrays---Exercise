using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    public class SmartPhone : Phone,IBrowsable
    {
        public string Browse(string url)
        {
            if (url.Any(x => char.IsDigit(x)))
            {
                throw new InvalidOperationException("Invalid URL!");
            }
            return $"Browsing: {url}!";
        }

        public override string Call(string number)
        {
            Validator.ThrowIfNumbersIsInvalid(number);

            return $"Calling... {number}";
        }
    }
}
