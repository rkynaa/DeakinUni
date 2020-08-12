using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5._2P
{
    class DepositTransaction
    {
        private Account _account;
        private decimal _amount;
        private bool _executed = false;
        private bool _success = false;
        private bool _reversed = false;
        public bool Success
        {
            get
            {
                return _success;
            }
        }

        public bool Executed
        {
            get
            {
                return _executed;
            }
        }
        public bool Reversed
        {
            get
            {
                return _reversed;
            }
        }
        public DepositTransaction(Account account, decimal amount)
        {
            _account = account;
            _amount = amount;
        }
        public void Print()
        {
            if (_success == true)
            {
                Console.WriteLine("Deposit Successful");
                Console.WriteLine("Deposited Amount: " + Convert.ToString(_amount));

            }
            if (_reversed)
            {
                Console.WriteLine("Reserved");
            }
        }
        public void Execute()
        {
            if (_executed && _success)
            {
                throw new InvalidOperationException("Transaction Already Executed");
            }
            _executed = true;
            _success = _account.Deposit(_amount);
            if (!_success)
            {
                _executed = false;
                throw new InvalidOperationException("Insufficient Balance");
            }
        }
        public void Rollback()
        {
            if (!_success)
            {
                throw new InvalidOperationException("Cannot Rollback!Transaction NOT Executed Successfully");
            }
            if (_reversed)
            {
                throw new InvalidOperationException("Cannot Rollback! Transaction Already Reversed");
            }
            if (!_reversed)
            {
                throw new InvalidOperationException("Insufficient Balance");
            }
            
            _reversed = true;
            _reversed = _account.Withdraw(_amount);
        }

    }
}
