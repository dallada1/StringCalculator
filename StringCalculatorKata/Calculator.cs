using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorKata
{
    public class Calculator
    {
        private const String CustomDelimiterPrefix = "//";
        private const String CustomDelimiterSuffix = "\n";
        private const Char CustomLengthDelimiterPrefix = '[';
        private const Char CustomLengthDelimiterSuffix = ']';

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
                    var numberList = new List<Int32>();
                    var customDelimiterIsDefined = input.Substring(0, 2) == CustomDelimiterPrefix;

                    if (customDelimiterIsDefined)
                    {

                        var isolatingDelimiters = new[] { CustomDelimiterPrefix, CustomDelimiterSuffix };
                        var expressionParts = input.Split(isolatingDelimiters, StringSplitOptions.RemoveEmptyEntries);
                        customDelimiter = expressionParts[0];
                        var customLengthDelimiterIsDefined = customDelimiter.ElementAt(0) == CustomLengthDelimiterPrefix;

                        if (customLengthDelimiterIsDefined)
                        {
                            var bracketDelimiters = new[] { CustomLengthDelimiterPrefix, CustomLengthDelimiterSuffix };
                            var multipleCustomDelimiters = customDelimiter.Split(bracketDelimiters, StringSplitOptions.RemoveEmptyEntries);
                            input = expressionParts[1];
                            numberList = ConvertStringToNumberList(input, multipleCustomDelimiters);
                        }
                        else
                        {
                            input = expressionParts[1];
                            numberList = ConvertStringToNumberList(input, customDelimiter);
                        }
                    }
                    else
                    {
                        numberList = ConvertStringToNumberList(input, customDelimiter);
                    }
                    
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

        private List<Int32> ConvertStringToNumberList(String input, String[] customDelimiters)
        {
            var delimiters = new List<String> { ",", "\n"};

            delimiters.AddRange(customDelimiters);

            var stringParts = input.Split(delimiters.ToArray(), StringSplitOptions.None);

            return StringsToIntegers(stringParts);
        }

        private Int32 SumOfList(List<Int32> list)
        {
            var sum = 0;
            var negatives = new List<Int32>();

            foreach (var number in list)
            {
                if(number < 0)
                    negatives.Add(number);
                if(number <= 1000)
                    sum += number;
            }
            if (negatives.Any())
            {
                var exceptionMessage = BuildNegativeNumberExceptionMessage(negatives);
                throw new NegativesNotAllowedException(exceptionMessage);
            }

            return sum;
        }

        private List<Int32> StringsToIntegers(string[] array)
        {
            var returnList = new List<Int32>();
            foreach(var str in array)
                returnList.Add(Convert.ToInt32(str));

            return returnList;
        }

        private static string BuildNegativeNumberExceptionMessage(List<int> negatives)
        {
            var negativeNumbers = String.Join(", ", negatives);
            var notAllowedMessage = negatives.Count() > 1 ? "are not allowed." : "is not allowed.";
            var exceptionMessage = String.Format("{0} {1}", negativeNumbers, notAllowedMessage);

            return exceptionMessage;
        }
    }
}
