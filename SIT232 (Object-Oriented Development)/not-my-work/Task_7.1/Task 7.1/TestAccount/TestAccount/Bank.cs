using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Transactions;

namespace TestAccount
{
    class Bank
    {
        List<Account> _accounts = new List<Account>();
        List<Transaction> _transactions = new List<Transaction>();

        public Bank(List<Account> accounts)
        {
            this._accounts = accounts;
        }

        public void AddAccount(Account account)
        {
            _accounts.Add(account);
            Console.WriteLine("Bank account " + account.name + " has been added to " +
                "list of bank accounts!");
        }

        public Account GetAccount(String name)
        {
            var answer = _accounts.Find(item => item.name == name);

            if ( answer != null )
            {
                Console.WriteLine("Account found!");
                return answer;
            }

            else
            {
                Console.WriteLine("Account not found!");
                return null;
            }
        }

        public Transaction GetTransaction(int index)
        {
            try
            {
                return _transactions[index];
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        public void ExecuteTransaction(Transaction transaction)
        {
            transaction.Execute();
            _transactions.Add(transaction);
        }

        public void RollbackTransaction(Transaction transaction)
        {
            transaction.Rollback();
        }

        public void PrintTransactionHistory()
        {
            for (int i= 0; i < _transactions.Count; i++)
            {
                _transactions[i].Print();
            }
        }
    }
}
