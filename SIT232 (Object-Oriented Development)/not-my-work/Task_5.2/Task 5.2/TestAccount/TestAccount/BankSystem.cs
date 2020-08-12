using System;
using System.Diagnostics;

namespace TestAccount
{
    public enum MenuOption
    {
        Withraw = 1,
        Deposit = 2,
        Transfer = 3,
        Print = 4,
        Quit = 5
    };

    class BankSystem
    {
        static void DoDeposit(Account account)
        {
            Console.WriteLine("Please enter the amount you want to deposit : ");
            decimal amount = Convert.ToDecimal(Console.ReadLine());

            DepositTransaction transaction = new DepositTransaction(account, amount);

            transaction.Execute();
            transaction.Print();
        }

        static void DoWithdraw(Account account)
        {
            Console.WriteLine("Please enter the amount you want to withdraw : ");
            decimal amount = Convert.ToDecimal(Console.ReadLine());

            WithdrawTransaction transaction =  new WithdrawTransaction(account, amount);

            transaction.Execute();
            transaction.Print();

        }

        static void DoTransfer(Account fromAccount, Account toAccount)
        {
            Account found1 = fromAccount;
            Account found2 = toAccount;

            if (found1 == null)
            {
                Console.WriteLine("Cancelling transaction...");
            }
            else if (found2 == null)
            {
                Console.WriteLine("Cancelling transaction...");
            }
            else
            {
                Console.WriteLine("Please enter the amount you want to transfer : ");
                decimal amount = Convert.ToDecimal(Console.ReadLine());
                TransferTransaction transaction = new TransferTransaction(found1, found2, amount);

                try
                {
                    transaction.Execute();
                }
                catch (System.InvalidOperationException trans_ex)
                {
                    Console.WriteLine(trans_ex);
                    transaction.Rollback();
                }
                transaction.Print();
            }
        }

        static void DoPrint(Account account)
        {
            Console.WriteLine(account + " account's balance is " + account.getBalance());
        }

        public static int ReadUserOption()
        {
            do
            {
                Console.WriteLine("Bank System Menu : ");
                Console.WriteLine("");
                Console.WriteLine("1. Withdraw");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Transfer");
                Console.WriteLine("4. Print");
                Console.WriteLine("5. Quit");
                Console.WriteLine("Please insert an input : ");

                int input = Convert.ToInt32(Console.ReadLine());

                if (input < 5 && input > 0)
                {
                    return input;
                }

                else

                {
                    Console.WriteLine("Please insert number based of the options !");
                }

            } while (true);

        }


        static void Main(string[] args)
        {
            int input = ReadUserOption();

            Account timAccount = new Account("CommonWealth", 100);
            Account benAccount = new Account("CommonWealth", 200);



            switch (input)
            {
                case (int)MenuOption.Withraw: DoWithdraw(timAccount); break;
                case (int)MenuOption.Deposit: DoDeposit(timAccount); break;
                case (int)MenuOption.Transfer: DoTransfer(timAccount, benAccount); break;
                case (int)MenuOption.Print:  DoPrint(timAccount); break;
                case (int)MenuOption.Quit: Console.WriteLine("Quitting..."); break;
            }

            //timAccount.Deposit(500);
            //timAccount.Withdraw(500);
            //timAccount.print();
        }
    }
}
