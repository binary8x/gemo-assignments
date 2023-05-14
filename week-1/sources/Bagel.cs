using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gemo.Pricing.Services
{
    public class Bagel: Breakfast
    {
        public BagelToppingType ToppingType { get; private set; }

        private void ChangeToppingType(BagelToppingType toppingType)
        {
            ToppingType = toppingType;
        }

        public void calculatePrice4(BagelToppingType toppingType)
        {
            ChangeToppingType(toppingType);
            Amount = _basePrice;           
        }
    }

    public enum BagelToppingType
    {
        None = 0,
        Butter = 1,
        CreamCheese = 2
    }
}
