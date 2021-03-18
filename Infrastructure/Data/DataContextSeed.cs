using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class DataContextSeed
    {
        public static async Task SeedAsync(DataContext context, ILoggerFactory loggerFactory)
        {
             try
            {
                if (!context.ProductBrands.Any())
                {
                    var brandsData = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");

                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                    foreach (var item in brands)
                    {
                        context.ProductBrands.Add(item);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.ProductTypes.Any())
                {
                    var typesData = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");

                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);

                    foreach (var item in types)
                    {
                        context.ProductTypes.Add(item);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.Products.Any())
                {
                    var productsData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");

                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                    foreach (var item in products)
                    {
                        context.Products.Add(item);
                    }

                    await context.SaveChangesAsync();
                }

                            if (!context.IngredientCategory.Any())
            {
                var categories = new List<IngredientCategory>()
                {
                    new IngredientCategory() { Name = "Other" },
                    new IngredientCategory() { Name = "Nuts And Oilseeds" },
                    new IngredientCategory() { Name = "Sugar" },
                    new IngredientCategory() { Name = "Seafood" },
                    new IngredientCategory() { Name = "Fruits" },
                    new IngredientCategory() { Name = "Dairy Products" },
                    new IngredientCategory() { Name = "Meat" },
                    new IngredientCategory() { Name = "Careals And Pulses" },
                    new IngredientCategory() { Name = "Spices And Herbs" },
                    new IngredientCategory() { Name = "Vegetables" },
                };

                foreach (var category in categories)
				{
					context.IngredientCategory.Add(category);
				}
				await context.SaveChangesAsync();
            }


            // if (!context.Ingredients.Any())
            // {
            //     var categoryMeat = context.IngredientCategory.Local.Where(a => a.Name == "Meat").First();
            //     var categoryVegetables = context.IngredientCategory.Local.Where(a => a.Name == "Vegetables").First();
            //     var categorySpicesAndHerbs = context.IngredientCategory.Local.Where(a => a.Name == "Spices And Herbs").First();
            //     var categoryCarealsAndPulses = context.IngredientCategory.Local.Where(a => a.Name == "Careals And Pulses").First();
            //     var categoryDairyProducts = context.IngredientCategory.Local.Where(a => a.Name == "Dairy Products").First();
            //     var categoryFruits = context.IngredientCategory.Local.Where(a => a.Name == "Fruits").First();
            //     var categorySeafood = context.IngredientCategory.Local.Where(a => a.Name == "Seafood").First();
            //     var categorySugar = context.IngredientCategory.Local.Where(a => a.Name == "Sugar").First();
            //     var categoryNuts = context.IngredientCategory.Local.Where(a => a.Name == "Nuts And Oilseeds").First();
            //     var categoryOther = context.IngredientCategory.Local.Where(a => a.Name == "Other").First();

            //     var ingredients = new List<Ingredient>()
            //     {
            //                 new Ingredient() { Name = "Tomato", IngredientCategory = categoryVegetables },
            //                 new Ingredient() { Name = "Turnip", IngredientCategory = categoryVegetables },
            //                 new Ingredient() { Name = "Spinach", IngredientCategory = categoryVegetables },
            //                 new Ingredient() { Name = "Onion", IngredientCategory = categoryVegetables },
            //                 new Ingredient() { Name = "Mushroom", IngredientCategory = categoryVegetables },
            //                 new Ingredient() { Name = "Garlic", IngredientCategory = categoryVegetables },
            //                 new Ingredient() { Name = "Cucumber", IngredientCategory = categoryVegetables },
            //                 new Ingredient() { Name = "Carrot", IngredientCategory = categoryVegetables },
            //                 new Ingredient() { Name = "Broccoli", IngredientCategory = categoryVegetables },
            //                 new Ingredient() { Name = "Rosemary", IngredientCategory = categorySpicesAndHerbs },
            //                 new Ingredient() { Name = "Salt", IngredientCategory = categorySpicesAndHerbs },
            //                 new Ingredient() { Name = "Pepper", IngredientCategory = categorySpicesAndHerbs },
            //                 new Ingredient() { Name = "Mint Leaves", IngredientCategory = categorySpicesAndHerbs },
            //                 new Ingredient() { Name = "Saffron", IngredientCategory = categorySpicesAndHerbs },
            //                 new Ingredient() { Name = "Flour", IngredientCategory = categoryCarealsAndPulses },
            //                 new Ingredient() { Name = "Oats", IngredientCategory = categoryCarealsAndPulses },
            //                 new Ingredient() { Name = "Beef", IngredientCategory = categoryMeat },
            //                 new Ingredient() { Name = "Chicken", IngredientCategory = categoryMeat },
            //                 new Ingredient() { Name = "Turkey", IngredientCategory = categoryMeat },
            //                 new Ingredient() { Name = "Ham", IngredientCategory = categoryMeat },
            //                 new Ingredient() { Name = "Lamb", IngredientCategory = categoryMeat },
            //                 new Ingredient() { Name = "Milk", IngredientCategory = categoryDairyProducts },
            //                 new Ingredient() { Name = "Ricotta Cheese", IngredientCategory = categoryDairyProducts },
            //                 new Ingredient() { Name = "Yogurt", IngredientCategory = categoryDairyProducts },
            //                 new Ingredient() { Name = "Mango", IngredientCategory = categoryFruits },
            //                 new Ingredient() { Name = "Strawberry", IngredientCategory = categoryFruits },
            //                 new Ingredient() { Name = "Papaya", IngredientCategory = categoryFruits },
            //                 new Ingredient() { Name = "Shark", IngredientCategory = categorySeafood },
            //                 new Ingredient() { Name = "Tuna", IngredientCategory = categorySeafood },
            //                 new Ingredient() { Name = "Brown Sugar", IngredientCategory = categorySugar },
            //                 new Ingredient() { Name = "Caramel", IngredientCategory = categorySugar },
            //                 new Ingredient() { Name = "Pine Nuts", IngredientCategory = categoryNuts },
            //                 new Ingredient() { Name = "Cashew Nuts", IngredientCategory = categoryNuts },
            //                 new Ingredient() { Name = "Red Wine", IngredientCategory = categoryOther },
            //                 new Ingredient() { Name = "Pasta", IngredientCategory = categoryOther },
            //                 new Ingredient() { Name = "Jelly", IngredientCategory = categoryOther },
            //     };

            //     foreach (var ingredient in ingredients)
			// 	{
			// 		context.Ingredients.Add(ingredient);
			// 	}
			// 	await context.SaveChangesAsync();
            // }

            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<DataContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}