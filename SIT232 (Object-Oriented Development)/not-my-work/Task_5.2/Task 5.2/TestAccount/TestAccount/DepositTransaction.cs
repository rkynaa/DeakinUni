using System;
using System.Collections.Generic;
using System.Text;

namespace TestAccount
{
    class DepositTransaction
    {
        private Account _account;
        private decimal _amount;
        private bool _executed;
        private bool _success;
        private bool _reversed;

        public DepositTransaction(Account account, decimal amount)
        {
            this._account = account;
            this._amount = amount;
        }

        public bool executed
        {
            get
            {
                return _executed;
            }
        }

        public bool success
        {
            get
            {
                return _success;
            }
        }

        public bool reversed
        {
            get
            {
                return _reversed;
            }
        }

        public void Print()
        {

            if (_success == true)
            {
                Console.WriteLine("Deposit Amount: " + Convert.ToString(_amount));
            }

            if (_reversed == true)
            {
                Console.WriteLine("Balance has been reversed");
            }
        }
        public void Execute()
        {
            if (_executed == true && _success == true)
            {
                throw new System.InvalidOperationException("Transaction has already been executed!");
            }
            else { }

            _executed = true;
            _success = _account.Deposit(_amount);

            if (_success == false)
            {
                throw new System.InvalidOperationException("Amount cannot be negative!");
            }
            else { }
        }
        public void Rollback()
        {

            if (_executed == false)
            {
                throw new InvalidOperationException("Transaction has not been executed!");
            }
            else if (_reversed == true)
            {
                throw new InvalidOperationException("Transaction has already been reversed!");
            }
            else if (_reversed == false)
            {
                throw new InvalidOperationException("Insufficient Balance");
            }
            else
            {
                _executed = false;
                _reversed = true;
                _reversed = _account.Deposit(_amount);
            }
        }
    }
}
