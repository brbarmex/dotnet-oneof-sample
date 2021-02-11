using System;

namespace OneOfSample.OneOfServices.Models
{
    public class OrderPayment
    {
        public int OrderId { get; set; }
        public int Total { get; set; }
        public int Type { get; set; }
    }

    public class OrderPaymentInvalid
    {
        public string InvalidMessage {get; }

        public OrderPaymentInvalid(string invalidMessage) => InvalidMessage = invalidMessage;
    }

    public class ProofPayment
    {
        public Guid Id { get; set; }
        public int Identifier { get; set; }
        public decimal Value { get; set; }
        public string Type { get; set; }
        public DateTime DateBilling { get; set; }
    }
}