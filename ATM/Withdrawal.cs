namespace ATMCaseStudy
{
    class Withdrawal : Transaction
    {
        private decimal amount;
        private const int CANCELED = 0;
        private CashDispenser cashDispenser;
        private Keypad keypad;

        public Withdrawal(int userAccount, Screen screen, BankDatabase bankDatabase, Keypad keypad, CashDispenser cashDispenser) : base(userAccount, screen, bankDatabase)
        {
            this.keypad = keypad;
            this.cashDispenser = cashDispenser;
        }

        public int displayMenu()
        {
            int Choice = 0;

            int[] amounts = { 0, 10, 20, 30, 40, 50, 100 };

            while (Choice == 0)
            {
                UserScreen.DisplayMessageLine("\nWithdrawal Menu:");
                UserScreen.DisplayMessageLine("1 - $10");
                UserScreen.DisplayMessageLine("2 - $20");
                UserScreen.DisplayMessageLine("3 - $30");
                UserScreen.DisplayMessageLine("4 - $40");
                UserScreen.DisplayMessageLine("5 - $50");
                UserScreen.DisplayMessageLine("6 - $100");
                UserScreen.DisplayMessageLine("7 - Custom");
                UserScreen.DisplayMessageLine("0 - Cancel");
                UserScreen.DisplayMessage("\nChoose a withdrawal amount: ");

                int input = keypad.GetInput();

                switch (input)
                {
                    case 1:
                        Choice = amounts[input];
                        break;
                    case 2:
                        Choice = amounts[input];
                        break;
                    case 3:
                        Choice = amounts[input];
                        break;
                    case 4:
                        Choice = amounts[input];
                        break;
                    case 5:
                        Choice = amounts[input];
                        break;
                    case 6:
                        Choice = amounts[input];
                        break;
                    case 7:
                        UserScreen.DisplayMessage("\nPlease enter money you want: ");
                        Choice = keypad.GetInput();
                        break;
                    case CANCELED:
                        Choice = CANCELED;
                        break;
                    default:
                        UserScreen.DisplayMessageLine("\nInvalid selection. Try again.");
                        break;
                }
            }
                return Choice;
        }

        public override void Execute()
        {
            bool cashDispensed = false;
            decimal availableBalance;

            BankDatabase bankDatabase = new BankDatabase();
            Screen screen = new Screen();

            do
            {
                amount = (decimal)displayMenu();

                if (amount != CANCELED)
                {
                    availableBalance = bankDatabase.getAvailableBalance(AccountNumber);

                    if (amount <= availableBalance)
                    {
                        bankDatabase.Debit(AccountNumber, amount);

                        cashDispenser.DispenseCash(amount);
                        cashDispensed = true;

                        bankDatabase.Save(AccountNumber, amount);

                        screen.DisplayMessageLine("\nYour cash has been dispensed. Please take your cash now.");
                    }
                    else
                        screen.DisplayMessageLine("\nInsufficient funds in your account. \nPlease choose a smaller amount.");
                }
                else
                {
                    screen.DisplayMessageLine("\nCancelling transaction...");
                    return;
                }
            } while (!cashDispensed);
        }
    }
}
