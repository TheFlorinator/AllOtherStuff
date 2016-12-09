using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Linq.Data;
using Linq.Models;

namespace Linq.Exercises
{
    /// <summary>
    /// Only change the methods--not the string constants.
    /// </summary>
    public static class Exercise
    {
        /// <summary>
        /// Print all products.
        /// </summary>
        public static List<Product> Example1()
        {
            return DataLoader.LoadProducts();
        }

        /// <summary>
        /// Print all numbers in NumbersA.
        /// </summary>
        public static List<int> Example2()
        {
            return DataLoader.NumbersA.ToList();
        }

        /// <summary>
        /// Print all products that are out of stock without using Linq.
        /// </summary>
        public static List<Product> Exercise1WithoutLinq()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Print all products that are out of stock.
        /// </summary>
        public static List<Product> Exercise1()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Print all products that are in stock and cost more than 3.00 per unit.
        /// </summary>
        public static List<Product> Exercise2()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Print all customer and their order information for the Washington (WA) region.
        /// </summary>
        public static List<Customer> Exercise3()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Create and print an anonymous type with just the ProductName
        /// </summary>
        public static StringBuilder Exercise4()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Create and print an anonymous type of all product information but increase the unit price by 25%
        /// </summary>
        public static StringBuilder Exercise5()
        {
            const string exercise5Format = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6}";

            throw new NotImplementedException();
        }

        /// <summary>
        /// Create and print an anonymous type of only ProductName and Category with all the letters in upper case
        /// </summary>
        public static StringBuilder Exercise6()
        {
            const string exercise6Format = "{0,-35} {1,-15}";

            throw new NotImplementedException();
        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra bool property ReOrder which should 
        /// be set to true if the Units in Stock is less than 3. Hint: use a ternary expression.
        /// </summary>
        public static StringBuilder Exercise7()
        {
            const string exercise7Format = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6} {5}";
            throw new NotImplementedException();
        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra decimal called 
        /// StockValue which should be the product of unit price and units in stock
        /// </summary>
        public static StringBuilder Exercise8()
        {
            const string exercise8Format = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6} {5}";
            throw new NotImplementedException();
        }

        /// <summary>
        /// Print only the even numbers in NumbersA
        /// </summary>
        public static List<int> Exercise9()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Print only customers that have an order whose total is less than $500
        /// </summary>
        public static List<Customer> Exercise10()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Print only the first 3 odd numbers from NumbersC
        /// </summary>
        public static List<int> Exercise11()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Print the numbers from NumbersB except the first 3 without using Linq.
        /// </summary>
        public static List<int> Exercise12WithoutLinq()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Print the numbers from NumbersB except the first 3
        /// </summary>
        public static List<int> Exercise12()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Print the Company Name and most recent order for each customer in Washington
        /// </summary>
        public static StringBuilder Exercise13()
        {
            const string exercise13Format = "{0,-35} {1,-15} {2} {3}";

            throw new NotImplementedException();
        }

        /// <summary>
        /// Print all the numbers in NumbersC until a number is >= 6 without using Linq.
        /// </summary>
        public static List<int> Exercise14WithoutLinq()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Print all the numbers in NumbersC until a number is >= 6
        /// </summary>
        public static List<int> Exercise14()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Print all the numbers in NumbersC that come after the first number divisible by 3 without using Linq.
        /// </summary>
        public static List<int> Exercise15WithoutLinq()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Print all the numbers in NumbersC that come after the first number divisible by 3
        /// </summary>
        public static List<int> Exercise15()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Print the products alphabetically by name without using Linq.
        /// </summary>
        public static List<Product> Exercise16WithoutLinq()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Print the products alphabetically by name
        /// </summary>
        public static List<Product> Exercise16()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Print the products in descending order by units in stock without using Linq.
        /// </summary>
        public static List<Product> Exercise17WithoutLinq()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Print the products in descending order by units in stock
        /// </summary>
        public static List<Product> Exercise17()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Print the list of products ordered first by category, then by unit price, from highest to lowest without using Linq.
        /// </summary>
        public static List<Product> Exercise18WithoutLinq()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Print the list of products ordered first by category, then by unit price, from highest to lowest.
        /// </summary>
        public static List<Product> Exercise18()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Print NumbersB in reverse order without using Linq.
        /// </summary>
        public static List<int> Exercise19WithoutLinq()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Print NumbersB in reverse order
        /// </summary>
        public static List<int> Exercise19()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Group products by category, then print each category name and its products
        /// ex:
        /// 
        /// Beverages
        /// Tea
        /// Coffee
        /// 
        /// Sandwiches
        /// Turkey
        /// Ham
        /// </summary>
        public static StringBuilder Exercise20()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Print all Customers with their orders by Year then Month
        /// ex:
        /// 
        /// Joe's Diner
        /// 2015
        ///     1 -  $500.00
        ///     3 -  $750.00
        /// 2016
        ///     2 - $1000.00
        /// </summary>
        public static StringBuilder Exercise21()
        {
            const string exercise21FormatPerMonth = "\t{0} -  {1:C2}";

            throw new NotImplementedException();
        }

        /// <summary>
        /// Print the unique list of product categories without using Linq.
        /// </summary>
        public static List<string> Exercise22WithoutLinq()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Print the unique list of product categories
        /// </summary>
        public static List<string> Exercise22()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Write code to check to see if Product 789 exists without using Linq.
        /// </summary>
        public static bool Exercise23WithoutLinq()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Write code to check to see if Product 789 exists
        /// </summary>
        public static bool Exercise23()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Print a list of categories that have at least one product out of stock
        /// </summary>
        public static List<string> Exercise24()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Print a list of categories that have no products out of stock
        /// </summary>
        public static List<string> Exercise25()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Count the number of odd numbers in NumbersA without using Linq.
        /// </summary>
        public static int Exercise26WithoutLinq()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Count the number of odd numbers in NumbersA
        /// </summary>
        public static int Exercise26()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Create and print an anonymous type containing CustomerId and the count of their orders
        /// </summary>
        public static StringBuilder Exercise27()
        {
            const string exercise27Format = "{0} - {1}";
            throw new NotImplementedException();
        }

        /// <summary>
        /// Print a distinct list of product categories and the count of the products they contain
        /// </summary>
        public static StringBuilder Exercise28()
        {
            const string exercise28Format = "{0} - {1}";
            throw new NotImplementedException();
        }

        /// <summary>
        /// Print a distinct list of product categories and the total units in stock
        /// </summary>
        public static StringBuilder Exercise29()
        {
            const string exercise29Format = "{0} - {1}";
            throw new NotImplementedException();
        }

        /// <summary>
        /// Print a distinct list of product categories and the lowest priced product in that category
        /// </summary>
        public static StringBuilder Exercise30()
        {
            const string exercise30Format = "{0} - {1}";
            throw new NotImplementedException();
        }

        /// <summary>
        /// Print the top 3 categories by the average unit price of their products
        /// </summary>
        public static StringBuilder Exercise31()
        {
            const string exercise31Format = "{0} - {1}";
            throw new NotImplementedException();
        }
    }
}
