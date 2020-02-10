using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace PivotPointCalculation
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();
        public static Calculation  test1 = new Calculation();

        static void Main(string[] args)
        {
           
            if (args.Length == 0)
            {
                args = new string[1];
                args[0] = "XBTUSD";
            }

            foreach (var coin in args)
            {
                var data = CandlePrice(coin).Result;
                var price = data[1];

                Console.WriteLine($"Name {coin}");
                Console.WriteLine($"Pivot   point { Math.Round(test1.PivotPoint(price.close, price.high, price.low), 4)}");
                Console.WriteLine($"First   resistance { Math.Round(test1.Resistance(1, price.close, price.high, price.low), 4)}");
                Console.WriteLine($"Second   resistance { Math.Round(test1.Resistance(2, price.close, price.high, price.low), 4)}");
                Console.WriteLine($"Third  resistance { Math.Round(test1.Resistance(3, price.close, price.high, price.low), 4)}");
                Console.WriteLine($"First  support { Math.Round(test1.Support(1, price.close, price.high, price.low), 4)}");
                Console.WriteLine($"Second   support { Math.Round(test1.Support(2, price.close, price.high, price.low), 4)}");
                Console.WriteLine($"Third   support  { Math.Round(test1.Support(3, price.close, price.high, price.low), 4)}");
            }
           

        }

        private static async Task<List<Candle>> CandlePrice(string coin)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var serializer = new DataContractJsonSerializer(typeof(List<Candle>));
            var streamTask = client.GetStreamAsync($"https://www.bitmex.com/api/v1/trade/bucketed?binSize=1d&partial=false&symbol={coin}&count=40&reverse=true");
            var repositories = serializer.ReadObject(await streamTask) as List<Candle>;
            return repositories;
        }
    }
}
