using System;
using OneOfSample.Models;
using OneOfSample.OneOfServices.Exceptions;

namespace OneOfSample.Services
{
    public class TraditionalWay
    {
        public ProofPayment MakePayment(OrderPurchase purchase)
        {
            if (purchase is null) return default;
            if (purchase.OrderId <= 0) throw new OrderPurchaseException("The orderId is invalid.");
            if (purchase.Total <= 0) throw new OrderPurchaseException("The total order cannot be zero.");

            if (
                 purchase.EPaymentType != PaymentType.Cash       ||
                 purchase.EPaymentType != PaymentType.CreditCard ||
                 purchase.EPaymentType != PaymentType.DebitCard
               ) { throw new OrderPurchaseException("The type payment is invalid."); }

            return new ProofPayment
            {
                Id = Guid.NewGuid(),
                Identifier = new Random(10).Next(100),
                Type = purchase.GetLabelPaymentType(),
                DateBilling = DateTime.Now,
                Value = purchase.Total
            };
        }
    }
}