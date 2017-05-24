namespace HepsiPay.Client.Messages
{
    public class BasketItem
    {
        public string Description { get; set; }
        public string ProductCode { get; set; }
        public int Amount { get; set; }
        public int Count { get; set; }
        public int BasketItemType { get; set; }

        public BasketItem()
        {
            BasketItemType = 1;
        }
    }
}