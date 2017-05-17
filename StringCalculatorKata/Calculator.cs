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
            var sum = 0;

            if (!String.IsNullOrWhiteSpace(input))
            {
                if(!input.Contains(","))
                {
                    firstNumber = Convert.ToInt32(input);
                }
                else
                {
                    var numberList = ConvertStringToNumberList(input);
                    sum = SumOfList(numberList);
                }
            }
            
            return firstNumber + sum;
        }

        private List<Int32> ConvertStringToNumberList(String input)
        {
            var numberList = new List<Int32>();
            var commaIndex = input.IndexOf(',');

            while (commaIndex != -1)
            {
                numberList.Add(Convert.ToInt32(input.Substring(0, commaIndex)));
                input = input.Substring(commaIndex + 1, input.Length - commaIndex - 1);
                commaIndex = input.IndexOf(',');
            }

            numberList.Add(Convert.ToInt32(input.Substring(0, input.Length)));

            return numberList;
        }

        private Int32 SumOfList(List<Int32> list)
        {
            var sum = 0;
            foreach (var number in list)
                sum += number;

            return sum;
        }
    }
}
