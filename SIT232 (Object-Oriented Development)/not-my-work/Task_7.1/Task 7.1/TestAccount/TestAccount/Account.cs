using System;
using System.Collections.Generic;
using System.Text;

namespace TestAccount
{
    class Account
    {
        private decimal _balance;
        private string _name;

        public Account(string name, decimal balance)
        {
            this._name = name;
            this._balance = balance;
        }
        
        public bool Deposit(decimal amount)
        {
            if ( amount < 0 )
            {
                Console.WriteLine("Amount cannot be negative!");
                return false;
            }
            else
            {
                this._balance += amount;
                Console.WriteLine("The deposit was successful!");
                return true;
            }
        }

        public bool Withdraw(decimal amount)
        {
            if ( amount < 0 || this._balance - amount < 0 )
            {
                Console.WriteLine("Amount cannot be more than balance or negative!");
                return false;
            }
            else
            {
                this._balance -= amount;
                Console.WriteLine("The Withdraw was successful!");
                return true;
            }
        }

        public string GetBalance()
        {
            return this._balance.ToString("C");
        }

        public void print()
        {
            Console.WriteLine(_name + " account's balance is " + GetBalance());
        }

        public string name
        {
            get => _name;
            set => _name = value;
        }
    }
}
