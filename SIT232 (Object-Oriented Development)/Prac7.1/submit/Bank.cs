class Bank
    {
        // Instance variables
        private List<Account> _accounts;
        private List<Transaction> _transactions;

        // Constructor
        public Bank()
        {
            _accounts = new List<Account>();
            _transactions = new List<Transaction>();
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

        public void ExecuteTransaction(Transaction transaction)
        {
            try
            {
                transaction.Execute();
            }
            catch (System.InvalidOperationException with_err)
            {
                Console.WriteLine("Transaction has been executed. Rollback initiated.", with_err);
                RollbackTransaction(transaction);
            }
            _transactions.Add(transaction);
        }

        public void RollbackTransaction(Transaction transaction)
        {
            transaction.Rollback();
        }

        public void PrintTransactionHistory()
        {
            Console.Clear();
            foreach (Transaction transaction in _transactions)
            {
                transaction.print();
                Console.WriteLine("Transaction time: " + transaction.DateStamp + "\n");
                Thread.Sleep(2000);
            }
        }
    }