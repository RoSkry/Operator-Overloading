using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Net_module1_2_3_lab
{
    class Program
    {
        static void Main(string[] args)
        {
            // 10) declare 2 objects
            Money money1 = new Money(1000, CurrencyTypes.USD);
            Money money2 = new Money(4500,CurrencyTypes.UAN);

            // 11) do operations
            // add 2 objects of Money
            Console.WriteLine("Add 2 objects of Money");
            Money money3 = money1 + money2;
            Console.WriteLine($"Money {money3.Amount}, Type {money3.CurrencyType}");
            // add 1st object of Money and double
            Console.WriteLine("Add 1st object of Money and double");
            Money money4 = money1 + 1234.5;
            Console.WriteLine($"Money {money4.Amount}, Type {money4.CurrencyType}");
            // decrease 2nd object of Money by 1 
            Console.WriteLine("Decrease 2nd object of Money by 1 ");
            money2--;
            Console.WriteLine($"Money {money2.Amount}, Type {money2.CurrencyType}");
            // increase 1st object of Money
            Console.WriteLine("Increase 1st object of Money");
            money1 *= 3;
            Console.WriteLine($"Money {money1.Amount}, Type {money1.CurrencyType}");
            // compare 2 objects of Money
            Console.WriteLine("Compare 2 objects of Money");
            if (money1>money4)
            {
               Console.WriteLine($"money1 {money1.Amount}, Type {money1.CurrencyType} bigger than money4 {money4.Amount} ,Type {money4.CurrencyType}");
            }
            // compare 2nd object of Money and string
            if(money2>"rt")
            {
                Console.WriteLine("money2 bigger");
            }
            // check CurrencyType of every object
            Console.WriteLine("Check CurrencyType of every object");
            if(money1)
            {
                Console.WriteLine("money1 type is UAN");
            }
            if (money2)
            {
                Console.WriteLine("money2 type is UAN");
            }
            // convert 1st object of Money to string
            Console.WriteLine("Convert 1st object of Money to string");
            string str = money1;
            Console.WriteLine($"After convert {str}");
            Console.WriteLine("Convert 3st object of Money to double");
            double amount = (double)money3;
            Console.WriteLine($"After convert {amount}");
        }
    }
}
