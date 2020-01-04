using System;
using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;
using Poe_Multitrader.Domain;

namespace Poe_Multitrader.WebScraper
{
    public class UserOffersScraper
    {
        public IEnumerable<UserOffer> ParseUsersOffers(string html)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);

            HtmlNode leagueName = doc.DocumentNode.SelectSingleNode("//h3[contains(@class, 'title')]//a");
            
            if (leagueName is null)
            {
                throw new ArgumentNullException("Cannot find league name node");
            }
            
            HtmlNodeCollection baseNodes = doc.DocumentNode.SelectNodes("//div[contains(@class, 'displayoffer ')]"); 

            if (baseNodes is null)
            {
                throw new ArgumentNullException("Cannot find users offers base node");
            }

            ICollection<UserOffer> usersOffers = new List<UserOffer>();

            foreach (var node in baseNodes)
            {
                usersOffers.Add(MapHtmlToObject(ParseLeagueName(leagueName.InnerHtml), node.Attributes));
            }

            return usersOffers;
        }

        public UserOffer MapHtmlToObject(string league, HtmlAttributeCollection attributes)
        {
            var userOffer = new UserOffer();

            userOffer.League = league;
            foreach (var attribute in attributes)
            {
                switch (attribute.OriginalName)
                {
                    case "data-username":
                        userOffer.Username = attribute.Value;
                        break;

                    case "data-sellcurrency":
                        userOffer.SellCurrency = int.Parse(attribute.Value);
                        break;

                    case "data-sellvalue":
                        userOffer.SellValue = float.Parse(attribute.Value.Replace('.', ','));
                        break;

                    case "data-buycurrency":
                        userOffer.BuyCurrency = int.Parse(attribute.Value);
                        break;

                    case "data-buyvalue":
                        userOffer.BuyValue = float.Parse(attribute.Value.Replace('.',','));
                        break;

                    case "data-ign":
                        userOffer.Ign = attribute.Value;
                        break;

                    case "data-stock":
                        userOffer.Stock = int.Parse(attribute.Value);
                        break;

                    default:
                        break;                    
                }
            }

            return userOffer;
        }

        public string ParseLeagueName(string item)
            => item.Substring(item.IndexOf("//") + 3, item.Length - item.IndexOf("//") - 3);
    }
}