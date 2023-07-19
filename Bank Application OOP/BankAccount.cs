using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Application_OOP
{
    internal class BankAccount
    {
        public string Number { get; }
        public string Owner { get; set; }
        public decimal Balance
        {
            get
            {
                decimal balance = 0;
                foreach (var item in allTransactions)
                {
                    balance = balance + item.Amount;
                }
                return balance;

            }

        }


        private static int accountNumberSeed = 1234567890;

        private List<Transaction> allTransactions = new List<Transaction>();


        //My Constructor
        public BankAccount(string owner, decimal initialBalance)
        {
            this.Owner = owner;

            this.Number = accountNumberSeed.ToString();
            accountNumberSeed++;
            MakeDeposit(initialBalance, DateTime.Now, "Initial Balance");
        }

        //Makes deposits into the account
        public void MakeDeposit(decimal amount, DateTime date, string note)
        {

            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }
            var deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);

        }


        //Withdrawal 
        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {

            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }
            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }
            var withdrawal = new Transaction(-amount, date, note);
            allTransactions.Add(withdrawal);

        }

        //Gets Account history
        public string GetAccountHistory()
        {

            var report = new StringBuilder();

            //HEADER
            report.AppendLine("Date\t\tAmount\tNote");
            foreach (var item in allTransactions)
            {

                report.AppendLine($"{item.Date.ToShortDateString()}\tR{item.Amount}\t{item.Notes}");

            }

            return report.ToString();

        }
    }
}