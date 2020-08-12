using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5._2P
{
    class TransferTransaction
    {
        private Account _fromAccount;
        private Account _toAccount;
        private decimal _amount;
        private DepositTransaction _deposit;
        private WithdrawTransaction _withdraw;
        private bool _executed;
        private bool _reversed;

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
        public bool Success => (_deposit.Success && _withdraw.Success);

        public TransferTransaction(Account toAccount, Account fromAccount, decimal amount)
        {
            _fromAccount = fromAccount;
            _toAccount = toAccount;
            _amount = amount;
            _deposit = new DepositTransaction(_toAccount, amount);
            _withdraw = new WithdrawTransaction(_fromAccount, amount);
        }
        public void Print()
        {
            if(_withdraw.Success && _deposit.Success )
            {
                Console.WriteLine("Transferred ${0} from {1} to {2}", _amount, _fromAccount.name, _toAccount.name);
                Console.WriteLine();
                Console.WriteLine(" ");
                _deposit.Print();
                Console.WriteLine();
                Console.WriteLine(" ");
                _withdraw.Print();
            }
            else if(_withdraw.Reversed && _deposit.Reversed)
            {
                Console.WriteLine("Already Reversed!");
            }
        }
        public void Execute()
        {
            if (_executed)
            {
                throw new InvalidOperationException(" Transaction ALready Executed!");
            }
            _withdraw.Execute();
            _executed = true;
            if(_withdraw.Success)
            {
                _deposit.Execute();
                if (_deposit.Success == false)
                {
                    _withdraw.Rollback();
                }
            }
        }
        public void Rollback()
        {
            if (!_executed)
            {
                throw new InvalidOperationException(" Transaction ALready Executed!");
            }
            else if (_withdraw.Reversed || _deposit.Reversed)
            {
                throw new InvalidOperationException(" Transaction ALready Reversed! Cannot rollback!!");
            }
            else if (_withdraw.Success) 
            {
                _withdraw.Rollback();
            }
            else if (_deposit.Success)
            {
                _deposit.Rollback();
            }
            _executed = false;
        }





    }
}
