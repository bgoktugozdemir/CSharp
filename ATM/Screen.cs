namespace ATMCaseStudy
{
    public class Screen
    {

        public void DisplayMessage(string p)
        {
            System.Console.Write(p);
        }

        public void DisplayDollarAmount(decimal amount)
        {
            System.Console.WriteLine(amount + " $");
        }

        public void DisplayMessageLine(string p)
        {
            System.Console.WriteLine(p);
        }
    }
}