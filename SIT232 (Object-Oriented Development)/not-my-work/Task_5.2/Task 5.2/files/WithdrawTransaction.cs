using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5._2P
{
    class WithdrawTransaction
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

        

        public WithdrawTransaction(Account account, decimal amount) 
        {  _account =account;
           _amount = amount;
        }
        public void Print()
        {
            if (_success == true)
            {
                Console.WriteLine("Withdraw Successful");
                Console.WriteLine("Withdrawn Amount: " + Convert.ToString(_amount));

            }
            if (_reversed)
            {
                Console.WriteLine("Reserved");
            }
        }
        public void Execute() 
        { 
            _executed = true;
            _success = _account.Withdraw(_amount);
            if (!_success)
            {
                _executed = false;
                throw new InvalidOperationException("Insufficient Balance");
            }
            if (_executed && _success)
            {
                throw new InvalidOperationException("Transaction Already Executed");
            }
        }
        public void Rollback()
        {
            if (!_executed)
            {
                throw new InvalidOperationException("Cannot Rollback!Transaction NOT Executed");
            }
            if(_reversed)
            {
                throw new InvalidOperationException("Cannot Rollback! Transaction Already Reversed");
            }
            if(!_reversed)
            {
                throw new InvalidOperationException("Insufficient Balance");
            }
            _executed = false;
            _reversed = true;
            _reversed = _account.Deposit(_amount);
        }
        
        
    }
}
