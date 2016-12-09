using System;
using System.Collections.Generic;
using StockDI.Data.Interfaces;
using StockDI.Data.Models;

namespace StockDI.Data.Concrete
{
    public class StockTestRepository : IStockLookup
    {
        public List<StockLookupResult> GetStockInformation(string symbols)
        {
            var results = new List<StockLookupResult>();

            var rng = new Random();
            var stockSymbols = symbols.Split(' ');

            foreach (var symbol in stockSymbols)
            {
                results.Add(new StockLookupResult
                {
                    Symbol = symbol,
                    CompanyName = symbol + " Company",
                    StockPrice = rng.Next(1, 400)
                });
            }

            return results;
        }
    }
}
