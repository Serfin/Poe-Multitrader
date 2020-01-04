namespace Poe_Multitrader.Domain
{
    public class UserOffer
    {
        public UserOffer() 
        {

        }

        public UserOffer(string ign, string userName, int sellCurrency, float sellValue,
            int buyCurrency, float buyValue, int stock, string league)
        {
            Ign = ign;
            Username = userName;
            SellCurrency = sellCurrency;
            SellValue = sellValue;
            BuyCurrency = buyCurrency;
            BuyValue = buyValue;
            Stock = Stock;
            League = league;
        }

        public string Ign { get; set; }
        public string Username { get; set; }
        public int SellCurrency { get; set; }
        public float SellValue { get; set; }
        public int BuyCurrency { get; set; }
        public float BuyValue { get; set; }  
        public int Stock { get; set; }
        public string League { get; set; }
        public float Ratio 
        { 
            get {
                return SellValue / BuyValue;
            }
        }
    }
}