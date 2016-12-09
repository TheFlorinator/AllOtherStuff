using System.Collections.Generic;
using StockDI.Data.Models;

namespace StockDI.Data.Interfaces
{
    public interface IStockLookup
    {
        List<StockLookupResult> GetStockInformation(string symbols);
    }
}
