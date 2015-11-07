namespace ArticlesInGivenPriceRange
{
    using System;
    public class Product : IComparable<Product>
    {
        public Product(string title, decimal price, string vendor, byte[] barcode)
        {
            this.Title = title;
            this.Price = price;
            this.Vendor = vendor;
            this.Barcode = barcode;
        }

        public byte[] Barcode { get; set; }

        public string Vendor { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public int CompareTo(Product other)
        {
            return this.Price.CompareTo(other.Price);
        }
    }
}
