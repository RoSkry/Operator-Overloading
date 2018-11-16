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
        UAN,USD,EU
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
            return money.Amount.ToString();
        }



    }
}
