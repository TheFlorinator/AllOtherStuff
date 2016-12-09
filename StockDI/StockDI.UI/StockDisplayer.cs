using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using StockDI.Data.Interfaces;

namespace StockDI.UI
{
    // this is the dependent object
    public class StockDisplayer
    {
        private IStockLookup _stockLookup;

        // constructor injection
        public StockDisplayer(IStockLookup lookup)
        {
            _stockLookup = lookup;
        }

        public void PrintDataFor(string symbols)
        {
            var stockData = _stockLookup.GetStockInformation(symbols);

            Console.WriteLine("\nStock Data");
            Console.WriteLine("-----------------------------------------------------");

            foreach (var stock in stockData)
            {
                Console.WriteLine("{0}, {1}, {2:c}", stock.Symbol, stock.CompanyName, stock.StockPrice);
            }
        }
    }

    // this is the dependent object
    public class StockDisplayerMethodInjection
    {
        private IStockLookup _stockLookup;

        // method injection
        [Inject]
        public void SetStockLookup(IStockLookup lookup)
        {
            _stockLookup = lookup;
        }

        public void PrintDataFor(string symbols)
        {
            var stockData = _stockLookup.GetStockInformation(symbols);

            Console.WriteLine("\nStock Data");
            Console.WriteLine("-----------------------------------------------------");

            foreach (var stock in stockData)
            {
                Console.WriteLine("{0}, {1}, {2:c}", stock.Symbol, stock.CompanyName, stock.StockPrice);
            }
        }
    }

    // this is the dependent object
    public class StockDisplayerPropertyInjection
    {
        // method injection
        [Inject]
        public IStockLookup StockLookup { get; set; }

        public void PrintDataFor(string symbols)
        {
            var stockData = StockLookup.GetStockInformation(symbols);

            Console.WriteLine("\nStock Data");
            Console.WriteLine("-----------------------------------------------------");

            foreach (var stock in stockData)
            {
                Console.WriteLine("{0}, {1}, {2:c}", stock.Symbol, stock.CompanyName, stock.StockPrice);
            }
        }
    }
}
