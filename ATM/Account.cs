namespace ATMCaseStudy
{
    public class Account
    {
        public int AccountNumber { get; set; }
        public decimal AvailableBalance { get; set; }
        public int Pin { get; set; }
        public decimal TotalBalance { get; set; }

        public Account(int AccountNumber, int Pin, decimal TotalBalance, decimal AvailableBalance)
        {
            this.AccountNumber = AccountNumber;
            this.Pin = Pin;
            this.TotalBalance = TotalBalance;
            this.AvailableBalance = AvailableBalance;
        }

        public void Credit(decimal amount)
        {
            TotalBalance += amount;
        }

        public void Debit(decimal amount)
        {
            TotalBalance -= amount;
            AvailableBalance -= amount;
        }

        public bool ValidatePin(int userPin)
        {
            if (userPin == Pin)
                return true;
            else
                return false;
        }
    }
}
