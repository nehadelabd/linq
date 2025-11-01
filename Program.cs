using Day_01_G03;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace linq
{
    internal class Program
    {
        private static IEnumerable<object> words;

        static void Main(string[] args)
        {

            #region LINQ - Restriction Operators
            #region 1. Find all products that are out of stock
            //var outOfStock = ListGenerator.ProductsList.Where(p => p.UnitsInStock == 0);

            //foreach (var p in outOfStock)
            //    Console.WriteLine($"- {p.ProductName}");


            //Console.WriteLine(  "?????????");
            #endregion

            #region 2. Find all products that are in stock and cost more than 3.00 per unit.
            //var inStock = ListGenerator.ProductsList.Where(p2=> p2.UnitsInStock >0&& p2.UnitsInStock >3.00);

            //foreach (var p2 in inStock)
            //    Console.WriteLine($"- {p2.ProductName}");

            #endregion
            #region 3. Returns digits whose name is shorter than their value.
            // string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            // var result = Arr
            //.Select((name, index) => new { Name = name, Value = index })
            // .Where(d => d.Name.Length < d.Value)
            // .Select(d => d.Name);


            #endregion






            #endregion

            #region Aggregate Operators
            //      #region 1. Uses Count to get the number of odd numbers in the array
            //      int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            //      int oddCoun = Arr.Count(n => n % 2 != 0);

            //      Console.WriteLine("1. Num of odd numbers in  array: " + oddCoun);

            //      #endregion
            //      #region 2. Return a list of customers and how many orders each has.
            //      var customerOrderCount = ListGenerator. CustomersList.Select(c => new
            //      {
            //          CustomerName = c.CustomerName,
            //          OrderCount = c.Orders.Length
            //      });
            //      foreach (var c in customerOrderCount)
            //          Console.WriteLine($" {c.CustomerName}: {c.OrderCount} orders");


            //      #endregion
            //      #region 3. Return a list of categories and how many products each has

            //      var categoryProductCount = ListGenerator.ProductsList
            //.GroupBy(p => p.Category)
            //.Select(g => new
            //{
            //    Category = g.Key,
            //    ProductCount = g.Count()
            //});

            //      foreach (var c in categoryProductCount)
            //          Console.WriteLine($"{c.Category}: :{c.ProductCount} products");
            //  }
            //  #endregion
            #region 4. Get the total of the numbers in an array.

            int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            int total = Arr.Sum();
            Console.WriteLine($"{total}\n");
            #endregion
            #region   5.Get the total number of characters of all words in dictionary_english.txt(Read dictionary_english.txt into Array of String First).
            //int totalChars = 0;
            //foreach (string word in words)
            //{
            //    totalChars += word.Length;
            //}

            //Console.WriteLine($"characters in dictionary = {totalChars}");

            #endregion
            #region 6. Get the length of the shortest word in dictionary_english.txt (Read dictionary_english.txt into Array of String First).
            //string[] words = File.ReadAllLines("dictionary_english.txt");

            //int shortestLength = words.Min(w => w.Length);
            //Console.WriteLine($" shortest word = {shortestLength}");
            #endregion
            #region 7. Get the length of the longest word in dictionary_english.txt (Read dictionary_english.txt into Array of String First).

            //int longestLength = words.Max(w => w.Length);
            //Console.WriteLine($"{longestLength}");
            #endregion
            #region 8and9and10 
            string[] words = File.ReadAllLines("dictionary_english.txt");
            double averageLength = words.Average(w => w.Length);
            Console.WriteLine($" {averageLength:F2}");
            /////9
            var totalUnitsByCategory = from p in ListGenerator.ProductsList
                                       group p by p.Category into g
                                       select new
                                       {
                                           Category = g.Key,
                                           TotalUnits = g.Sum(p => p.UnitsInStock)
                                       };

            foreach (var item in totalUnitsByCategory)
            {
                Console.WriteLine($" {item.Category} → Total Units: {item.TotalUnits}");
            }
            ////10
            ///


            var cheapestPriceByCategory = from p in ListGenerator.ProductsList
                                          group p by p.Category into g
                                          select new
                                          {
                                              Category = g.Key,
                                              CheapestPrice = g.Min(p => p.UnitPrice)
                                          };

            foreach (var item in cheapestPriceByCategory)
            {
                Console.WriteLine($"10. {item.Category} → Cheapest Price: {item.CheapestPrice}");
            }
            #endregion
            #region 11

            ////11
            ///
            var cheapestProductsByCategory = from p in ListGenerator.ProductsList
                                             group p by p.Category into g
                                             let minPrice = g.Min(p => p.UnitPrice)
                                             from prod in g
                                             where prod.UnitPrice == minPrice
                                             select new
                                             {
                                                 Category = g.Key,
                                                 ProductName = prod.ProductName,
                                                 Price = prod.UnitPrice
                                             };

            foreach (var item in cheapestProductsByCategory)
            {
                Console.WriteLine($"11. {item.Category} → {item.ProductName} (${item.Price})");
            }
            #endregion
            #region 12
            var mostExpensivePriceByCategory = from p in ListGenerator.ProductsList
                                               group p by p.Category into g
                                               select new
                                               {
                                                   Category = g.Key,
                                                   MostExpensivePrice = g.Max(p => p.UnitPrice)
                                               };

            foreach (var item in mostExpensivePriceByCategory)
            {
                Console.WriteLine($"12. {item.Category} → Most Expensive Price: {item.MostExpensivePrice}");
            }
            #endregion
            #region 13
            var mostExpensiveProductsByCategory = from p in ListGenerator.ProductsList
                                                  group p by p.Category into g
                                                  let maxPrice = g.Max(p => p.UnitPrice)
                                                  from prod in g
                                                  where prod.UnitPrice == maxPrice
                                                  select new
                                                  {
                                                      Category = g.Key,
                                                      ProductName = prod.ProductName,
                                                      Price = prod.UnitPrice
                                                  };

            foreach (var item in mostExpensiveProductsByCategory)
            {
                Console.WriteLine($"13. {item.Category} → {item.ProductName} (${item.Price})");
            }
            #endregion
            #region 14
            var avgPriceByCategory = from p in ListGenerator.ProductsList
                                     group p by p.Category into g
                                     select new
                                     {
                                         Category = g.Key,
                                         AveragePrice = g.Average(p => p.UnitPrice)
                                     };

            foreach (var item in avgPriceByCategory)
            {
                Console.WriteLine($"14. {item.Category} → Average Price: {item.AveragePrice:F2}");
            }

            #endregion


            #endregion

            #region Element Operators
            //1
            var firstOutOfStock = ListGenerator.ProductsList.FirstOrDefault(p => p.UnitsInStock == 0);

            if (firstOutOfStock != null)
                Console.WriteLine($"out-of-stock product: {firstOutOfStock.ProductName}");
            else
                Console.WriteLine("no out of stock.");



            //2
            var expensiveProduct = ListGenerator.ProductsList.FirstOrDefault(p => p.UnitPrice > 1000);

            if (expensiveProduct != null)
                Console.WriteLine($"First product with Price > 1000: {expensiveProduct.ProductName} (${expensiveProduct.UnitPrice})");
            else
                Console.WriteLine(" No product found with Price > 1000.");




            //3

            //int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            //int? secondGreaterThan5 = Arr.Where(n => n > 5).Skip(1).FirstOrDefault();

            //if (secondGreaterThan5 != 0)
            //    Console.WriteLine($"Second number greater than 5 = {secondGreaterThan5}");
            //else
            //    Console.WriteLine(" No second number greater than 5 ");
            #endregion




        }
    }   } 
