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
        private const Int32 minNumber = 0;
        private const Int32 maxNumber = 1000;

        public Int32 Add(String input)
        {
            if (String.IsNullOrWhiteSpace(input))
                return 0;

            var noDelimitersAreUsed = !(input.Contains(",") || input.Contains("\n"));
            if (noDelimitersAreUsed)
                return Convert.ToInt32(input);

            var numberList = new List<Int32>();
            var customDelimiterIsDefined = input.Substring(0, 2) == CustomDelimiterPrefix;

            if (customDelimiterIsDefined)
                numberList = BuildNumberListForCustomDelimiter(input);
            else
                numberList = ConvertStringToNumberList(input).ToList();

            VerifyNoNegativesExist(numberList);

            return numberList.Where(n => n <= maxNumber).Sum();
        }

        private List<Int32> BuildNumberListForCustomDelimiter(String input)
        {
            var isolatingDelimiters = new[] { CustomDelimiterPrefix, CustomDelimiterSuffix };
            var expressionParts = input.Split(isolatingDelimiters, StringSplitOptions.RemoveEmptyEntries);
            var customDelimiter = expressionParts[0];
            var customLengthDelimiterIsDefined = customDelimiter.ElementAt(0) == CustomLengthDelimiterPrefix;
            var stringEquation = expressionParts[1];

            if (customLengthDelimiterIsDefined)
                return BuildNumberListForCustomLengthDelimiter(customDelimiter, stringEquation);
            else
                return ConvertStringToNumberList(stringEquation, customDelimiter).ToList();
        }

        private List<Int32> BuildNumberListForCustomLengthDelimiter(String customDelimiter, String input)
        {
            var bracketDelimiters = new[] { CustomLengthDelimiterPrefix, CustomLengthDelimiterSuffix };
            var multipleCustomDelimiters = customDelimiter.Split(bracketDelimiters, StringSplitOptions.RemoveEmptyEntries);

            return ConvertStringToNumberList(input, multipleCustomDelimiters).ToList();
        }

        private IEnumerable<Int32> ConvertStringToNumberList(String input, String customDelimiter = null)
        {
            return ConvertStringToNumberList(input, new[] { customDelimiter });
        }

        private IEnumerable<Int32> ConvertStringToNumberList(String input, String[] customDelimiters)
        {
            var delimiters = new List<String> { ",", "\n"};
            delimiters.AddRange(customDelimiters);
            var stringParts = input.Split(delimiters.ToArray(), StringSplitOptions.None);

            return StringsToIntegers(stringParts);
        }

        private void VerifyNoNegativesExist(List<Int32> numberList)
        {
            var negatives = numberList.Where(n => n < minNumber);

            if (negatives.Any())
            {
                var exceptionMessage = BuildNegativeNumberExceptionMessage(negatives);
                throw new NegativesNotAllowedException(exceptionMessage);
            }
        }

        private IEnumerable<Int32> StringsToIntegers(String[] array)
        {
            return array.Select(s => Convert.ToInt32(s));
        }

        private String BuildNegativeNumberExceptionMessage(IEnumerable<Int32> negatives)
        {
            var negativeNumbers = String.Join(", ", negatives);
            var notAllowedMessage = negatives.Count() > 1 ? "are not allowed." : "is not allowed.";
            var exceptionMessage = String.Format("{0} {1}", negativeNumbers, notAllowedMessage);

            return exceptionMessage;
        }
    }
}
