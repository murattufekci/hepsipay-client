namespace HepsiPay.Client.Messages
{
    public class BaseResponse
    {
        public bool Success { get; set; }
        public string MessageCode { get; set; }
        public string Message { get; set; }
        public string UserMessage { get; set; }
    }
}