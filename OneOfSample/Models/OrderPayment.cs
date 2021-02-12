namespace OneOfSample.Models
{
    public class OrderPurchase
    {
        public int OrderId { get; set; }
        public int Total { get; set; }
        public PaymentType EPaymentType { get; set; }

        public string GetLabelPaymentType()
        => this.EPaymentType switch
        {
            PaymentType.Cash => "Cash",
            PaymentType.CreditCard => "Credit card",
            PaymentType.DebitCard => "Debit card",
            _ => "Undefined type"
        };
    }

    public enum PaymentType
    {
        DebitCard = 0,
        CreditCard = 1,
        Cash = 2
    }
}