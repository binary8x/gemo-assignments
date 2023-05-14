using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gemo.Pricing.Services
{
    public class Sandwich: Breakfast
    {
        public SandwichAdditionType AdditionType { get; private set; }

        private void ChangeAdditionType(SandwichAdditionType additionType)
        {
            AdditionType = additionType;
        }

        public void calculatePrice4(SandwichAdditionType additionType)
        {
            ChangeAdditionType(additionType);
            Amount = _basePrice;
            if (additionType == SandwichAdditionType.Egg || additionType == SandwichAdditionType.Turkey) Amount += 1;
        }
    }

    public enum SandwichAdditionType
    {
        None = 0,
        Egg = 1,
        Turkey = 2
    }
}
