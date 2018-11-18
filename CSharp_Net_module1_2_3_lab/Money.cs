using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Net_module1_2_3_lab
{
    // 1) declare enumeration CurrencyTypes, values UAH, USD, EU
    public enum CurrencyTypes
    {

        // энумка на практике всегда дожна содеражть нулевым элемнтом какой нибудь Unknown или Unspecified или None
        // потому что энумку можно парсить со строки
        // и если не распарсили - 0, т.е. Unknown

        //Unknown
        UAN, USD,EU
    }

   public class Money
    {
        
        // 2) declare 2 properties Amount, CurrencyType
         public decimal Amount { get; set; }
         public CurrencyTypes CurrencyType { get; set; }
        // 3) declare parameter constructor for properties initialization
        public Money(){ }
        public Money(decimal amount, CurrencyTypes type)
        {
            Amount = amount;
            CurrencyType = type;
        }
        // 4) declare overloading of operator + to add 2 objects of Money
        public static Money operator+(Money money1,Money money2)
        {
            return new Money() { Amount = CalculateAmount(money1) + CalculateAmount(money2), CurrencyType = CurrencyTypes.UAN };
        }
        public static Money operator +(Money money, double value)
        {
            return new Money() { Amount = CalculateAmount(money) + (decimal)value, CurrencyType = CurrencyTypes.UAN };
        }
        public static decimal CalculateAmount(Money money)
        {
            if(money.CurrencyType==CurrencyTypes.UAN)
            {
                return money.Amount;
            }
            else if(money.CurrencyType == CurrencyTypes.USD)
            {
                return money.Amount * 28;
            }
            else
            {
                return money.Amount * (decimal)31.35;
            }
        }

        // 5) declare overloading of operator -- to decrease object of Money by 1
        public static Money operator--(Money money)
        {
            money.Amount--;
            return money;
        }
        // 6) declare overloading of operator * to increase object of Money 3 times
        public static Money operator *(Money money, int count)
        {
            money.Amount *= count;
            return money;
        }
        // 7) declare overloading of operator > and < to compare 2 objects of Money
        public static bool operator >(Money money1, Money money2)
        {
            return CalculateAmount(money1) > CalculateAmount(money2);
        }
        public static bool operator <(Money money1, Money money2)
        {
            return CalculateAmount(money1) < CalculateAmount(money2);
        }
        // compare  object of Money and string
        public static bool operator >(Money money, string str)
        {
            return money.CurrencyType.ToString().Length > str.Length;
        }
        public static bool operator <(Money money, string str)
        {
            return money.CurrencyType.ToString().Length < str.Length;
        }
        // 8) declare overloading of operator true and false to check CurrencyType of object
        public static bool operator true(Money money)
        {
            //если мы учтем Uknown - тру если не 0
            return money.CurrencyType == CurrencyTypes.UAN;
        }
        public static bool operator false(Money money)
        {
            return money.CurrencyType != CurrencyTypes.UAN;
        }
        // 9) declare overloading of implicit/ explicit conversion  to convert Money to double, string and vice versa
        public static explicit operator double(Money money)
        {
            return (double)money.Amount;
        }

        public static implicit operator string(Money money)
        {
            //хорошо но я б еще учел валюту
            //return money.Amount.ToString();

            //https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/tokens/interpolated
            //такой формат создания строки  - знак доллара и фигурные скобки - интерполяция
            return $"{money.CurrencyType.ToString()} {money.Amount}";
        }

        //и вайса верса
        public static implicit operator Money(string value)
        {
            //мы это не рассматривали, но в задании оно есть
            // Enum.Parse - механизм приведения строки к енумке: в метод передали тип и строку, на выходе получили object который привели к нужному типу
            //string.Split() - получения массива стрингов по разделителю (пробел, запятая и т.п.)
            //value.Split()[0] вернет нам значение до пробела
            //value.Split()[1] вернет нам значение после пробела
            string strCur = value.Split()[0];
            CurrencyTypes currency = (CurrencyTypes)Enum.Parse(typeof(CurrencyTypes), strCur);
            string strAmount = value.Split()[1];
            decimal amount = decimal.Parse(strAmount);
            return new Money(amount, currency);
        }

    }
}
