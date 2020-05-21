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
    }