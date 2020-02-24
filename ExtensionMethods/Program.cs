using System;
using System.Linq;
using LinqAndExtensionMethods;

namespace LinqAndExtensionMethods {
    class Program {
        static void Main(string[] args) {

            Product[] productList = {
                new Product { Code = "Echo", Name = "Amazon Echo", Quantity = 3, Taxible = true },
                new Product { Code = "EchoDot", Name = "Amazon Echo Dot", Quantity = 7, Taxible = true },
                new Product { Code = "EchoShow5", Name = "Amazon Echo Show 5", Quantity = 5, Taxible = true },
                new Product { Code = "3Way", Name = "Skyline 3-Way", Quantity = 2, Taxible = false },
                new Product { Code = "4Way", Name = "Skyline 4-Way", Quantity = 1, Taxible = false },
                new Product { Code = "5Way", Name = "Skyline 5-Way", Quantity = 2, Taxible = false },
                new Product { Code = "5DayClass", Name = "MAX 5 day clas", Quantity = 6, Taxible = true }
            };
            Pricing[] priceList = {
                new Pricing { ProductCode = "Echo", Price = 99.99 },
                new Pricing { ProductCode = "EchoDot", Price = 39.99 },
                new Pricing { ProductCode = "EchoShow5", Price = 119.99 },
                new Pricing { ProductCode = "3Way", Price = 6.99 },
                new Pricing { ProductCode = "4Way", Price = 7.99 },
                new Pricing { ProductCode = "5Way", Price = 8.99 },
                new Pricing { ProductCode = "5DayClass", Price = 2995.00 }
            };

            var ProductsWithPrices = from prod in productList
                                     join pric in priceList
                                     on prod.Code equals pric.ProductCode
                                     select new {
                                         Code = prod.Code,
                                         Name = prod.Name,
                                         Price = pric.Price,
                                         Quanity = prod.Quantity,
                                         Taxible = prod.Taxible,
                                         Total = prod.Quantity * pric.Price
                                     };
            foreach(var p in ProductsWithPrices) {
                Console.WriteLine($"{p.Code} | {p.Name} | {p.Price} | {p.Quanity} | {p.Taxible} | {p.Total}");
            }



            int[] nbrs2 = {
                3524,    7436,    7815,    8881,    4972,    4964,
                5662,    1106,    7676,    1806,    4933,    5317,
                1557,    9323,    4655,    4389,    2562,    8428,
                1925,    1884,    8738,    9403,    5531,    7826,
                3641,    4690,    8722,    1221,    8818,    3267,
                6533,    9993,    3986,    4129,    5338,    8112,
                5077,    8951,    2729,    2115,    3995,    1948,
                2134,    3439,    7144,    4724,    5282,    3323,
                6405,    2733
            };
            var nbrs2Sum = nbrs2.Sum();
            Console.WriteLine($"Sum: {nbrs2Sum}");

            var nbrsSumDivBy3 = nbrs2.Where(n => n % 3 == 0).Sum();
            Console.WriteLine($"Sum: {nbrsSumDivBy3}");

            var nbrsSumDivBy3Ext = from n in nbrs2 // declaring the method will not execute alone
                                   where n % 3 == 0
                                   select n;
            foreach(var n in nbrsSumDivBy3Ext) {
                Console.WriteLine($"{n} ");
            }
            

            var nbrs2Avg = nbrs2.Average();
            Console.WriteLine($"Avg: {nbrs2Avg}");
        }
    }
}
