using System.Runtime.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context)
        {
            if(!context.ProductBrands.Any())
            {
                var brandsData = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                var brands = System.Text.Json.JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                context.AddRange(brands);
            }
             if(!context.ProductTypes.Any())
            {
                var typesData = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
                var types = System.Text.Json.JsonSerializer.Deserialize<List<ProductType>>(typesData);
                context.AddRange(types);
            }
             if(!context.Products.Any())
            {
                var productsData = File.ReadAllText("../Infrastructure/Data/SeedData//products.json");
                var products = System.Text.Json.JsonSerializer.Deserialize<List<Product>>(productsData);
                context.AddRange(products);
            }

            if(context.ChangeTracker.HasChanges()) await context.SaveChangesAsync();
        }
    }
}