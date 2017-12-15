namespace ATMCaseStudy
{
    public class CashDispenser
    {
        private int billCount;
        private const int INITIAL_COUNT = 1000;

        public CashDispenser()
        {
            billCount = INITIAL_COUNT;
        }

        public void DispenseCash(decimal amount)
        {
            billCount -= (int)amount; //TODO;
        }

        public bool isSufficiantCashAvailable(decimal amount)
        {
            if (billCount >= (int)amount)
                return true;
            else
                return false;            
        }
    }
}
