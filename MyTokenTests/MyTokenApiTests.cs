using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyToken;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToken.Tests
{
    [TestClass()]
    public class MyTokenApiTests
    {
        string key = "lmzBK8jSVoUSDixirrKIC2O80WHkm7IQJp827qL/HIc=";
        [TestMethod()]
        public void GetKeyTest()
        {
            var key = MyTokenApi.GetKey();
            Console.WriteLine(key);
            Assert.IsNotNull(key);
        }

        [TestMethod()]
        public void AddTokenTest()
        {
            var result = MyTokenApi.AddToken(key, new Token()
            {
                Symbol = "BTC",
                ContactAddress = "",
                CoinmarketcapUrl = "",
                ExplorerUrl = "",
                Facebook = "",
                Github = "",
                Id = 1,
                LogoUrl = "",
                Name = "BitCoin",
                Twitter = "",
                UniqueKey = "d8bea4e8c73c5476dc311f24209b844c"
            });
            Console.WriteLine(result);
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void GetTokensTest()
        {
            var result = MyTokenApi.GetTokens(key);
            Console.WriteLine(result);
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void AddTickerTest()
        {
            var result = MyTokenApi.AddTicker(key, new Ticker()
            {
                SymbolKey = "d8bea4e8c73c5476dc311f24209b844c",
                SymbolName = "BitCoin",
                AnchorKey = "62de4c4f2d82641a44172daf0af6af8c",
                AnchorName = "Ethereum",
                Price = "10.232",
                PriceUpdatedAt = "2018-03-13 13:14:00 +8000",
                Volume24h = "10.2",
                VolumeAnchor24h = "100.22m"
            });
            Console.WriteLine(result);
        }

        [TestMethod()]
        public void GetTickersTest()
        {
            var result = MyTokenApi.GetTickers(key);
            Console.WriteLine(result);
        }

        [TestMethod()]
        public void CreateBatchTickersTest()
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
            Console.WriteLine(result);
        }
    }
}