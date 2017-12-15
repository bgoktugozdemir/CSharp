namespace ATMCaseStudy
{
    public class BankDatabase
    {
        private Account[] accounts;

        public BankDatabase()
        {
            accounts = new Account[4];
            accounts[0] = new Account(168869386, 3698, 500.00M, 350.00M);
            accounts[1] = new Account(567342198, 9331, 2023.00M, 1923.00M);
            accounts[2] = new Account(193867518, 1328, 750.50M, 700.25M);
            accounts[3] = new Account(497651832, 1881, 999.01M, 100.14M);
        }

        public bool AuthenticateUser(int userAccountNumber, int userPin)
        {
            Account account = GetAccount(userAccountNumber);
            foreach (var item in accounts)
                {
                    if (item.AccountNumber == userAccountNumber)
                        return GetAccount(userAccountNumber).ValidatePin(userPin);
                }
            return false;
        }

        public void Credit(int userAccountNumber, decimal amount)
        {
            GetAccount(userAccountNumber).Credit(amount);
        }

        public void Debit(int userAccountNumber, decimal amount)
        {
            GetAccount(userAccountNumber).Debit(amount);
        }

        public void Save(int userAccountNumber, decimal amount)
        {
            GetAccount(userAccountNumber).AvailableBalance -= amount;
            GetAccount(userAccountNumber).TotalBalance -= amount;
        }

        public Account GetAccount(int userAccountNumber)
        {
            foreach (var item in accounts)
            {
                if (item.AccountNumber == userAccountNumber)
                    return item;
            }
            return null;
        }

        public decimal getAvailableBalance(int userAccountNumber)
        {
            return GetAccount(userAccountNumber).AvailableBalance;
        }

        public decimal getTotalBalance(int userAccountNumber)
        {
            return GetAccount(userAccountNumber).TotalBalance;
        }
    }
}