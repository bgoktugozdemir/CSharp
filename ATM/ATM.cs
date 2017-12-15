//Berat Göktuğ ÖZDEMİR
//150101002

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ATMCaseStudy
{
    class ATM
    {
        private BankDatabase bankDatabase;
        private CashDispenser cashDispenser;
        private int currentAccountNumber = 0;
        private DepositSlot depositSlot;
        private Keypad keypad;
        private Screen screen;
        private bool userAuthenticated = false;
        private bool userExited = false;

        private const int waitingSeconds = 5;
        private const int BALANCE_INQUIRY = 1;
        private const int WITHDRAWAL = 2;
        private const int DEPOSIT = 3;
        private const int EXIT_ATM = 0;

        static void Main(string[] args)
        {
            ATM atm = new ATM();
            atm.Run();
        }

        public ATM()
        {
            bankDatabase = new BankDatabase();
            cashDispenser = new CashDispenser();
            depositSlot = new DepositSlot();
            keypad = new Keypad();
            screen = new Screen();
        }

        public void AuthenticateUser()
        {
            screen.DisplayMessage("\nPlease enter your account number: ");
            int AccountNumber = Convert.ToInt32(Console.ReadLine());
            screen.DisplayMessage("\nEnter your PIN: ");
            int Pin = Convert.ToInt32(Console.ReadLine());

            userAuthenticated = bankDatabase.AuthenticateUser(AccountNumber, Pin);

            if (userAuthenticated)
                currentAccountNumber = AccountNumber;
            else
                screen.DisplayMessageLine("\nInvalid account number or PIN. Please try again.");

        }

        public Transaction CreateTransaction(int type)
        {
            Transaction temp = null;

            switch (type)
            {
                case BALANCE_INQUIRY:
                    temp = new BalanceInquiry(currentAccountNumber, screen, bankDatabase);
                    temp.Execute();
                    break;
                case WITHDRAWAL:
                    temp = new Withdrawal(currentAccountNumber, screen, bankDatabase, keypad, cashDispenser);
                    temp.Execute();
                    break;
                case DEPOSIT:
                    temp = new Deposit(currentAccountNumber, screen, bankDatabase, keypad, depositSlot);
                    temp.Execute();
                    break;
                case EXIT_ATM:
                    userExited = true;
                    screen.DisplayMessageLine("\nGoodbye!");
                    screen.DisplayMessage("\nExiting the system");
                    for (int i = 0; i < waitingSeconds; i++)
                    {
                        Thread.Sleep(1000);
                        if (i == waitingSeconds-1)
                            screen.DisplayMessageLine(".");
                        else
                            screen.DisplayMessage(".");
                    }
                    break;
                default:
                    screen.DisplayMessageLine("Please enter a valid selection.");
                    break;
            }
            return temp;
        }

        public void PerformTransactions()
        {
            screen.DisplayMessageLine("\nMain Menu: ");
            screen.DisplayMessageLine("1 - View my balance");
            screen.DisplayMessageLine("2 - Withdraw cash");
            screen.DisplayMessageLine("3 - Deposit funds");
            screen.DisplayMessageLine("0 - Exit");
            screen.DisplayMessage("Enter a choice: ");
            int mainMenuSelection = keypad.GetInput();
            CreateTransaction(mainMenuSelection);
        }

        public void Run()
        {
            while (true)
            {
                screen.DisplayMessageLine("\nWelcome!");

                while (!userAuthenticated)
                {
                    AuthenticateUser();
                }
                do
                {
                    PerformTransactions();
                } while (!userExited);
                userAuthenticated = false;
                currentAccountNumber = 0;
                Console.Clear();
                userExited = false;
            }
        }
    }
}
