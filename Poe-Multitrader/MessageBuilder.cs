using System.Text;
using Poe_Multitrader.Domain;

namespace Poe_Multitrader
{
    public class MessageBuilder
    {
        public string PrepareMessage(UserOffer userOffer)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"@{userOffer.Ign} ");
            sb.Append(" Hi, I'd like to buy your ");
            sb.Append(userOffer.SellValue + " ");
            sb.Append(DictionaryManager.Translate(userOffer.SellCurrency));
            sb.Append(" for my ");
            sb.Append(userOffer.BuyValue + " ");
            sb.Append(DictionaryManager.Translate(userOffer.BuyCurrency));
            sb.Append($" in {userOffer.League}");

            //sb.Append($"  [RATIO {userOffer.Ratio} => 1]  ");

            return sb.ToString();
        }
    }
}