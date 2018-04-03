using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;


namespace MyToken
{
    public static class MyTokenApi
    {
        static string baseUrl = "http://matrix.beta.mytoken.io/api/v1";
        private static string SendRequest(string url, string httpMethod, string key = null, string body = null)
        {
            HttpWebRequest wr = WebRequest.CreateHttp(url);
            if (key != null) wr.Headers.Add("X-API-key", key);
            wr.Method = httpMethod;
            wr.ContentType = "application/json";
            string response = null;
            try
            {
                if (httpMethod.ToLower() == "post")
                {
                    byte[] btBodys = Encoding.UTF8.GetBytes(body);
                    wr.ContentLength = btBodys.Length;
                    wr.GetRequestStream().Write(btBodys, 0, btBodys.Length);
                }
                HttpWebResponse resp = wr.GetResponse() as HttpWebResponse;
                StreamReader sr = new StreamReader(resp.GetResponseStream());
                response = sr.ReadToEnd();
                sr.Close();
            }
            catch (WebException ex)
            {
                StreamReader sr = new StreamReader(ex.Response.GetResponseStream());
                response = sr.ReadToEnd();
                sr.Close();
                try
                {
                    var e = JsonConvert.DeserializeObject<MyTokenException>(response);
                    return e.Code;
                }
                catch
                {
                    throw new WebException(response, ex);
                }
            }
            return response;
        }
        public static string GetKey()
        {
            string url = $"{baseUrl}/markets";
            var body = new Market()
            {
                Name = "Xbrick_beta",
                Website = "https://www.xbrick.io",
                Contact = "email:support@xbrick.io",
                Description = "XBRICK核心团队成员由曾就职于高盛、ASX澳交所上市公司和澳大利亚著名家族私募集团等知名企业的董事和高管组成，具丰富的国际投行，投融资经验与世界一流企业的管理经验。",
                Logo_url = "https://www.xbrick.io/imgs/logo.svg"
            };
            return SendRequest(url, "post", body: JsonConvert.SerializeObject(body));
        }
        public static string AddToken(string key, Token token)
        {
            string url = $"{baseUrl}/tokens";
            return SendRequest(url, "post", key, JsonConvert.SerializeObject(token));
        }
        public static string GetTokens(string key)
        {
            string url = $"{baseUrl}/tokens";
            return SendRequest(url, "get", key);
        }
        public static string AddTicker(string key, Ticker ticker)
        {
            string url = $"{baseUrl}/tickers";
            return SendRequest(url, "post", key, JsonConvert.SerializeObject(new { ticker }));
        }
        public static string GetTickers(string key)
        {
            string url = $"{baseUrl}/tickers";
            return SendRequest(url, "get", key);
        }
        /// <summary>
        /// 先注册，然后批量更新用
        /// </summary>
        /// <param name="key"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public static string CreateBatchTickers(string key, List<Ticker> list)
        {
            string url = $"{baseUrl}/tickers/batch_create";//
            return SendRequest(url, "post", key, JsonConvert.SerializeObject(new { tickers = list }));
        }

    }

    public class MyTokenException
    {
        [JsonProperty("code")]
        public string Code { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
    }

    public class Token
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("symbol")]
        public string Symbol { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("unique_key")]
        public string UniqueKey { get; set; }
        [JsonProperty("website")]
        public string Website { get; set; }
        [JsonProperty("coinmarketcap_url")]
        public string CoinmarketcapUrl { get; set; }
        [JsonProperty("explorer_url")]
        public string ExplorerUrl { get; set; }
        [JsonProperty("contact_address")]
        public string ContactAddress { get; set; }
        [JsonProperty("twitter")]
        public string Twitter { get; set; }
        [JsonProperty("facebook")]
        public string Facebook { get; set; }
        [JsonProperty("github")]
        public string Github { get; set; }
        [JsonProperty("logo_url")]
        public string LogoUrl { get; set; }
    }

    public class Market
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("website")]
        public string Website { get; set; }
        [JsonProperty("contact")]
        public string Contact { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("logo_url")]
        public string Logo_url { get; set; }
        [JsonProperty("Api_url")]
        public string Api_url { get; set; }
    }
    public class Ticker
    {
        [JsonProperty("symbol_key")]
        public string SymbolKey { get; set; }
        [JsonProperty("symbol_name")]
        public string SymbolName { get; set; }
        [JsonProperty("anchor_key")]
        public string AnchorKey { get; set; }
        [JsonProperty("anchor_name")]
        public string AnchorName { get; set; }
        [JsonProperty("price")]
        public string Price { get; set; }
        [JsonProperty("price_updated_at")]
        public string PriceUpdatedAt { get; set; }
        [JsonProperty("volume_24h")]
        public string Volume24h { get; set; }
        [JsonProperty("volume_anchor_24h")]
        public string VolumeAnchor24h { get; set; }
    }


}
