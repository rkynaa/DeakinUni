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