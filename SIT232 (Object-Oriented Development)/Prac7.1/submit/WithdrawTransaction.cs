    class WithdrawTransaction : Transaction
    {
        private Account _account;
        private Boolean _executed;
        private Boolean _reversed;

        public WithdrawTransaction(Account account, decimal amount) : base(amount)
        {
            this._account = account;
        }

        public override void print()
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

        public override void Execute()
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
            //bool temp = _account.deposit(_amount); //kalau ini di uncomment saldo tidak akan berkurang
        }

        public override void Rollback()
        {
            _reversed = _account.deposit(_amount);
        }

        public override bool Success
        {
            get
            {
                return this._success;
            }
        }
    }