namespace OneOfSample.Models
{
    public class OrderPaymentInvalid
    {
        public OrderPaymentInvalid(string invalidMessage)
        => InvalidMessage = invalidMessage;

        public string InvalidMessage {get; }
    }
}