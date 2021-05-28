using Catalog.API.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Catalog.API.Data
{
    public class CatalogContextSeed
    {
        public static void SeedData(IMongoCollection<Product> productCollection)
        {
            bool existProduct = productCollection.Find(p => true).Any();

            if (!existProduct)
                productCollection.InsertManyAsync(GetPreconfiguredProducts());
        }

        private static IEnumerable<Product> GetPreconfiguredProducts()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Id = Guid.NewGuid().ToString("N"),
                    Name = "Samsung",
                    Summary = "Test",
                    Description = "Mongo test",
                    ImageFile = "product1.png",
                    Price = 873.00M,
                    Category = "Phones"
                },
                new Product()
                {
                    Id = Guid.NewGuid().ToString("N"),
                    Name = "Chair",
                    Summary = "Chair",
                    Description = "Chair test",
                    ImageFile = "product-2.png",
                    Price = 324,
                    Category = "Furniture"
                }
            };
        }
    }
}
