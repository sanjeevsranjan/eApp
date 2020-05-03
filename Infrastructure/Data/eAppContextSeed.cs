using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.Extensions.Logging;
using Core.Entities.OrderAggregate;

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

                if (!context.DeliveryMethods.Any())
                {
                    var dmData =
                    //File.ReadAllText(path + @"/Data/SeedData/delivery.json");
                    File.ReadAllText("C:/Users/sanje/Desktop/Desktop/Projects/eApp/Infrastructure/Data/SeedData/delivery.json");

                    var methods = JsonSerializer.Deserialize<List<DeliveryMethod>>(dmData);

                    foreach (var item in methods)
                    {
                        context.DeliveryMethods.Add(item);
                    }

                    await context.SaveChangesAsync();
                }

                 if (!context.Countries.Any())
                {
                    var countriesData =

                       // File.ReadAllText(path + @"/Data/SeedData/brands.json");
                        File.ReadAllText("C:/Users/sanje/Desktop/Desktop/Projects/eApp/Infrastructure/Data/SeedData/countries.json");

                    var countries = JsonSerializer.Deserialize<List<Country>>(countriesData);

                    foreach (var item in countries)
                    {
                        context.Countries.Add(item);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.States.Any())
                {
                    var statesData =
                        //File.ReadAllText(path + @"/Data/SeedData/types.json");
                        File.ReadAllText("C:/Users/sanje/Desktop/Desktop/Projects/eApp/Infrastructure/Data/SeedData/states.json");
                        

                    var states = JsonSerializer.Deserialize<List<State>>(statesData);

                    foreach (var item in states)
                    {
                        context.States.Add(item);
                    }

                    await context.SaveChangesAsync();
                }
                 if (!context.PricingModels.Any())
                {
                    var priningmodelsData =
                        //File.ReadAllText(path + @"/Data/SeedData/types.json");
                        File.ReadAllText("C:/Users/sanje/Desktop/Desktop/Projects/eApp/Infrastructure/Data/SeedData/pricingmodels.json");
                        

                    var pricingmodels = JsonSerializer.Deserialize<List<PricingModel>>(priningmodelsData);

                    foreach (var item in pricingmodels)
                    {
                        context.PricingModels.Add(item);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.Franchises.Any())
                {
                    var franchisesData =
                       // File.ReadAllText(path + @"/Data/SeedData/products.json");
                       File.ReadAllText("C:/Users/sanje/Desktop/Desktop/Projects/eApp/Infrastructure/Data/SeedData/franchises.json");

                    var franchises = JsonSerializer.Deserialize<List<Franchise>>(franchisesData);

                    foreach (var item in franchises)
                    {
                        context.Franchises.Add(item);
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