using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using StockDI.Data.Concrete;
using StockDI.Data.Interfaces;

namespace StockDI.UI
{
    class Program
    {
        private static IKernel _container;

        static void Main(string[] args)
        {
            ConfigureContainer();

            var symbols = GetStockSymbolsFromUser();

            //var display = _container.Get<StockDisplayer>();
            var display = _container.Get<StockDisplayerMethodInjection>();
            //var display = _container.Get<StockDisplayerPropertyInjection>();

            display.PrintDataFor(symbols);
            Console.ReadLine();
        }

        private static string GetStockSymbolsFromUser()
        {
            Console.Write("Enter a list of stock symbols separated by a space: ");
            return Console.ReadLine();
        }

        private static void ConfigureContainer()
        {
            _container = new StandardKernel();

            _container.Bind<IStockLookup>().To<YahooStockRepository>();
        }
    }
}
