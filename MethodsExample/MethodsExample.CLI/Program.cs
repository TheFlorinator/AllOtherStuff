using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodsExample.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = 100;
            BankAccount bankAccount = new BankAccount
            {
                Balance = 200
            };

            //TryChangingTheValue(number);
            //TryChangingTheValueWithTheOutKeyword(out number);
            //TryChangingTheValue(bankAccount);
            //TryChangingTheBalance(bankAccount);
            
            Console.WriteLine("Number value: {0}", number);
            Console.WriteLine("Bank account balance: {0}", bankAccount.Balance);
            Console.ReadKey();
        }

        static void TryChangingTheValue(double number)
        {
            number = 900;
        }

        static void TryChangingTheValueWithTheOutKeyword(out double number)
        {
            number = 600;
        }

        static void TryChangingTheValue(BankAccount bankAccount)
        {
            bankAccount = new BankAccount
            {
                Balance = 800
            };
        }

        static void TryChangingTheBalance(BankAccount bankAccount)
        {
            bankAccount.Balance = 700;
        }
    }
}
