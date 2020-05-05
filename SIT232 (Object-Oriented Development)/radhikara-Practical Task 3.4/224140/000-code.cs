using System;

namespace task01
{
    enum MenuOption
    {
        Withdraw,
        Deposit,
        Print,
        Quit
    }
    class BankSystem
    {
        static void Main(String[] args)
        {
            // MenuOption test = ReadUserOption();
            // Account rakyan = new Account("Rakyan", 0);
            // switch (test)
            // {
            //     case MenuOption.Withdraw:
            //         DoWithdrawal(rakyan);
            //         break;
            //     case MenuOption.Deposit:
            //         DoDeposit(rakyan);
            //         break;
            //     case MenuOption.Print:
            //         DoPrint(rakyan);
            //         break;
            //     case MenuOption.Quit:
            //         Console.WriteLine("Thank you for using the system! Please come again!");
            //         break;
            //     default:
            //         break;
            // }
            int[] presidents = {1, 2, 3, 4, 5};
            int maxName = presidents.max();
            Console.WriteLine(maxName);
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
                buckets[Math.Floor((b * accounts[i].Balance)/ M)] = accounts[i];
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
                buckets[Math.Floor((b * accounts[i].Balance)/ M)] = accounts[i];
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
