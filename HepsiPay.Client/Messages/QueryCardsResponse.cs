using System.Collections.Generic;

namespace HepsiPay.Client.Messages
{
    public class QueryCardsResponse : BaseResponse
    {
        public List<MerchantCardDto> MerchantCardDtos { get; set; }
        public PagerState PagerState { get; set; }
    }
}