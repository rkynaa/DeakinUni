using System;
using System.Collections.Generic;

namespace Prac3._4
{
    enum MenuOption
    {
        Withdraw,
        Deposit,
        Print,
        Sort, 
        Quit
    }
    class BankSystem
    {
        static void Main(string[] args)
        {
            MenuOption test = ReadUserOption();
            Account rakyan = new Account("Rakyan", 0);
            Account jonn = new Account("Jonn", 100);
            Account jonn2 = new Account("Jonn2", 200);
            Account jonn3 = new Account("Jonn3", 300);
            Account[] test_arr = {rakyan, jonn, jonn2, jonn3};
            switch (test)
            {
                case MenuOption.Withdraw:
                    DoWithdrawal(rakyan);
                    break;
                case MenuOption.Deposit:
                    DoDeposit(rakyan);
                    break;
                case MenuOption.Print:
                    DoPrint(rakyan);
                    break;
                case MenuOption.Quit:
                    Console.WriteLine("Thank you for using the system! Please come again!");
                    break;
                case MenuOption.Sort:
                    AccountsSorter.Sort(test_arr, 4);
                    break;
                default:
                    break;
            }
        }
        static MenuOption ReadUserOption()
        {
            int optionInp = 0;
            do
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. " + MenuOption.Withdraw);
                Console.WriteLine("2. " + MenuOption.Deposit);
                Console.WriteLine("3. " + MenuOption.Print);
                Console.WriteLine("4. " + MenuOption.Quit);
                Console.Write("Enter your option: ");
                try
                {
                    optionInp = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException optionError)
                {
                    Console.WriteLine("Error: input must be in number!", optionError);
                }
                if (optionInp < 1 || optionInp > 4)
                {
                    Console.WriteLine("Error: Input must be between 1 and 4!");
                    optionInp = 0;
                    Console.WriteLine(optionInp);
                }
            } while (optionInp == 0);
            optionInp--;
            return (MenuOption) optionInp;
        }
        static void DoDeposit(Account account)
        {
            int amount;
            Console.Write("Enter deposit amount: ");
            amount = Convert.ToInt32(Console.ReadLine());
            bool DepositTest = account.deposit(amount);
            if (DepositTest)
            {
                Console.WriteLine("Deposit succeed!");
            }
            else
            {
                Console.WriteLine("Deposit falied!");
            }
        }
        static void DoWithdrawal(Account account)
        {
            int amount;
            Console.Write("Enter withdrawal amount: ");
            amount = Convert.ToInt32(Console.ReadLine());
            bool WithdrawTest = account.withdraw(amount);
            if (WithdrawTest)
            {
                Console.WriteLine("Withdrawal succeed!");
            }
            else
            {
                Console.WriteLine("Withdrawal falied!");
            }
        }
        static void DoPrint(Account account)
        {
            account.print();
        }
    }
    class Account
    {
        // Instance Variables
        private decimal _balance;
        private String _name;

        public Account(String name, decimal balance)
        {
            this._name = name;
            this._balance = balance;
        }

        // Accessor methods
        public String Name
        {
            get
            {
                return this._name;
            }
        }

        public decimal Balance
        {
            get
            {
                return this._balance;
            }
        }

        public bool deposit(decimal amount)
        {
            if(amount > 0)
            {
                this._balance += amount;
//                Console.WriteLine("Deposit succeed. New balance: " + this._balance.ToString("C"));
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool withdraw(decimal amount)
        {
            if (this._balance - amount > 0)
            {
                this._balance -= amount;
//                Console.WriteLine("Withdraw succeed. New balance: " + this._balance.ToString("C"));
                return true;
            } else 
            {
//                Console.WriteLine("Error: balance not enough for withdrawal!");
                return false;
            }
        }
        public void print()
        {
            Console.WriteLine("Account name: " + this._name + "\nCurrent Balance: " + this._balance.ToString("C"));
        }
    }
    static class AccountsSorter
    {
        public static void Sort(Account[] accounts, int b)
        {
            Account[] buckets = new Account[b];
            decimal M = 0;
            for (int i = 0; i < accounts.Length; i++)
            {
                if (M < accounts[i].Balance)
                {
                    M = accounts[i].Balance;
                }
            }
            for (int i = 0; i < b; i++)
            {
                buckets[(int) Math.Floor((b * accounts[i].Balance)/ M)] = accounts[i];
            }
            for (int i = 0; i < b; i++)
            {
                buckets[i].Sort();
            }
            Console.Write("Sorted! now: ");
            for (int i = 0; i < b; i++)
            {
                if (buckets[i] != null)
                {
                    Console.Write(buckets[i].Name + buckets[i].Balance);
                }
            }
        }
        public static void Sort(List<Account> accounts, int b)
        {
            List<Account> buckets = new List<Account>();
            decimal M = 0;
            
            foreach (Account current in accounts)
            {
                if (M < current.Balance)
                {
                    m = current.Balance;
                }
            }
            foreach (Account current in accounts)
            {
                buckets.Add(Math.Floor((b * current.Balance)/ M)) = current;
            }
            foreach (Account current in buckets)
            {
                current.Sort();
            }
            Console.Write("Sorted! now: ");
            foreach (Account current in buckets)
            {
                if (current != null)
                {
                    Console.Write(current.Name + current.Balance);
                }
            }
        }
    }
}
