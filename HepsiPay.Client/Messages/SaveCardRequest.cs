namespace HepsiPay.Client.Messages
{
    public class SaveCardRequest : TokenBasedRequest
    {
        public string Fullname { get; set; }
        public string Cardnumber { get; set; }
        public string Expiremonth { get; set; }
        public string Expireyear { get; set; }
        public string Apikey { get; set; }
        public string MerchantUserId { get; set; }
        public string MerchantCardUserId { get; set; }
        public string Email { get; set; }
        public string ReferenceId1 { get; set; }
    }
}