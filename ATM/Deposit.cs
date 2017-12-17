namespace ATMCaseStudy
{
    public class Deposit : Transaction
    {
        private decimal amount;
        private Keypad keypad;
        private DepositSlot depositSlot;

        //constant representing cancel option
        private const int CANCELED = 0;

        //five-paramater constructer initializes class instance
        public Deposit(int userAccountNumber, Screen atmScreen, BankDatabase atmBankDatabase, Keypad atmKeypad, DepositSlot atmDepositSlot) : base(userAccountNumber, atmScreen, atmBankDatabase)
        {
            //initialize references to keypad and deposit slot
            keypad = atmKeypad;
            depositSlot = atmDepositSlot;
        }
        //perform transaction; overrides Transaction's abstract method
        public override void Execute()
        {
            amount = PromptForDepositAmount();

            if (amount != CANCELED)
            {
                // request deposit envelope containing specified amount
                UserScreen.DisplayMessage(
                    "\nPlease insert a deposit envelope containing ");
                UserScreen.DisplayDollarAmount(amount);
                UserScreen.DisplayMessageLine(" in the deposit slot.");
                // retrieve deposit envelope
                bool envelopeReceived = depositSlot.isDepositEnvelopeReceived();
                // check whether deposit envelope was received
                if (envelopeReceived)
                {
                    UserScreen.DisplayMessageLine(
                        "\nYour envelope has been received.\n" +
                        "The money just deposited will not be available " +
                        "until we \nverify the amount o any " +
                        "enclosed cash, and any enclosed checks clear.");

                    Database.Credit(AccountNumber, amount);
                    Database.Debit(AccountNumber, amount);
                }
                else
                    UserScreen.DisplayMessageLine(
                        "\nYou did not insert an envelope, so the ATM has " +
                        "cancelled your transaction.");
            }
            else
                UserScreen.DisplayMessageLine("\nCanceling transaction...");
        }
        private decimal PromptForDepositAmount()
        {
            // display the prompt and receive input
            UserScreen.DisplayMessage(
                "\nPlease input a deposit amount in CENTS (or 0 to cancel): ");
            int input = keypad.GetInput();
            // check whether the user cancelled or entered a valid amount
            if (input == CANCELED)
                return CANCELED;
            else
                return input;
        }
    }
}