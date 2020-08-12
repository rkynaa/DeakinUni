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