using System;

namespace OneOfSample.OneOfServices.Exceptions
{
    public class OrderPaymentException: Exception
    {
        public OrderPaymentException() : base()
        {
        }

        public OrderPaymentException(string message) : base(message)
        {
        }

        public OrderPaymentException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}