    class Account
    {
        // Instance Variables
        private decimal _balance;
        private String _name;

        public Account(String name, decimal balance)
        {
            this._name = name;
            this._balance = balance;
        }

        // Accessor methods
        public String Name
        {
            get
            {
                return this._name;
            }
        }

        public bool deposit(decimal amount)
        {
            if(amount > 0)
            {
                this._balance += amount;
//                Console.WriteLine("Deposit succeed. New balance: " + this._balance.ToString("C"));
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool withdraw(decimal amount)
        {
            if (amount < 0)
            {
                throw new Exception("Cannot be negative!");
            }
            if (this._balance - amount < 0)
            {
                throw new Exception("Balance not enough!");
            }
            if (this._balance - amount > 0)
            {
                this._balance -= amount;
//                Console.WriteLine("Withdraw succeed. New balance: " + this._balance.ToString("C"));
                return true;
            } else 
            {
//                Console.WriteLine("Error: balance not enough for withdrawal!");
                return false;
            }
        }
        public void print()
        {
            Console.WriteLine("Account name: " + this._name + "\nCurrent Balance: " + this._balance.ToString("C"));
        }
    }