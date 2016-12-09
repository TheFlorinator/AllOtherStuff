using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using StockDI.Data.Interfaces;
using StockDI.Data.Models;

namespace StockDI.Data.Concrete
{
    public class YahooStockRepository : IStockLookup
    {
        public List<StockLookupResult> GetStockInformation(string symbols)
        {
            var results = new List<StockLookupResult>();

            string url = "http://finance.yahoo.com/d/quotes.csv?s=" + symbols.Replace(' ', '+') + "&f=sna";

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

            StreamReader sr = new StreamReader(resp.GetResponseStream());
            string data = sr.ReadToEnd();
            sr.Close();

            string[] lines = data.Split('\n');
            foreach (var line in lines)
            {
                if (line.Length > 0)
                {
                    var lineData = line.Split(',');

                    try
                    {
                        results.Add(new StockLookupResult
                        {
                            Symbol = lineData[0],
                            CompanyName = lineData[1],
                            StockPrice = decimal.Parse(lineData[2])
                        });
                    }
                    catch
                    {
                        Console.WriteLine("Error loading symbol: {0}", lineData[0]);
                    }                    
                }
            }

            return results;
        }
    }
}
