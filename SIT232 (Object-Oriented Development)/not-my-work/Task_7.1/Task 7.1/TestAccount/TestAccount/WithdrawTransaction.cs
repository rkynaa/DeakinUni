using System;
using System.Collections.Generic;
using System.Text;

namespace TestAccount
{
    class WithdrawTransaction : Transaction
    {
        private Account _account;
        private bool _executed;
        private bool _reversed;

        public WithdrawTransaction ( Account account, decimal amount ) : base(amount)
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
                Console.WriteLine(_account.name + " has withdrawn with amount: " + Convert.ToString(_amount));
            }

            if (_reversed == true)
            {
                Console.WriteLine("Balance has been reversed");
            }
        }
        public override void Execute()
        {
            base.Execute();

            _executed = true;
            _success = _account.Withdraw(_amount);

            if (_success == false)
            {
                throw new System.InvalidOperationException("Insufficient amount!");
            }
            else { }
        }
        public override void Rollback()
        {
            try
            {
                base.Rollback();
                _reversed = _account.Deposit(_amount);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
