using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace TestAccount
{
    class DepositTransaction : Transaction
    {
        private Account _account;
        private bool _executed;
        private bool _reversed;

        public DepositTransaction(Account account, decimal amount) : base(amount)
        {
            this._account = account;
        }

        public bool Executed
        {
            get
            {
                return _executed;
            }
        }

        public override bool Success
        {
            get
            {
                return _success;
            }
        }

        public bool Reversed
        {
            get
            {
                return _reversed;
            }
        }

        public override void Print()
        {
            if (_success == true)
            {
                Console.WriteLine(_account.name + " has deposited with amount: " + Convert.ToString(_amount));
            }
            if (base.Reversed == true)
            {
                Console.WriteLine("Balance has been reversed");
            }
        }
        public override void Execute()
        {
            base.Execute();

            _executed = true;
            _success = _account.Deposit(_amount);

            if (_success == false)
            {
                throw new System.InvalidOperationException("Amount cannot be negative!");
            }
            else { }
        }
        public override void Rollback()
        {
            try
            {
                base.Rollback();
                _reversed = _account.Withdraw(_amount);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
