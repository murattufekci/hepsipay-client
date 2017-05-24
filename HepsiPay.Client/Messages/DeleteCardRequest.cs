namespace HepsiPay.Client.Messages
{
    public class DeleteCardRequest : TokenBasedRequest
    {
        public string Id { get; set; }
        public string Apikey { get; set; }
        public string MerchantUserId { get; set; }
        public string MerchantCardUserId { get; set; }
    }
}