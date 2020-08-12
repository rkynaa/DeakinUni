using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TestAccount
{
    class TransferTransaction : Transaction
    {
        private Account _fromAccount;
        private Account _toAccount;
        private DepositTransaction _deposit;
        private WithdrawTransaction _withdraw;
        private bool _executed;
        private bool _reversed;

        public TransferTransaction(Account _fromAccount, Account _toAccount, decimal amount) : base(amount)
        {
            this._fromAccount = _fromAccount;
            this._toAccount = _toAccount;
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
                Console.WriteLine("Transfer Amount: " + Convert.ToString(_amount) + " from "
                    + _fromAccount.name + " to " + _toAccount.name);

            }

            if (_reversed == true)
            {
                Console.WriteLine("Balancess has been reversed");
            }
        }
        public override void Execute()
        {
            base.Execute();

            _executed = true;

            _withdraw = new WithdrawTransaction(_fromAccount, _amount);
            _withdraw.Execute();


            if (_withdraw.Success == true)
            {
                _deposit = new DepositTransaction(_toAccount, _amount);
                _deposit.Execute();
                _success = true;
            }
            else
            {
                throw new System.InvalidOperationException("Insufficient Balance!");
            }

            if (_withdraw.Success == false)
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
                _withdraw.Rollback();
                _deposit.Rollback();
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
