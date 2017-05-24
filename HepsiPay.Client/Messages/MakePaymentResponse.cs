using System.Collections.Generic;

namespace HepsiPay.Client.Messages
{
    public class MakePaymentResponse
    {
        public int Amount { get; set; }
        public int Installment { get; set; }
        public string ApiKey { get; set; }
        public string TransactionId { get; set; }
        public string TransactionTime { get; set; }
        public string Signature { get; set; }
        public string Currency { get; set; }
        public List<object> Extras { get; set; }
        public string CardId { get; set; }
        public bool Success { get; set; }
        public string MessageCode { get; set; }
        public string Message { get; set; }
        public string UserMessage { get; set; }
    }
}