using System.Collections.Generic;

namespace HepsiPay.Client.Messages
{
    public class DeleteCardResponse : BaseResponse
    {
        public List<MerchantCardDto> MerchantCardDtos { get; set; }
    }
}