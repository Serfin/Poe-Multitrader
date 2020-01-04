using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Poe_Multitrader.Domain;
using Poe_Multitrader.WebScraper;
using RestSharp;

namespace Poe_Multitrader
{
    public class OffersService
    {
        private static readonly HttpClient client = new HttpClient();

        public async Task<IEnumerable<UserOffer>> GetUserOffersAsync(string league, bool online, int? stock, int want, int have)
        {
            var client = new RestClient(RequestBuilder.PrepareRequest(league, online, stock, want, have));
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            var response = await client.ExecuteTaskAsync(request);
            
            var usersOffers = new UserOffersScraper();
            return usersOffers.ParseUsersOffers(response.Content);
        }
    }
}