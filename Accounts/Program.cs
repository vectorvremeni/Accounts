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

            Account b = new Account { Age = 20, Amount = 5,  id= "Mary"};
            Account c = new Account { Age = 25, Amount = 50, id = "Ann" };
            Account d = new Account { Age = 35, Amount = 55, id = "Kate" };
            Account e = new Account { Age = 50, Amount = 500, id = "Jane" };

            Accounts.Add(a.id, a);
            Accounts.Add(b.id, b);
            Accounts.Add(c.id, c);
            Accounts.Add(d.id, d);
            Accounts.Add(e.id, e);


            //функция которая принимает string и возвращает account
            Func<String, Account> babulya = (String name) => new Account() {Age=99, id=name };

            Account bbb = babulya("dusya");



            Account xxx;
            //лямбда выражение
            List<Account> lst = Accounts.Select(ttt).Where(x =>
            {
                ///замыкание - локальный x замыкается на глобальную область
                xxx = x;
                return x.Age > 25;
                }).ToList();


            Transfer(a, b, 5);

            decimal allmoney = Accounts.GetAccountsSum();

        }

        static Account ttt(KeyValuePair<String, Account> a)
        {
            return a.Value;
        }

        //в виде лямбды
        static int test5() => 5;
        //в виде обычной функции
        static int test6()
        {
            return 6;
        }
        //в виде обычной функции
        static int pow(int x)
        {
            return x * x;
        }

        //в виде лямбды
        static int Lpow(int x) => x* x;

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

    //расширения обязательно должны быть в статическом классе
    public static class DictionaryExtensions
    {
        //обязательно статическая функция
        public static decimal GetAccountsSum(
            /*указать перед типом который расширяем*/
            this 
            /*сам расширяемый тип*/
            Dictionary<String, Account> d)
        {
            decimal sum = d.Sum(x => x.Value.Amount);
            return sum;
        }
    }
}
