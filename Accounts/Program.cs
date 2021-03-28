using System;
using System.Collections.Generic;
using System.Linq;

namespace Accounts
{
    class Program
    { 
        static Dictionary<String, Account> Accounts = new Dictionary<string, Account>();
        static void Main(string[] args)
        {
            Account a = new Account();
            a.Age = 30;
            a.id = "John";
            a.Amount = 5;

            Account b = new Account {Age=20,Amount=5,id="Mary"};

            Accounts.Add(a.id,a);
            Accounts.Add(b.id, b);


            Transfer(a, b, 5);

            decimal allmoney = Accounts.GetAccountsSum();

        }

        static void Transfer (Account from, Account to, decimal amount ) 
        {
            if (amount > 0 && from.Amount>=amount)
            {
                from.Amount -= amount;
                to.Amount += amount;
            }
        }
    }

    public class Account
    {
        public String id { get; set; }
        private int Age_;
        public int Age 
        { 
            get 
            {
                return Age_; 
            }
            set 
            {
                if (value > 0 && value < 150)
                {
                    Age_ = value;
                }
                else
                {
                    throw new Exception("invalid Age");
                }
            }
        }
        public decimal Amount { get; set; }        
    }

    public static class DictionaryExtensions
    {
        public static decimal GetAccountsSum(this Dictionary<String, Account> d)
        {
            decimal sum = d.Sum(x => x.Value.Amount);
            return sum;
        }
    }
}
