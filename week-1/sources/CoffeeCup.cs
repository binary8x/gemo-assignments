using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gemo.Pricing.Services
{
    public class CoffeeCup
    {
        private const double _basePrice = 2;

        /// <summary>
        /// Add follow requirement #2
        /// </summary>
        private const double _milkTeabasePrice = 2.25;

        public CoffeeDrinkType DrinkType { get; private set; }
        public CoffeeSize Size { get; private set; }
        public bool CreamTopping { get; private set; }

        /// <summary>
        /// Add follow requirement #2
        /// </summary>
        public CoffeeMilkOption MilkOption { get; private set; }

        /// <summary>
        /// Add follow requirement #3
        /// </summary>
        public int ChocolateSauce { get; private set; }

        public double Amount { get; private set; } 
      
        private void ChangeDrinkType(CoffeeDrinkType drinkType)
        {
            DrinkType = drinkType;
        }

        private void ChangeSize(CoffeeSize size)
        {
            if (size == CoffeeSize.L && (DrinkType != CoffeeDrinkType.Cold || DrinkType != CoffeeDrinkType.Blended)) throw new Exception($"Size L avaiable only for cold and blended.");
            Size = size;
        }

        private void ChangeCreamTopping(bool topping)
        {
            CreamTopping = topping;
        }

        /// <summary>
        /// Add follow requirement #2
        /// </summary>
        /// <param name="milkOption"></param>
        private void ChangeMilkOption(CoffeeMilkOption milkOption)
        {
            MilkOption = milkOption;
        }

        /// <summary>
        /// Add follow requirement #3
        /// </summary>
        /// <param name="milkOption"></param>
        private void AddChocolateSauce(int chocolateSauce)
        {
            if (chocolateSauce > 6) throw new Exception($"Chocolate sauce exceeds the allowed amount. Maximum is 6");
            ChocolateSauce = chocolateSauce;
        }

        public void CalculatePrice1(CoffeeDrinkType drinkType, CoffeeSize size, bool creamTopping)
        {
            ChangeDrinkType(drinkType);
            ChangeSize(size);
            ChangeCreamTopping(creamTopping);

            Amount = _basePrice;
            if (Size == CoffeeSize.M) Amount += 0.5;
            else if (Size == CoffeeSize.L) Amount += 1;

            if (DrinkType == CoffeeDrinkType.Blended) Amount += 1;

            if (creamTopping) Amount += 0.5;
        }

        public void CalculatePrice2(CoffeeDrinkType drinkType, CoffeeSize size, bool creamTopping, CoffeeMilkOption milkOption)
        {
            ChangeDrinkType(drinkType);
            ChangeSize(size);
            ChangeCreamTopping(creamTopping);
            ChangeMilkOption(milkOption);

            
            if (DrinkType == CoffeeDrinkType.MilkTea) Amount = _milkTeabasePrice;
            else Amount = _basePrice;
            
            if (Size == CoffeeSize.M) Amount += 0.5;
            else if (Size == CoffeeSize.L) Amount += 1;
            else if (Size == CoffeeSize.XL) Amount += 1.5;

            if (DrinkType == CoffeeDrinkType.Blended) Amount += 1;

            if (creamTopping) Amount += 0.5;            
        }

        public void CalculatePrice3(CoffeeDrinkType drinkType, CoffeeSize size, bool creamTopping, CoffeeMilkOption milkOption, int chocolateSauce)
        {
            ChangeDrinkType(drinkType);
            ChangeSize(size);
            ChangeCreamTopping(creamTopping);
            ChangeMilkOption(milkOption);
            AddChocolateSauce(chocolateSauce);

            if (DrinkType == CoffeeDrinkType.MilkTea) Amount = _milkTeabasePrice;
            else Amount = _basePrice;

            if (Size == CoffeeSize.M) Amount += 0.5;
            else if (Size == CoffeeSize.L) Amount += 1;
            else if (Size == CoffeeSize.XL) Amount += 1.5;

            if (DrinkType == CoffeeDrinkType.Blended) Amount += 1;

            if (creamTopping) Amount += 0.5;

            if (ChocolateSauce > 2) Amount += ((ChocolateSauce - 2) * 0.5);
        }

    }

    public enum CoffeeDrinkType
    {
        Hot = 0,
        Cold = 1,
        Blended = 2,
        /// <summary>
        /// Add follow requirement #2
        /// </summary>
        MilkTea = 3
    }

    public enum CoffeeSize
    {
        S = 0,
        M = 1,
        L = 2,
        /// <summary>
        /// Add follow requirement #2
        /// </summary>
        XL =3
    }

    /// <summary>
    /// Add follow requirement #3
    /// </summary>
    public enum CoffeeMilkOption
    {
        None = 0,
        WholeMilk = 1,
        AlmondMilk = 2
    }
}
