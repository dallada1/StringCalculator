using System;

namespace StringCalculatorKata
{
    public class NegativesNotAllowedException : Exception
    {
        public NegativesNotAllowedException(String message) : base(message)
        {
        }
    }
}
