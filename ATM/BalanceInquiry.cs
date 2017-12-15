namespace ATMCaseStudy
{
    class BalanceInquiry : Transaction
    {
        public BalanceInquiry(int accountNumber, Screen screen, BankDatabase bankDatabase):base(accountNumber, screen, bankDatabase)
        {

        }

        public override void Execute()
        {
            BankDatabase bankDatabase = new BankDatabase();

            var AvailableBalance = bankDatabase.getAvailableBalance(AccountNumber);
            var TotalBalance = bankDatabase.getTotalBalance(AccountNumber);

            UserScreen.DisplayMessageLine("\nBalance Information");
            UserScreen.DisplayMessage(" - Available Balance: ");
            UserScreen.DisplayDollarAmount(AvailableBalance);
            UserScreen.DisplayMessage("\n - Total Balance: ");
            UserScreen.DisplayDollarAmount(TotalBalance);
            UserScreen.DisplayMessageLine("");
        }
    }
}
