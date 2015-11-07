namespace SearchByRange
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Wintellect.PowerCollections;

    class SearchByPriceExample
    {
        static void Main()
        {
            var products = new OrderedBag<Product>();

            for (int i = 0; i < 500000; i++)
            {
                products.Add(new Product("Product #" + (i + 1), ((i + 1) % 50) + (decimal)i / 100));
            }

            var productsWithPrice10to15 = GetProductsByPriceRange(products, 10, 15, 20);
            var productsWithPrice15to20 = GetProductsByPriceRange(products, 15, 20, 20);
            var productsWithPrice20to25 = GetProductsByPriceRange(products, 20, 25, 20);

            Console.WriteLine("First 20 products with prices from 10.00 to 15.00");
            Console.WriteLine(string.Join(Environment.NewLine, productsWithPrice10to15));
            Console.WriteLine("First 20 products with prices from 15.00 to 20.00");
            Console.WriteLine(string.Join(Environment.NewLine, productsWithPrice15to20));
            Console.WriteLine("First 20 products with prices from 20.00 to 25.00");
            Console.WriteLine(string.Join(Environment.NewLine, productsWithPrice20to25));
        }

        static IEnumerable<Product> GetProductsByPriceRange(OrderedBag<Product> products, decimal from, decimal to, int count)
        {
            var result =
                products.Range(
                    products.FirstOrDefault(x => x.Price >= from),
                    true,
                    products.LastOrDefault(x => x.Price <= to),
                    true).Take(count);

            return result;
        }
    }
}
