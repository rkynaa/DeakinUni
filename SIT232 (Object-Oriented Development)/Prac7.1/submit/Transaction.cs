    abstract class Transaction
    {
        // Instance variables
        protected decimal _amount;
        protected Boolean _success;
        private Boolean _executed;
        private Boolean _reversed;
        private DateTime _dateStamp;

        // Instance properties
        public abstract Boolean Success
        {
            get;
        }

        public Boolean Executed
        {
            get
            {
                return _executed;
            }
        }

        public Boolean Reversed
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

        // Constructor
        public Transaction(decimal amount)
        {
            this._amount = amount;
            this._executed = false;
            this._reversed = false;
            this._success = false;
        }

        public abstract void print();

        public virtual void Execute()
        {
            _dateStamp = DateTime.Now;
        }

        public virtual void Rollback()
        {
            _dateStamp = DateTime.Now;
        }
    }