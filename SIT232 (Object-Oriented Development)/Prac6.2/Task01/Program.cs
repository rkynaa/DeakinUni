using System;
using System.Threading;
using System.Collections.Generic;

namespace Task01
{
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

    class WithdrawTransaction
    {
        private Account _account;
        private decimal _amount;
        private Boolean _executed;
        private Boolean _success;
        private Boolean _reversed;

        public WithdrawTransaction(Account account, decimal amount)
        {
            this._account = account;
            this._amount = amount;
        }

        public void print()
        {
            Console.WriteLine("Account " + _account.Name + "'s Withdrawal amount: " + _amount.ToString("C"));
            _account.print();
            
            // Printing execution status
            Console.Write("Executed? ");
            if (_executed)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }

            // Printing succession status
            Console.Write("Succeed? ");
            if (_success)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }

            // Printing reverse status
            Console.Write("Reversed? ");
            if (_reversed)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }

        public void Execute()
        {
            if (_executed == true || _account.withdraw(_amount) == false)
            {
                throw new System.InvalidOperationException("Transaction has been executed");
            }
            else
            {
                _success = _account.withdraw(_amount);
                _executed = true;
            }
            bool temp = _account.deposit(_amount);
        }

        public void Rollback()
        {
            _reversed = _account.deposit(_amount);
        }

        public bool Executed
        {
            get
            {
                return this._executed;
            }
        }

        public bool Success
        {
            get
            {
                return this._success;
            }
        }

        public bool Reversed
        {
            get
            {
                return this._reversed;
            }
        }
    }

    class DepositTransaction
    {
        private Account _account;
        private decimal _amount;
        private Boolean _executed;
        private Boolean _success;
        private Boolean _reversed;

        public DepositTransaction(Account account, decimal amount)
        {
            this._account = account;
            this._amount = amount;
        }

        public void print()
        {
            Console.WriteLine("Account " + _account.Name + "'s Deposit amount: " + _amount.ToString("C"));
            _account.print();
            
            // Printing execution status
            Console.Write("Executed? ");
            if (_executed)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }

            // Printing succession status
            Console.Write("Succeed? ");
            if (_success)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }

            // Printing reverse status
            Console.Write("Reversed? ");
            if (_reversed)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }

        public void Execute()
        {
            if (_executed == true)
            {
                throw new System.InvalidOperationException("Transaction has been executed");
            }
            _success = _account.deposit(_amount);
            _executed = true;
        }

        public void Rollback()
        {
            _reversed = _account.withdraw(_amount);
        }

        public bool Executed
        {
            get
            {
                return this._executed;
            }
        }

        public bool Success
        {
            get
            {
                return this._success;
            }
        }

        public bool Reversed
        {
            get
            {
                return this._reversed;
            }
        }

    }

    class TransferTransaction
    {
        private Account _fromAccount;
        private Account _toAccount;
        private decimal _amount;
        private DepositTransaction _deposit;
        private WithdrawTransaction _withdraw;
        private Boolean _executed;
        private Boolean _success;
        private Boolean _reversed;

        public TransferTransaction(Account fromAccount, Account toAccount, decimal amount)
        {
            this._fromAccount = fromAccount;
            this._toAccount = toAccount;
            this._amount = amount;
            this._withdraw = new WithdrawTransaction(_fromAccount, _amount);
            this._deposit = new DepositTransaction(_toAccount, _amount);
        }
        public void print()
        {
            Console.Clear();
            Console.WriteLine("Transferred " + _amount.ToString("C") + " from " + _fromAccount.Name + "'s Account to " + _toAccount.Name + "'s Account");
            
            // Printing execution status
            Console.Write("Executed? ");
            if (_executed)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }

            // Printing succession status
            Console.Write("Succeed? ");
            if (_success)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }

            // Printing reverse status
            Console.Write("Reversed? ");
            if (_reversed)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }

            Console.WriteLine();
            _withdraw.print();

            Console.WriteLine();
            _deposit.print();
        }

        public void Execute()
        {
            if (_executed == true || _fromAccount.withdraw(_amount) == false)
            {
                throw new System.InvalidOperationException("Transaction has been executed");
            }
            
            // Withdraw amount from the _fromAccount
            _withdraw.Execute();

            // Deposit amount to the _toAccount
            _deposit.Execute();

            if (_withdraw.Success && _deposit.Success)
            {
                _success = true;
            }
            else
            {
                _success = false;
            }
            _executed = true;
            bool temp = _fromAccount.deposit(_amount);
        }

        public void Rollback()
        {
            _withdraw.Rollback();
            _deposit.Rollback();
            _reversed = true;
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
            if (amount < 0)
            {
                throw new Exception("Cannot be negative!");
            }
            if (this._balance - amount < 0)
            {
                throw new Exception("Balance not enough!");
            }
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

    class Bank
    {
        // Instance variables
        private List<Account> _accounts;

        // Constructor
        public Bank()
        {
            _accounts = new List<Account>();
        }

        public void AddAccount(Account account)
        {
            _accounts.Add(account);
            Console.WriteLine("\nAccount " + account.Name + " has been added successfully!\n");
            account.print();
        }

        public Account GetAccount(String name)
        {
            foreach (Account account in _accounts)
            {
                if (account.Name == name)
                {
                    return account;
                }
            }
            return null;
        }

        public void ExecuteTransaction (WithdrawTransaction transaction)
        {
            try
            {
                transaction.Execute();
            }
            catch (System.Exception with_err)
            {
                if (with_err is InvalidOperationException)
                {
                    Console.WriteLine("Transaction has been executed. Rollback initiated.", with_err);
                    transaction.Rollback();
                }
                else
                {
                    Console.WriteLine(with_err);
                }
            }
        }

        public void ExecuteTransaction (DepositTransaction transaction)
        {
            try
            {
                transaction.Execute();
            }
            catch (System.Exception depo_err)
            {
                if (depo_err is InvalidOperationException)
                {
                    Console.WriteLine("Transaction has been executed. Rollback initiated.", depo_err);
                    transaction.Rollback();
                }
                else
                {
                    Console.WriteLine(depo_err);
                }
            }
        }
        
        public void ExecuteTransaction (TransferTransaction transaction)
        {
            try
            {
                transaction.Execute();
            }
            catch (System.Exception trans_err)
            {
                if (trans_err is InvalidOperationException)
                {
                    Console.WriteLine("Transaction has been executed. Rollback initiated.", trans_err);
                    transaction.Rollback();
                }
                else
                {
                    Console.WriteLine(trans_err);
                }
            }
        }
    }
}
