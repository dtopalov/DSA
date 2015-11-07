namespace ArticlesInGivenPriceRange
{
    using System;

    using Wintellect.PowerCollections;

    class CompanyArticlesOperations
    {
        static void Main()
        {
            var products = new OrderedMultiDictionary<decimal, Product>(true);

            Console.Write("Creating and adding products");
            for (int i = 0; i < 1000000; i++)
            {
                products.Add(
                    (i + 1) % 50 + (decimal)i / 100,
                    new Product(
                    "Product #" + (i + 1),
                    ((i + 1) % 50 + (decimal)i / 100),
                    "Vendor#" + i % 50000,
                    null));
                if (i % 1000 == 0)
                {
                    Console.Write(".");
                }
            }

            Console.WriteLine();

            var productsInPricerangeFrom10To11 = products.Range(10M, true, 11M, true);
            var productsInPricerangeFrom15To25 = products.Range(15M, true, 25M, true);
            var productsInPricerangeFrom30To35 = products.Range(30M, true, 35M, true);

            Console.WriteLine("Products with price between 10 and 11: " + productsInPricerangeFrom10To11.Count);
            Console.WriteLine("Products with price between 15 and 25: " + productsInPricerangeFrom15To25.Count);
            Console.WriteLine("Products with price between 30 and 35: " + productsInPricerangeFrom30To35.Count);
        }
    }
}
