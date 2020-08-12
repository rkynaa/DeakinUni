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
            if (this._balance - amount >= 0)
            {
                this._balance -= amount;
                return true;
            } else 
            {
                return false;
            }
        }
        public void print()
        {
            Console.WriteLine("Account name: " + this._name + "\nCurrent Balance: " + this._balance.ToString("C"));
        }
    }