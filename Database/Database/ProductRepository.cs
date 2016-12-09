using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;

namespace Database
{
    public class ProductRepository
    {
        private const string CONN_STRING_KEY = "Northwind";

        public IEnumerable<Product> All()
        {
            var result = MemoryCache.Default.Get("ALL_PRODUCTS") as IEnumerable<Product>;
            if(result == null)
            {
                result = AllFromDatabase();
                MemoryCache.Default.Add("ALL_PRODUCTS", result, DateTime.UtcNow.AddMinutes(10));
            }
            return result;
        }

        public Product ById(int productID)
        {
            using (var connection = Connector.GetOpenConnection(CONN_STRING_KEY))
            {
                string sql = "SELECT ProductID, ProductName, SupplierID, CategoryID, " +
                    "QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued " +
                    "FROM Products " +
                    "WHERE ProductID = @ProductID;";

                return connection.Query<Product>(sql, new { ProductId = productID }).FirstOrDefault();
            }
        }

        public Product Save(Product product)
        {
            if (product.ProductId > 0)
            {
                if (!Update(product))
                {
                    // Failed!
                }
            }
            else
            {
                product = Insert(product);
            }
            return product;
        }

        private IEnumerable<Product> AllFromDatabase()
        {
            using (var connection = Connector.GetOpenConnection(CONN_STRING_KEY))
            {
                string sql = "SELECT ProductID, ProductName, SupplierID, CategoryID, " +
                    "QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued " +
                    "FROM Products;";

                return connection.Query<Product>(sql);
            }
        }

        private Product Insert(Product product)
        {
            using (var connection = Connector.GetOpenConnection(CONN_STRING_KEY))
            {
                string sql = "INSERT INTO Products (ProductName, SupplierID, CategoryID, QuantityPerUnit, " +
                    "UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued) VALUES (" +
                    "@ProductName, @SupplierID, @CategoryID, @QuantityPerUnit, " +
                    "@UnitPrice, @UnitsInStock, @UnitsOnOrder, @ReorderLevel, @Discontinued);" +
                    "SELECT CAST(SCOPE_IDENTITY() AS int)";

                product.ProductId = connection.Query<int>(sql, product).First();
                return product;
            }
        }

        private bool Update(Product product)
        {
            using (var connection = Connector.GetOpenConnection(CONN_STRING_KEY))
            {
                string sql = "UPDATE Products SET " +
                    "ProductName = @ProductName, " +
                    "SupplierID = @SupplierID, " +
                    "CategoryID = @CategoryID, " +
                    "QuantityPerUnit = @QuantityPerUnit, " +
                    "UnitPrice = @UnitPrice, " +
                    "UnitsInStock = @UnitsInStock, " +
                    "UnitsOnOrder = @UnitsOnOrder, " +
                    "ReorderLevel = @ReorderLevel, " +
                    "Discontinued = @Discontinued " +
                    "WHERE ProductID = @ProductID;";

                return connection.Execute(sql, product) > 0;
            }
        }
    }
}
