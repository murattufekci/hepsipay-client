using System.Collections.Generic;
using Newtonsoft.Json;

namespace HepsiPay.Client.Messages
{
    public class MakePaymentRequest : HepsiPayRequest
    {
        public MakePaymentRequest()
        {
            Card = new Card();
            Customer = new Customer();
            Version = "1.0";
        }
        public string Version { get; set; }
        public string ApiKey { get; set; }
        public string TransactionId { get; set; }
        public int TransactionTime { get; set; }
        public string Signature { get; set; }
        [JsonIgnore]
        public string ApiSecret { get; set; }

        public string MerchantCardId { get; set; }

        public int Amount { get; set; }

        public string Currency { get; set; }

        public int Installment { get; set; }
        public Card Card { get; set; }
        public Customer Customer { get; set; }
        public List<BasketItem> BasketItems { get; set; }

        public AddressInfo InvoiceAddress { get; set; }
        public AddressInfo ShippingAddress { get; set; }
    }
}