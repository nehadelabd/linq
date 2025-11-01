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

            #region Ordering Operators






            //1

            //var q1 = ListGenerator.ProductsList.OrderBy(p => p.ProductName);
            //    foreach (var p in q1) Console.WriteLine($"1. {p.ProductName}");
            //    //2
            //    string[] Arr1 = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            //    var q2 = Arr1.OrderBy(w => w, StringComparer.OrdinalIgnoreCase);
            //    Console.WriteLine("2. " + string.Join(", ", q2));
            ////3
            //    var q3 = ListGenerator.ProductsList.OrderByDescending(p => p.UnitsInStock);
            //    foreach (var p in q3) Console.WriteLine($"3. {p.ProductName} ({p.UnitsInStock})");
            //    //4
            //    string[] Arr2 = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            //    var q4 = Arr2.OrderBy(w => w.Length).ThenBy(w => w);
            //    Console.WriteLine("4. " + string.Join(", ", q4));



            //string[] Arr1 = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            //var q5 = Arr1.OrderBy(w => w.Length).ThenBy(w => w, StringComparer.OrdinalIgnoreCase);
            //Console.WriteLine("5. " + string.Join(", ", q5));

            //var q6 = ListGenerator.ProductsList.OrderBy(p => p.Category).ThenByDescending(p => p.UnitPrice);
            //foreach (var p in q6) Console.WriteLine($"6. {p.Category} - {p.ProductName} ({p.UnitPrice})");

            //string[] Arr2 = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            //var q7 = Arr2.OrderBy(w => w.Length).ThenByDescending(w => w, StringComparer.OrdinalIgnoreCase);
            //Console.WriteLine("7. " + string.Join(", ", q7));

            //string[] Arr3 = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            //var q8 = Arr3.Where(w => w.Length > 1 && w[1] == 'i').Reverse();
            //Console.WriteLine("8. " + string.Join(", ", q8));
            #endregion

            #region Transformation Operators
            //var q1 = products.Select(p => p.Name);
            //Console.WriteLine("1. " + string.Join(", ", q1));

            //string[] words = { "aPPLE", "BlUeBeRrY", "cHeRry" };
            //var q2 = words.Select(w => new { Upper = w.ToUpper(), Lower = w.ToLower() });
            //Console.WriteLine("2.");
            //foreach (var w in q2) Console.WriteLine($"Upper: {w.Upper}, Lower: {w.Lower}");

            //var q3 = products.Select(p => new { p.Name, p.Category, Price = p.UnitPrice });
            //Console.WriteLine("3.");
            //foreach (var p in q3) Console.WriteLine($"{p.Name} ({p.Category}) - {p.Price}");

            //int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            //var q4 = Arr.Select((n, i) => new { Number = n, InPlace = (n == i) });
            //Console.WriteLine("4.");
            //foreach (var item in q4) Console.WriteLine($"Num: {item.Number}, Index: {item.InPlace}");

            //int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            //int[] numbersB = { 1, 3, 5, 7, 8 };
            //var q5 = from a in numbersA
            //         from b in numbersB
            //         where a < b
            //         select new { A = a, B = b };
            //Console.WriteLine("5.");
            //foreach (var pair in q5) Console.WriteLine($"{pair.A} is less than {pair.B}");

            //var q6 = orders.Where(o => o.Total < 500);
            //Console.WriteLine("6.");
            //foreach (var o in q6) Console.WriteLine($"Order {o.OrderID} - Total: {o.Total}");

            //var q7 = orders.Where(o => o.OrderDate.Year >= 1998);
            //Console.WriteLine("7.");
            //foreach (var o in q7) Console.WriteLine($"Order {o.OrderID} - Date: {o.OrderDate.ToShortDateString()}");
            #endregion

            #region Set Operators
            var q1 = ListGenerator.ProductsList.Select(p => p.Category).Distinct();
            Console.WriteLine("1. " + string.Join(", ", q1));

            var q2 = ListGenerator.ProductsList.Select(p => p.ProductName[0])
                             .Union(ListGenerator.CustomersList.Select(c => c.CustomerName[0]))
                             .Distinct();
            Console.WriteLine("2. " + string.Join(", ", q2));

            var q3 = ListGenerator.ProductsList.Select(p => p.ProductName[0])
                             .Intersect(ListGenerator.CustomersList.Select(c => c.CustomerName[0]));
            Console.WriteLine("3. " + string.Join(", ", q3));

            var q4 = ListGenerator.ProductsList.Select(p => p.ProductName[0])
                             .Except(ListGenerator.CustomersList.Select(c => c.CustomerName[0]));
            Console.WriteLine("4. " + string.Join(", ", q4));

            var q5 = ListGenerator.ProductsList.Select(p => p.ProductName.Length >= 3 ? p.ProductName.Substring(p.ProductName.Length - 3) : p.ProductName)
                             .Concat(ListGenerator.CustomersList.Select(c => c.CustomerName.Length >= 3 ? c.CustomerName.Substring(c.CustomerName.Length - 3) : c.CustomerName));
            Console.WriteLine("5. " + string.Join(", ", q5));
            #endregion
            #region Partitioning Operators
            var q1 = ListGenerator.CustomersList.Where(o => o.CustomerID== "WA").Take(3);
            Console.WriteLine("1. " + string.Join(", ", q1.Select(o => $"Order {Customer.ReferenceEquals }")));

            var q2 = orders.Where(o => o.CustomerState == "WA").Skip(2);
            Console.WriteLine("2. " + string.Join(", ", q2.Select(o => $"Order {Customer.ReferenceEquals}")));

            int[] numbers1 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var q3 = numbers1.TakeWhile((n, i) => n >= i);
            Console.WriteLine("3. " + string.Join(", ", q3));

            int[] numbers2 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var q4 = numbers2.SkipWhile(n => n % 3 != 0);
            Console.WriteLine("4. " + string.Join(", ", q4));

            int[] numbers3 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var q5 = numbers3.SkipWhile((n, i) => n >= i);
            Console.WriteLine("5. " + string.Join(", ", q5));
            #endregion


        }
    }   } 
