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