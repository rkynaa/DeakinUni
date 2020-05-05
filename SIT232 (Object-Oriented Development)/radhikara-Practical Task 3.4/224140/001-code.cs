static class AccountsSorter
    {
        public static void Sort(Account[] accounts, int b)
        {
            Account[] buckets = new Account[b];
            decimal M = 0;
            for (int i = 0; i < accounts.Length; i++)
            {
                if (M < accounts[i].Balance)
                {
                    M = accounts[i].Balance;
                }
            }
            for (int i = 0; i < b; i++)
            {
                buckets[Math.Floor((b * accounts[i].Balance)/ M)] = accounts[i];
            }
            for (int i = 0; i < b; i++)
            {
                buckets[i].Sort();
            }
            Console.Write("Sorted! now: ");
            for (int i = 0; i < b; i++)
            {
                if (buckets[i] != null)
                {
                    Console.Write(buckets[i].Name + buckets[i].Balance);
                }
            }
        }
        public static void Sort(List<Account> accounts, int b)
        {
            List<Account> buckets = new List<Account>();
            decimal M = 0;
            
            foreach (Account current in accounts)
            {
                if (M < current.Balance)
                {
                    m = current.Balance;
                }
            }
            foreach (Account current in accounts)
            {
                buckets.Add(Math.Floor((b * current.Balance)/ M)) = current;
            }
            foreach (Account current in buckets)
            {
                current.Sort();
            }
            Console.Write("Sorted! now: ");
            foreach (Account current in buckets)
            {
                if (current != null)
                {
                    Console.Write(current.Name + current.Balance);
                }
            }
        }
    }