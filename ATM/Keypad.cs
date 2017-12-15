using System;
using System.Text;
namespace ATMCaseStudy
{
    public class Keypad
    {

        public int GetInput()
        {
            return Convert.ToInt32(Console.ReadLine());
        }
    }
}