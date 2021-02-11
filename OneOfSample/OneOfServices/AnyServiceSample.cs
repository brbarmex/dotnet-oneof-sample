using System;
using OneOf;
using OneOfSample.OneOfServices.Exceptions;
using OneOfSample.OneOfServices.Models;

namespace OneOfSample.OneOfServices
{
    public class PaymentService
    {
        public ProofPayment MakePaymentUsingTraditionalMethod(OrderPayment orderPayment)
        {
            if (orderPayment is null)
                return null;

            if (orderPayment.OrderId <= 0)
                throw new OrderPaymentException("The orderId is invalid.");

            if (orderPayment.Total <= 0)
                throw new OrderPaymentException("The total order cannot be zero.");

            if (orderPayment.Type != 1 && orderPayment.Type != 2)
                throw new OrderPaymentException("The type payment is invalid.");

            return new ProofPayment
            {
                Id = Guid.NewGuid(),
                Identifier = new Random(10).Next(100),
                Type = orderPayment.Type == 1 ? "Money" : "Card",
                DateBilling = DateTime.Now,
                Value = orderPayment.Total
            };
        }

        public OneOf<ProofPayment, OrderPaymentInvalid> MakePaymentWitOneOf(OrderPayment orderPayment)
        {
            if (orderPayment is null)
                return new OrderPaymentInvalid("Object cannot be null");

            if (orderPayment.OrderId <= 0)
                return new OrderPaymentInvalid("The orderId is invalid.");

            if (orderPayment.Total <= 0)
                return new OrderPaymentInvalid("The total order cannot be zero.");

            if (orderPayment.Type != 1 && orderPayment.Type != 2)
                return new OrderPaymentInvalid("The type payment is invalid.");

            return new ProofPayment
            {
                Id = Guid.NewGuid(),
                Identifier = new Random(10).Next(100),
                Type = orderPayment.Type == 1 ? "Money" : "Card",
                DateBilling = DateTime.Now,
                Value = orderPayment.Total
            };
        }
    }
}