using System;
using System.Collections.Generic;
using System.Text;

namespace TestAccount
{
    class WithdrawTransaction
    {
        private Account _account;
        private decimal _amount;
        private bool _executed;
        private bool _success;
        private bool _reversed;

        public WithdrawTransaction ( Account account, decimal amount )
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
                Console.WriteLine("Withdrawn Amount: " + Convert.ToString(_amount));
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
            _success = _account.Withdraw(_amount);

            if (_success == false)
            {
                throw new System.InvalidOperationException("Insufficient amount!");
            }
            else { }
        }
        public void Rollback()
        {

                _reversed = true;
                _reversed = _account.Deposit(_amount);
        }
    }
}
