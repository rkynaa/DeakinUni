using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace TestAccount
{
    public enum MenuOption
    {
        AddNewAccount = 1,
        Withraw = 2,
        Deposit = 3,
        Transfer = 4,
        Print = 5,
        PrintHistoryTransaction = 6,
        Quit = 7
    };

    class BankSystem
    {
        static void DoDeposit(Bank bank)
        {
            Account found = FindAccount(bank);

            if (found == null)
            {
                Console.WriteLine("Cancelling transaction...");
            }
            else
            {
                Console.WriteLine("Please enter the amount you want to deposit : ");
                decimal amount = Convert.ToDecimal(Console.ReadLine());
                DepositTransaction transaction = new DepositTransaction(found, amount);

                bank.ExecuteTransaction(transaction);
                transaction.Print();
            }
        }

        static void DoWithdraw(Bank bank)
        {
            Account found = FindAccount(bank);

            if (found == null)
            {
                Console.WriteLine("Cancelling transaction...");
            }
            else
            {
                Console.WriteLine("Please enter the amount you want to withdraw : ");
                decimal amount = Convert.ToDecimal(Console.ReadLine());
                WithdrawTransaction transaction = new WithdrawTransaction(found, amount);

                bank.ExecuteTransaction(transaction);
                transaction.Print();
            }
        }

        static void DoTransfer(Bank bank)
        {
            Console.WriteLine("From account");
            Account found1 = FindAccount(bank);

            Console.WriteLine("to account");
            Account found2 = FindAccount(bank);

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

                bank.ExecuteTransaction(transaction);
                transaction.Print();
            }
        }

        static void DoPrint(Bank bank)
        {
            Account found = FindAccount(bank);
            if (found == null)
            {
                Console.WriteLine("Cancelling print...");
            }
            else
            {
                Console.WriteLine(found.name + " account's balance is " +
                    found.GetBalance());
            }
        }

        static void AddAccountProcess(Bank bank)
        {
            Console.WriteLine("Please insert the account's name!");
            var accName = Console.ReadLine();

            Console.WriteLine("Please insert the account's starting balance!");
            int strBalance = Convert.ToInt32(Console.ReadLine());

            Account account = new Account(accName, strBalance);

            bank.AddAccount(account);


        }

        static void TransactionHistory(Bank bank)
        {
            
            bank.PrintTransactionHistory();
            DoRollback(bank);
        }

        static void DoRollback(Bank bank)
        {
            Console.WriteLine("Do you want to rollback specific functions?");
            int answer = Convert.ToInt32(Console.ReadLine());
            answer -= 1;

            Transaction final = bank.GetTransaction(answer);
            if (final != null)
            {
                bank.RollbackTransaction(final);
            }
        }

        public static int ReadUserOption()
        {
            do
            {
                Console.WriteLine("Bank System Menu : ");
                Console.WriteLine("");
                Console.WriteLine("1. Add new account");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Deposit");
                Console.WriteLine("4. Transfer");
                Console.WriteLine("5. Print");
                Console.WriteLine("6. Print Transaction History");
                Console.WriteLine("7. Quit");
                Console.WriteLine("Please insert an input : ");

                int input = Convert.ToInt32(Console.ReadLine());

                if (input < 8 && input > 0)
                {
                    return input;
                }

                else

                {
                    Console.WriteLine("Please insert number based of the options !");
                }

            } while (true);

        }

        private static Account FindAccount(Bank bank)
        {
            Console.WriteLine("Please enter an account name :");
            string input = Console.ReadLine();

            if (bank.GetAccount(input) == null)
            {
                Console.WriteLine("Cannot continue! account doesn't exist");
                return null;
            }

            else
            {
                return bank.GetAccount(input);
            }
        }


        static void Main(string[] args)
        {
            List<Account> CommonWealthData = new List<Account>();
            Bank CommonWealth = new Bank(CommonWealthData);
            Account timAccount = new Account("Tim", 100);
            CommonWealth.AddAccount(timAccount);
            int input = 0;
            

            do
            {
                input = ReadUserOption();
                switch (input)
                {
                    case (int)MenuOption.AddNewAccount: AddAccountProcess(CommonWealth); break;
                    case (int)MenuOption.Withraw: DoWithdraw(CommonWealth); break;
                    case (int)MenuOption.Deposit: DoDeposit(CommonWealth); break;
                    case (int)MenuOption.Transfer: DoTransfer(CommonWealth); break;
                    case (int)MenuOption.Print: DoPrint(CommonWealth); break;
                    case (int)MenuOption.PrintHistoryTransaction: TransactionHistory(CommonWealth); break;
                    case (int)MenuOption.Quit: Console.WriteLine("Quitting..."); break;
                }
            } while (input != 7);
            


            //timAccount.Deposit(500);
            //timAccount.Withdraw(500);
            //timAccount.print();
        }
    }
}
