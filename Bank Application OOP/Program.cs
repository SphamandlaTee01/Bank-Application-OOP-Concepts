using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Application_OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var account = new BankAccount("Spha", 10000);
            Console.WriteLine($"Account {account.Number} was created for {account.Owner} with R{account.Balance}.");
            account.MakeWithdrawal(120, DateTime.Now, "Hammock");
            Console.WriteLine(account.Balance);
            account.MakeWithdrawal(100, DateTime.Now, "Todays's Lunch");
            Console.WriteLine(account.Balance);
            Console.WriteLine(account.GetAccountHistory());




            //Test that the initial Amount must be positive
            /*try
            {
                var invalidAccount = new BankAccount("Invalid", -55);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Exception caught creating acccount with negative balance");
                Console.WriteLine(e.ToString());
            }
            

            //Test For a Negative Balance
            try
            {

               account.MakeWithdrawal(80000, DateTime.Now, "Attempt to overdraw");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Exception caught trying to overdrwa");
                Console.WriteLine(e.ToString());
            }*/






        }
    }
}
