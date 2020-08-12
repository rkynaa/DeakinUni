using System;
using System.Collections.Generic;
using System.Text;

namespace TestAccount
{
    abstract class Transaction
    {
        protected decimal _amount;
        protected bool _success;
        private bool _executed;
        private bool _reversed;
        private DateTime _dateStamp;

        public bool Executed
        {
            get
            {
                return _executed;
            }
        }

        public abstract bool Success
        {
            get;
        }

        public bool Reversed
        {
            get
            {
                return _reversed;
            }
        }

        public DateTime DateStamp
        {
            get
            {
                return _dateStamp;
            }
        }

        public Transaction(decimal amount)
        {
            this._amount = amount;
        }

        public abstract void Print();

        public virtual void Execute()
        {
            if (_executed == true && _success == true)
            {
                throw new System.InvalidOperationException("Transaction has already been executed!");
            }
            else { }

            _executed = true;
        }

        public virtual void Rollback()
        {
            if (_executed == false)
            {
                throw new InvalidOperationException("Transaction has not been executed!");
            }
            else if (_reversed == true)
            {
                throw new InvalidOperationException("Transaction has already been reversed!");
            }
            else
            {
                _executed = false;
                _reversed = true;
            }
        }
    }
}
