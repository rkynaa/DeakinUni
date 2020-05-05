    enum MenuOption
    {
        Withdraw,
        Deposit,
        Transfer,
        Print,
        Quit
    }
    class BankSystem
    {
        static void Main(string[] args)
        {
            Boolean end = false;
            Account rakyan = new Account("Rakyan", 0);
            Account satrya = new Account("Satrya", 0);

            while (!end)
            {
                MenuOption test = ReadUserOption();
                switch (test)
                {
                    case MenuOption.Withdraw:
                        DoWithdrawal(rakyan);
                        break;
                    case MenuOption.Deposit:
                        DoDeposit(rakyan);
                        break;
                    case MenuOption.Transfer:
                        DoTransfer(rakyan, satrya);
                        break;
                    case MenuOption.Print:
                        DoPrint(rakyan);
                        break;
                    case MenuOption.Quit:
                        Console.WriteLine("Thank you for using the system! Please come again!");
                        end = !end;
                        break;
                    default:
                        break;
                }
                Console.WriteLine();
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
                Console.WriteLine("3. " + MenuOption.Transfer);
                Console.WriteLine("4. " + MenuOption.Print);
                Console.WriteLine("5. " + MenuOption.Quit);
                Console.Write("Enter your option: ");
                try
                {
                    optionInp = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException optionError)
                {
                    Console.WriteLine("Error: input must be in number!", optionError);
                }
                if (optionInp < 1 || optionInp > 5)
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

            DepositTransaction DTrans01 = new DepositTransaction(account, amount);

            Console.WriteLine("Execute? (Yes/No)");
            Console.Write(">> ");
            string exe_d = Console.ReadLine().ToLower();

            if (exe_d == "yes")
            {
                try
                {
                    DTrans01.Execute();
                }
                catch (System.InvalidOperationException depo_ex)
                {
                    Console.WriteLine("Transaction has been executed. Rollback initiated.", depo_ex);
                    DTrans01.Rollback();
                }
                Console.WriteLine("\nPrint the transaction? (Yes/No)");
                Console.Write(">> ");
                string print_w = Console.ReadLine().ToLower();
                if (print_w == "yes")
                {
                    DTrans01.print();
                } 
            }

            // bool DepositTest = account.deposit(amount);
            // if (DepositTest)
            // {
            //     Console.WriteLine("Deposit succeed!");
            // }
            // else
            // {
            //     Console.WriteLine("Deposit falied!");
            // }
        }
        static void DoWithdrawal(Account account)
        {
            int amount;
            Console.Write("Enter withdrawal amount: ");
            amount = Convert.ToInt32(Console.ReadLine());

            WithdrawTransaction WTrans01 = new WithdrawTransaction(account, amount);

            Console.WriteLine("Execute? (Yes/No)");
            Console.Write(">> ");
            string exe_w = Console.ReadLine().ToLower();

            if (exe_w == "yes")
            {
                try
                {
                    WTrans01.Execute();
                }
                catch (System.InvalidOperationException with_ex)
                {
                    Console.WriteLine("Transaction has been executed. Rollback initiated.", with_ex);
                    WTrans01.Rollback();
                }
                Console.WriteLine("\nPrint the transaction? (Yes/No)");
                Console.Write(">> ");
                string print_w = Console.ReadLine().ToLower();
                if (print_w == "yes")
                {
                    WTrans01.print();
                } 
            }

            // bool WithdrawTest = account.withdraw(amount);
            // if (WithdrawTest)
            // {
            //     Console.WriteLine("Withdrawal succeed!");
            // }
            // else
            // {
            //     Console.WriteLine("Withdrawal falied!");
            // }
        }

        static void DoTransfer(Account fromAcc, Account toAcc)
        {
            int amount;
            Console.Write("Enter transfer amount: ");
            amount = Convert.ToInt32(Console.ReadLine());

            TransferTransaction TTrans01 = new TransferTransaction(fromAcc, toAcc, amount);

            Console.WriteLine("Execute? (Yes/No)");
            Console.Write(">> ");
            string exe_t = Console.ReadLine().ToLower();

            if (exe_t == "yes")
            {
                try
                {
                    TTrans01.Execute();
                }
                catch (System.InvalidOperationException trans_ex)
                {
                    Console.WriteLine("Transaction has been executed. Rollback initiated.", trans_ex);
                    TTrans01.Rollback();
                }
                Console.WriteLine("\nPrint the transaction? (Yes/No)");
                Console.Write(">> ");
                string print_t = Console.ReadLine().ToLower();
                if (print_t == "yes")
                {
                    TTrans01.print();
                } 
            }

        }
        static void DoPrint(Account account)
        {
            account.print();
        }
    }