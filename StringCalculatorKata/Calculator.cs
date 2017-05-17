using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorKata
{
    public class Calculator
    {
        public Int32 Add(String input)
        {
            var firstNumber = 0;
            var secondNumber = 0;

            if (!String.IsNullOrWhiteSpace(input))
            {
                if(!input.Contains(","))
                {
                    firstNumber = Convert.ToInt32(input);
                }
                else
                {
                    var indexOfComma = input.IndexOf(',');
                    var lengthOfSecondNumber = input.Length - indexOfComma - 1;
                    firstNumber = Convert.ToInt32(input.Substring(0, indexOfComma));
                    secondNumber = Convert.ToInt32(input.Substring(indexOfComma + 1, lengthOfSecondNumber));
                }
            }
            
            return firstNumber + secondNumber;
        }
    }
}
