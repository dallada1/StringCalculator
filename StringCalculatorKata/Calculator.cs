using System;
using System.Collections.Generic;

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
                if(!(input.Contains(",") || input.Contains("\n")))
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
            
            var delimiters = new[] {',', '\n' };
            var stringParts = input.Split(delimiters, StringSplitOptions.None);

            return StringsToIntegers(stringParts);
        }

        private Int32 SumOfList(List<Int32> list)
        {
            var sum = 0;
            foreach (var number in list)
                sum += number;

            return sum;
        }

        private List<Int32> StringsToIntegers(string[] array)
        {
            var returnList = new List<Int32>();
            foreach(var str in array)
                returnList.Add(Convert.ToInt32(str));

            return returnList;
        }
    }
}
