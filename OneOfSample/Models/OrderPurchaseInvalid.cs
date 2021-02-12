namespace OneOfSample.Models
{
    public class OrderPurchaseInvalid
    {
        public OrderPurchaseInvalid(string invalidMessage)
        => InvalidMessage = invalidMessage;

        public string InvalidMessage {get; }
    }
}