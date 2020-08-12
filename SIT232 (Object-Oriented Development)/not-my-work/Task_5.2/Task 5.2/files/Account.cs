using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5._2P
{
    class Account
    {
        private decimal _balance;
        private string _name;

        public String Name
        {
           
            get { return _name; }
            
        }
        public Account(String name, decimal startingBalance)
        {
            this._balance = startingBalance;
            this._name = name;
        }

        public bool Deposit(decimal depositamount)
        {
            if (depositamount > 0)
            {
                this._balance += depositamount;
                return true;
            }
            else
            {
                return false;
            }


        }
        public bool Withdraw(decimal withdrawamount)
        {
            if ((withdrawamount > 0) && (withdrawamount <= this._balance))
            {
                this._balance -= withdrawamount;
                return true;
            }
            else
            {
                return false;
            }

        }
        public void Print()
        {
            Console.WriteLine("Account Name: " + this._name);
            Console.WriteLine("Balance: " + this._balance); ;
        }
    }
}
