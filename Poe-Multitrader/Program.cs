using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Poe_Multitrader
{
    class Program
    {
        private const float CurrencyLimit = 999999.0F;
        private static int? StockLimit = null;
        private const string filePath = @"full path to file: \users_to_whisper.txt";
        private const int usersLimit = 15;
		
        static async Task Main(string[] args)
        {
            var service = new OffersService();
            var usersOffers = await service.GetUserOffersAsync(LeagueDictionary.Metamorph, true, 
                StockLimit, 4, 6);

            usersOffers.OrderBy(x => x.Ratio);

            var messageBuilder = new MessageBuilder();
            using (StreamWriter file = new StreamWriter(filePath, false))
            {
                foreach (var user in usersOffers.Take(usersLimit))
                {
                    if (user.SellValue / user.BuyCurrency > CurrencyLimit)
                        continue;
                
                    file.WriteLine(messageBuilder.PrepareMessage(user));
                }
            }

            System.Console.WriteLine($"Saved {usersLimit} offers in \"{filePath}\"");
        }
    }
}
