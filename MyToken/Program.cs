using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToken
{
    class Program
    {
        static void Main(string[] args)
        {
            var key = "lmzBK8jSVoUSDixirrKIC2O80WHkm7IQJp827qL/HIc=";
            var result = MyTokenApi.AddToken(key, new Token()
            {
                Symbol = "BitCny",
                ContactAddress = "",
                CoinmarketcapUrl = "",
                ExplorerUrl = "",
                Facebook = "",
                Github = "",
                Id = 1,
                LogoUrl = "",
                Name = "BitCny",
                Twitter = "",
                UniqueKey = "BitCny"
            });
            
            var result2 = CreateBatchTickersTest(key);
            Console.WriteLine(result2);


            //var key= MyTokenApi.GetKey();
            //Console.WriteLine(key);
            Console.Read();
        }
        
        public static string CreateBatchTickersTest(string key)
        {
            var result = MyTokenApi.CreateBatchTickers(key, new List<Ticker>()
            {
                new Ticker()
                {
                    SymbolKey = "BitCny",
                    SymbolName = "BitCny",
                    AnchorKey = "BTC",
                    AnchorName = "BTC",
                    Price = "10.232",
                    PriceUpdatedAt = "2018-03-13 13:15:00 +8000",
                    Volume24h = "10.2",
                    VolumeAnchor24h = "100.22"
                },
                new Ticker()
                {
                    SymbolKey = "BitCny",
                    SymbolName = "BitCny",
                    AnchorKey = "BTC",
                    AnchorName = "BTC",
                    Price = "10.232",
                    PriceUpdatedAt = "2018-03-13 13:16:00 +8000",
                    Volume24h = "10.2",
                    VolumeAnchor24h = "100.22"
                }
            });
            return result;
        }
    }
}
