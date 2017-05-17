using System;
using System.Collections.Generic;

namespace StringCalculatorKata
{
    public class Calculator
    {
        private const String CustomDelimiterPrefix = "//";
        private const String CustomDelimiterSuffix = "\n";

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
                    String customDelimiter = null;
                    var customDelimiterIsDefined = input.Substring(0, 2) == CustomDelimiterPrefix;

                    if (customDelimiterIsDefined)
                    {
                        var isolatingDelimiters = new[] { CustomDelimiterPrefix, CustomDelimiterSuffix };
                        var expressionParts = input.Split(isolatingDelimiters, StringSplitOptions.RemoveEmptyEntries);
                        customDelimiter = expressionParts[0];
                        input = expressionParts[1];
                    }

                    var numberList = ConvertStringToNumberList(input, customDelimiter);
                    sum = SumOfList(numberList);
                }
            }
            
            return firstNumber + sum;
        }

        private List<Int32> ConvertStringToNumberList(String input, String customDelimiter)
        {
            var delimiters = new[] { ",", "\n", null };
            if (customDelimiter != null)
                delimiters[2] = customDelimiter;
            
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
