    class DepositTransaction : Transaction
    {
        private Account _account;
        private Boolean _executed;
        private Boolean _reversed;

        public DepositTransaction(Account account, decimal amount) : base(amount)
        {
            this._account = account;
        }

        public override void print()
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

        public override void Execute()
        {
            if (_executed == true)
            {
                throw new System.InvalidOperationException("Transaction has been executed");
            }
            _success = _account.deposit(_amount);
            _executed = true;
        }

        public override void Rollback()
        {
            _reversed = _account.withdraw(_amount);
        }


        public override bool Success
        {
            get
            {
                return this._success;
            }
        }

    }