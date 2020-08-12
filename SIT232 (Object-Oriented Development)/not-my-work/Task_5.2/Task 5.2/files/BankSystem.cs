using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5._2P
{
    public enum MenuOption
    {
        Withdraw,
        Deposit,
        Print,
        Quit
    }

    class BankSystem
    {
        public static MenuOption ReadUserOption()
        {
            int input = 0;
            Console.WriteLine("1: Withdraw");
            Console.WriteLine("2: Deposit");
            Console.WriteLine("3: Print");
            Console.WriteLine("4: Quit");
            do
            {
                Console.WriteLine("Enter your choice: ");
                try
                {
                    input = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Invalid Entry! Please try again.");
                }
            }
            while ((input < 1) && (input > 3));

            return (MenuOption)(input - 1);
        }

        static void Main(string[] args)
        {
            Account Sadia_Acc = new Account("Sadia", 30000);
            
            MenuOption userSelection;

            do
            {
                userSelection = ReadUserOption();
                Console.WriteLine("Option " + ((int)userSelection + 1) + " was entered");
                switch (userSelection)
                {
                    case MenuOption.Withdraw:
                        DoWithdraw(Sadia_Acc);
                        break;
                    case MenuOption.Deposit:
                        DoDeposit(Sadia_Acc);
                        break;
                    case MenuOption.Print:
                        DoPrint(Sadia_Acc);
                        break;
                    case MenuOption.Quit:
                        Console.WriteLine("Quit");
                        break;
                }
            }
            while (userSelection != MenuOption.Quit);
        }

        public static void DoWithdraw(Account account)
        {
            Console.WriteLine("Enter the amount to withdraw: ");
            decimal amount = Convert.ToDecimal(Console.ReadLine());
            WithdrawTransaction withdraw = new WithdrawTransaction(account, amount);
            try
            {
                withdraw.Execute();
            }
            catch (InvalidOperationException)
            {
                withdraw.Print();
                return;
            }
            withdraw.Print();
        }
        public static void DoDeposit(Account account)
        {
            Console.WriteLine("Enter the amount to deposit: ");
            decimal amount = Convert.ToDecimal(Console.ReadLine());
            DepositTransaction deposit = new DepositTransaction(account, amount);
            try
            {
                deposit.Execute();
            }
            catch (InvalidOperationException)
            {
                deposit.Print();
                return;
            }
            deposit.Print();


        }
        public static void DoTransfer(Account fromAccount, Account toAccount)
        {
            Console.WriteLine("Enter the amount to be transferred: ");
            decimal amount = Convert.ToDecimal(Console.ReadLine());
            TransferTransaction transfer = new TransferTransaction(fromAccount, toAccount, amount);
            transfer.Execute();
            transfer.Print();
        }
        public static void DoPrint(Account account)
        {
            account.Print();
        }
    }
}
