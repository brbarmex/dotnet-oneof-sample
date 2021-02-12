using System;

namespace OneOfSample.OneOfServices.Exceptions
{
    public class OrderPurchaseException: Exception
    {
        public OrderPurchaseException() : base()
        {
        }

        public OrderPurchaseException(string message) : base(message)
        {
        }

        public OrderPurchaseException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}