using System;
using OneOf;
using OneOfSample.Models;

namespace OneOfSample.Services
{
    public class AnExoticForm
    {
        public OneOf<ProofPayment, OrderPurchaseInvalid> MakePayment(OrderPurchase purchase)
        {
            if (purchase is null) return new OrderPurchaseInvalid("Object cannot be null");
            if (purchase.OrderId <= 0) return new OrderPurchaseInvalid("The orderId is invalid.");
            if (purchase.Total <= 0) return new OrderPurchaseInvalid("The total order cannot be zero.");

            if (
                 purchase.EPaymentType != PaymentType.Cash       ||
                 purchase.EPaymentType != PaymentType.CreditCard ||
                 purchase.EPaymentType != PaymentType.DebitCard
               ) { return new OrderPurchaseInvalid("The type payment is invalid."); }

            return new ProofPayment
            {
                Id = Guid.NewGuid(),
                Identifier = new Random(10).Next(100),
                Type =  purchase.GetLabelPaymentType(),
                DateBilling = DateTime.Now,
                Value = purchase.Total
            };
        }
    }
}