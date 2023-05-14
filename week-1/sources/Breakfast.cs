using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gemo.Pricing.Services
{
    public abstract class Breakfast
    {
        internal const double _basePrice = 3;
        public double Amount { get; internal set; }        
    }
}
