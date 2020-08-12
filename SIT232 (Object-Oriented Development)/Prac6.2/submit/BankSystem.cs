    enum MenuOption
    {
        AddAcc,
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
            Bank newBank = new Bank();

            while (!end)
            {
                Console.Clear();
                MenuOption test = ReadUserOption();
                switch (test)
                {
                    case MenuOption.AddAcc:
                        // Variables for account name and its starting balance
                        String nameAcc;
                        decimal balanceAcc;

                        Console.Write("Enter account name: ");
                        nameAcc = Console.ReadLine();

                        Console.Write("Enter its starting balance: ");
                        balanceAcc = Convert.ToDecimal(Console.ReadLine());

                        newBank.AddAccount(new Account(nameAcc, balanceAcc));
                        break;
                    case MenuOption.Withdraw:
                        DoWithdrawal(newBank);
                        break;
                    case MenuOption.Deposit:
                        DoDeposit(newBank);
                        break;
                    case MenuOption.Transfer:
                        DoTransfer(newBank);
                        break;
                    case MenuOption.Print:
                        DoPrint(newBank);
                        break;
                    case MenuOption.Quit:
                        Console.WriteLine("Thank you for using the system! Please come again!");
                        end = !end;
                        break;
                    default:
                        break;
                }
                Console.WriteLine();
                Thread.Sleep(3000);
            }
        }
        static MenuOption ReadUserOption()
        {
            int optionInp = 0;
            do
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Add an account");
                Console.WriteLine("2. " + MenuOption.Withdraw);
                Console.WriteLine("3. " + MenuOption.Deposit);
                Console.WriteLine("4. " + MenuOption.Transfer);
                Console.WriteLine("5. " + MenuOption.Print);
                Console.WriteLine("6. " + MenuOption.Quit);
                Console.Write("Enter your option: ");
                try
                {
                    optionInp = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException optionError)
                {
                    Console.WriteLine("Error: input must be in number!", optionError);
                }
                if (optionInp < 1 || optionInp > 6)
                {
                    Console.WriteLine("Error: Input must be between 1 and 4!");
                    optionInp = 0;
                    Console.WriteLine(optionInp);
                }
            } while (optionInp == 0);
            optionInp--;
            return (MenuOption) optionInp;
        }
        static void DoDeposit(Bank bank)
        {
            decimal amount;
            Account account = FindAccount(bank);

            if (account == null)
            {
                Console.WriteLine("\nTransaction aborted! Account can not be found!");
                Console.WriteLine("Suggestion: Add new account with desired name!");
                return;
            }

            Console.Write("Enter deposit amount: ");
            amount = Convert.ToDecimal(Console.ReadLine());

            DepositTransaction DTrans01 = new DepositTransaction(account, amount);

            Console.WriteLine("Execute? (Yes/No)");
            Console.Write(">> ");
            string exe_d = Console.ReadLine().ToLower();

            if (exe_d == "yes")
            {
                bank.ExecuteTransaction(DTrans01);
                Console.WriteLine("\nPrint the transaction? (Yes/No)");
                Console.Write(">> ");
                if (Console.ReadLine().ToLower() == "yes" || Console.ReadLine().ToLower() == "y")
                {
                    Console.WriteLine();
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
        static void DoWithdrawal(Bank bank)
        {
            decimal amount;
            Account account = FindAccount(bank);

            if (account == null)
            {
                Console.WriteLine("\nTransaction aborted! Account can not be found!");
                Console.WriteLine("Suggestion: Add new account with desired name!");
                return;
            }
            
            Console.Write("Enter withdrawal amount: ");
            amount = Convert.ToDecimal(Console.ReadLine());

            WithdrawTransaction WTrans01 = new WithdrawTransaction(account, amount);

            Console.WriteLine("Execute? (Yes/No)");
            Console.Write(">> ");
            string exe_w = Console.ReadLine().ToLower();

            if (exe_w == "yes")
            {
                bank.ExecuteTransaction(WTrans01);
                Console.WriteLine("\nPrint the transaction? (Yes/No)");
                Console.Write(">> ");
                if (Console.ReadLine().ToLower() == "yes" || Console.ReadLine().ToLower() == "y")
                {
                    Console.WriteLine();
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

        static void DoTransfer(Bank bank)
        {
            decimal amount;
            Console.WriteLine("Account who sends the credit");
            Account fromAcc = FindAccount(bank);

            if (fromAcc == null)
            {
                Console.WriteLine("\nTransaction aborted! Sender account cannot be found!\n");
                Console.WriteLine("Suggestion: Add new account with desired name!");
                return;
            }

            Console.WriteLine("Account who recieves the credit");
            Account toAcc = FindAccount(bank);
            
            if (toAcc == null)
            {
                Console.WriteLine("\nTransaction aborted! Reciever account cannot be found!\n");
                Console.WriteLine("Suggestion: Add new account with desired name!");
                return;
            }

            Console.Write("Enter transfer amount: ");
            amount = Convert.ToDecimal(Console.ReadLine());

            if (amount < 0)
            {
                Console.WriteLine("Error! No negative numbers!");
                return;
            }

            TransferTransaction TTrans01 = new TransferTransaction(fromAcc, toAcc, amount);

            Console.WriteLine("Execute? (Yes/No)");
            Console.Write(">> ");
            string exe_t = Console.ReadLine().ToLower();

            if (exe_t == "yes")
            {
                bank.ExecuteTransaction(TTrans01);
                Console.WriteLine("\nPrint the transaction? (Yes/No)");
                Console.Write(">> ");
                if (Console.ReadLine().ToLower() == "yes" || Console.ReadLine().ToLower() == "yes")
                {
                    Console.WriteLine();
                    TTrans01.print();
                } 
            }

        }
        static void DoPrint(Bank bank)
        {
            Account account = FindAccount(bank);

            if (account == null)
            {
                Console.WriteLine("\nTransaction aborted! Account can not be found!");
                Console.WriteLine("Suggestion: Add new account with desired name!");
                return;
            }
            account.print();
        }

        private static Account FindAccount(Bank bank)
        {
            // Instance variable;
            Account result;

            Console.Write("Enter account name: ");
            result = bank.GetAccount(Console.ReadLine());

            if (result == null)
            {
                Console.WriteLine("\nAccount cannot be found!");
            }

            return result;
        }
    }