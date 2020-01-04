using System.Text;

namespace Poe_Multitrader
{
    public class RequestBuilder
    {
        private const string baseUrl = "https://currency.poe.trade/search?";

        public static string PrepareRequest(string league, bool online, int? stock, int want, int have)
        {
            StringBuilder sb = new StringBuilder(baseUrl);
            sb.Append($"league={league}");

            if (online)
            {
                sb.Append($"&online=x");
            } 
            else
            {
                sb.Append($"&online=");
            }

            if (stock.HasValue)
            {
                sb.Append($"&stock={stock.Value}");
            }
            else
            {
                sb.Append("&stock=");           
            }

            sb.Append($"&want={want}");
            sb.Append($"&have={have}");           

            return sb.ToString();
        }
    }
}