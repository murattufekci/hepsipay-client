namespace HepsiPay.Client.Messages
{
    public class QueryCardsRequest: TokenBasedRequest
    {
        public string Apikey { get; set; }
        public string MerchantUserId { get; set; }
        public string MerchantCardUserId { get; set; }
        public string MerchantCardId { get; set; }
    }
}