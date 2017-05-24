using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using HepsiPay.Client.Messages;

namespace HepsiPay.Client
{
    public class HepsiPayApi : ApiBase, IHepsiPayApi
    {
        public HepsiPayApi(string baseApiUrl)
        {
            _baseApiUrl = baseApiUrl;
        }

        /// <summary>
        /// The Base API URL
        /// </summary>
        private readonly string _baseApiUrl;

        /// <summary>
        /// Makes the payment.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>MakePaymentResponse.</returns>
        public MakePaymentResponse MakePayment(MakePaymentRequest request)
        {
            request.Signature =
                CreateSHA256Hash(request.ApiSecret + request.TransactionId + request.TransactionTime + request.Amount +
                            request.Currency + request.Installment);
            return MakeApiRequest<MakePaymentRequest, MakePaymentResponse>(request, _baseApiUrl + "payments/pay", null);

        }

        /// <summary>
        /// Gets the authentication token.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>GetAuthenticationTokenResponse.</returns>
        public GetAuthenticationTokenResponse GetAuthenticationToken(GetAuthenticationTokeRequest request)
        {
            string hashed = GenerateBase64Hash(request.ClientId + ":" + request.ClientSecret);
            var headers = new Dictionary<string, string> { { "Authorization", "Basic " + hashed } };
            var response = GetResponse(_baseApiUrl + "oauth/token", "grant_type=password", headers,
                "application/x-www-form-urlencoded");
            var tokenResponse = GetResponseObject<GetAuthenticationTokenResponse>(response);
            tokenResponse.Success = !string.IsNullOrEmpty(tokenResponse.AccessToken);
            return tokenResponse;
        }

        /// <summary>
        /// Saves the card.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>SaveCardResponse.</returns>
        public SaveCardResponse SaveCard(SaveCardRequest request)
        {
            var headers = new Dictionary<string, string> { { "Authorization", "Bearer " + request.Token } };
            var response = MakeApiRequest<SaveCardRequest, SaveCardResponse>(request, _baseApiUrl + "cards", headers);
            return response;
        }

        /// <summary>
        /// Queries the cards.
        /// </summary>
        /// <param name="queryCardsRequest">The query cards request.</param>
        /// <returns>QueryCardsResponse.</returns>
        public QueryCardsResponse QueryCards(QueryCardsRequest queryCardsRequest)
        {
            var headers = new Dictionary<string, string> { { "Authorization", "Bearer " + queryCardsRequest.Token } };
            var response = MakeApiRequest<QueryCardsRequest, QueryCardsResponse>(queryCardsRequest, _baseApiUrl + "cards/query", headers);
            return response;
        }

        /// <summary>
        /// Deletes the card.
        /// </summary>
        /// <param name="deleteCardRequest">The delete card request.</param>
        /// <returns>DeleteCardResponse.</returns>
        public DeleteCardResponse DeleteCard(DeleteCardRequest deleteCardRequest)
        {
            var headers = new Dictionary<string, string> { { "Authorization", "Bearer " + deleteCardRequest.Token } };
            var response = MakeApiRequest<DeleteCardRequest, DeleteCardResponse>(deleteCardRequest, _baseApiUrl + "cards", headers, method: "DELETE");
            return response;
        }
    }
}
