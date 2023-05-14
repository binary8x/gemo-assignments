using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gemo.Pricing.Services
{
    public class Order
    {
        public CoffeeCup coffeeCup { get; private set; }
        public Breakfast breakFast { get; private set; }

        /// <summary>
        /// Total amount with tax
        /// </summary>
        public double TotalAmount { get; private set; }
        public double TaxAmount { get; private set; }

        public void calculatePrice5(CoffeeDrinkType drinkType, CoffeeSize size, bool creamTopping, CoffeeMilkOption milkOption, int chocolateSauce, BreakfastDish breakfastDish, SandwichAdditionType additionType, BagelToppingType toppingType)
        {
            coffeeCup = new CoffeeCup();
            coffeeCup.CalculatePrice3(drinkType, size, creamTopping, milkOption, chocolateSauce);

            if (breakfastDish == BreakfastDish.Sandwich )
            {
                var sandWich = new Sandwich();
                sandWich.calculatePrice4(additionType);
                breakFast = sandWich;
            }   
            else if (breakfastDish == BreakfastDish.Bagel)
            {
                var bagel = new Bagel();
                bagel.calculatePrice4(toppingType);
                breakFast = bagel;
            }

            // calculate amount without tax
            double amountWithoutTax = coffeeCup.Amount;
            if (breakFast != null) amountWithoutTax += breakFast.Amount;

            TaxAmount = amountWithoutTax * 7.25 / 100;
            TotalAmount = amountWithoutTax + TaxAmount;
        }
    }

    public enum BreakfastDish
    {
        None = 0,
        Sandwich = 1,
        Bagel = 2
    }
}
