using Day_01_G03;

namespace linq
{
    internal class Program
    {

        static void Main(string[] args)
        {

            #region LINQ - Restriction Operators
            #region 1. Find all products that are out of stock
            var outOfStock = ListGenerator.ProductsList.Where(p => p.UnitsInStock == 0);

            foreach (var p in outOfStock)
                Console.WriteLine($"- {p.ProductName}");


            Console.WriteLine(  "?????????");
            #endregion

            #region 2. Find all products that are in stock and cost more than 3.00 per unit.
            var inStock = ListGenerator.ProductsList.Where(p2=> p2.UnitsInStock >0&& p2.UnitsInStock >3.00);

            foreach (var p2 in inStock)
                Console.WriteLine($"- {p2.ProductName}");

            #endregion
            #region 3. Returns digits whose name is shorter than their value.
            string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };


            #endregion






            #endregion
        }
    }
}
