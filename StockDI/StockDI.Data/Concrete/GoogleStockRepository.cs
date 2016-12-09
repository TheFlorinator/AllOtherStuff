using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using StockDI.Data.Interfaces;
using StockDI.Data.Models;

namespace StockDI.Data.Concrete
{
    public class GoogleStockRepository : IStockLookup
    {
        public List<StockLookupResult> GetStockInformation(string symbols)
        {
            var results = new List<StockLookupResult>();

            var allSymbols = symbols.Split(' ');

            foreach (var symbol in allSymbols)
            {
                results.Add(FetchQuote(symbol));
            }

            return results;
        }

        private StockLookupResult FetchQuote(string symbol)
        {
            string url = "http://www.google.com/ig/api?stock=" + symbol;
            XDocument doc = XDocument.Load(url);

            var result = new StockLookupResult();

            result.CompanyName = GetData(doc, "company");
            result.Symbol = GetData(doc, "Symbol");
            result.StockPrice = decimal.Parse(GetData(doc, "last"));

            return result;
        }

        private string GetData(XDocument doc, string name)
        {
            return doc.Root.Element("finance").Element(name).Attribute("data").Value;
        }
    }
}
