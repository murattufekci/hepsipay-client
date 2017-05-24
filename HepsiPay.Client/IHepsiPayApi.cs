using HepsiPay.Client.Messages;

namespace HepsiPay.Client
{
    public interface IHepsiPayApi : IApiBase
    {
        /// <summary>
        /// Makes the payment.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>MakePaymentResponse.</returns>
        MakePaymentResponse MakePayment(MakePaymentRequest request);

        /// <summary>
        /// Gets the authentication token.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>GetAuthenticationTokenResponse.</returns>
        GetAuthenticationTokenResponse GetAuthenticationToken(GetAuthenticationTokeRequest request);

        /// <summary>
        /// Saves the card.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>SaveCardResponse.</returns>
        SaveCardResponse SaveCard(SaveCardRequest request);

        /// <summary>
        /// Queries the cards.
        /// </summary>
        /// <param name="queryCardsRequest">The query cards request.</param>
        /// <returns>QueryCardsResponse.</returns>
        QueryCardsResponse QueryCards(QueryCardsRequest queryCardsRequest);

        /// <summary>
        /// Deletes the card.
        /// </summary>
        /// <param name="deleteCardRequest">The delete card request.</param>
        /// <returns>DeleteCardResponse.</returns>
        DeleteCardResponse DeleteCard(DeleteCardRequest deleteCardRequest);
    }
}