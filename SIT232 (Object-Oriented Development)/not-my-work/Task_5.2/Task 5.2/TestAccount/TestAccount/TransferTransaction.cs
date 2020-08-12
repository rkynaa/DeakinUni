using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TestAccount
{
    class TransferTransaction
    {
        private Account _fromAccount;
        private Account _toAccount;
        private decimal _amount;
        private DepositTransaction _deposit;
        private WithdrawTransaction _withdraw;
        private bool _executed;
        private bool _success;
        private bool _reversed;

        public TransferTransaction(Account _fromAccount, Account _toAccount, decimal amount)
        {
            this._fromAccount = _fromAccount;
            this._toAccount = _toAccount;
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
                Console.WriteLine("Transfer Amount: " + Convert.ToString(_amount) + " from "
                    + _fromAccount + " to " + _toAccount);

            }

            if (_reversed == true)
            {
                Console.WriteLine("Balancess has been reversed");
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

            _withdraw = new WithdrawTransaction(_fromAccount, _amount);
            _withdraw.Execute();
            _deposit = new DepositTransaction(_toAccount, _amount);


            if (_withdraw.success == true)
            {
                _deposit.Execute();
            }
            else
            {
                throw new System.InvalidOperationException("Insufficient Balance!");
            }
        }
        public void Rollback()
        {
                _withdraw.Rollback();
                _deposit.Rollback();
                _reversed = true;
        }
    }
}
