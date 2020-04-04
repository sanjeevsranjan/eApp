using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
   public class eAppContextSeed
    {
        public static async Task SeedAsync(eAppContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                if (!context.ProductBrands.Any())
                {
                    var brandsData =
                    
                       // File.ReadAllText(path + @"/Data/SeedData/brands.json");
                        File.ReadAllText("C:/Users/sanje/Desktop/Desktop/Projects/eApp/Infrastructure/Data/SeedData/brands.json");

                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                    foreach (var item in brands)
                    {
                        context.ProductBrands.Add(item);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.ProductTypes.Any())
                {
                    var typesData =
                        //File.ReadAllText(path + @"/Data/SeedData/types.json");
                        File.ReadAllText("C:/Users/sanje/Desktop/Desktop/Projects/eApp/Infrastructure/Data/SeedData/types.json");
                        

                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);

                    foreach (var item in types)
                    {
                        context.ProductTypes.Add(item);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.Products.Any())
                {
                    var productsData =
                       // File.ReadAllText(path + @"/Data/SeedData/products.json");
                       File.ReadAllText("C:/Users/sanje/Desktop/Desktop/Projects/eApp/Infrastructure/Data/SeedData/products.json");

                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                    foreach (var item in products)
                    {
                        context.Products.Add(item);
                    }

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<eAppContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}