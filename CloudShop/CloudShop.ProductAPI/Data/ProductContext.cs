using CloudShop.ProductAPI.Models;
using MongoDB.Driver;

namespace CloudShop.ProductAPI.Data
{
    public class ProductContext
    {
        public IMongoCollection<Product> Products { get; }

        public ProductContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["DatabaseSettings:ConnectionString"]);
            var database = client.GetDatabase(configuration["DatabaseSettings:DatabaseName"]);

            Products = database.GetCollection<Product>(configuration["DatabaseSettings:CollectionName"]);
            SeedData(Products);
        }

        private static void SeedData(IMongoCollection<Product> productCollection)
        {
            bool existProduct = productCollection.Find(p => true).Any();

            if (!existProduct)
                productCollection.InsertMany(GetPreconfiguredProducts());
        }

        private static IEnumerable<Product> GetPreconfiguredProducts()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Name = "IPhone X",
                    Description =
                        "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageFile = "https://cloudshop.blob.core.windows.net/product/IPhone-X.jpg?sv=2022-11-02&ss=b&srt=o&sp=r&se=2024-02-07T23:36:28Z&st=2024-02-07T15:36:28Z&spr=https&sig=G9jpkMoxtjEmh%2F41bO%2BCjDfFG%2BuVc4GYoUJ%2F4KQB0vw%3D",
                    Price = 950.00M,
                    Category = "Smart Phone"
                },
                new Product()
                {
                    Name = "Samsung 10",
                    Description =
                        "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageFile = "https://cloudshop.blob.core.windows.net/product/Samsung-10.jpg?sv=2022-11-02&ss=b&srt=o&sp=r&se=2024-02-07T23:36:28Z&st=2024-02-07T15:36:28Z&spr=https&sig=G9jpkMoxtjEmh%2F41bO%2BCjDfFG%2BuVc4GYoUJ%2F4KQB0vw%3D",
                    Price = 840.00M,
                    Category = "Smart Phone"
                },
                new Product()
                {
                    Name = "Huawei Plus",
                    Description =
                        "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageFile = "https://cloudshop.blob.core.windows.net/product/Huawei-Plus.jpg?sv=2022-11-02&ss=b&srt=o&sp=r&se=2024-02-07T23:36:28Z&st=2024-02-07T15:36:28Z&spr=https&sig=G9jpkMoxtjEmh%2F41bO%2BCjDfFG%2BuVc4GYoUJ%2F4KQB0vw%3D",
                    Price = 650.00M,
                    Category = "White Appliances"
                },
                new Product()
                {
                    Name = "Xiaomi Mi 9",
                    Description =
                        "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageFile = "https://cloudshop.blob.core.windows.net/product/Xiaomi-Mi-9.jpg?sv=2022-11-02&ss=b&srt=o&sp=r&se=2024-02-07T23:36:28Z&st=2024-02-07T15:36:28Z&spr=https&sig=G9jpkMoxtjEmh%2F41bO%2BCjDfFG%2BuVc4GYoUJ%2F4KQB0vw%3D",
                    Price = 470.00M,
                    Category = "White Appliances"
                },
                new Product()
                {
                    Name = "HTC U11+ Plus",
                    Description =
                        "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageFile = "https://cloudshop.blob.core.windows.net/product/HTC-U1-Plus.jpg?sv=2022-11-02&ss=b&srt=o&sp=r&se=2024-02-07T23:36:28Z&st=2024-02-07T15:36:28Z&spr=https&sig=G9jpkMoxtjEmh%2F41bO%2BCjDfFG%2BuVc4GYoUJ%2F4KQB0vw%3D",
                    Price = 380.00M,
                    Category = "Smart Phone"
                },
                new Product()
                {
                    Name = "LG G7 ThinQ New8",
                    Description =
                        "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageFile = "https://cloudshop.blob.core.windows.net/product/LG-G7-ThinQ-New8.jpg?sv=2022-11-02&ss=b&srt=o&sp=r&se=2024-02-07T23:36:28Z&st=2024-02-07T15:36:28Z&spr=https&sig=G9jpkMoxtjEmh%2F41bO%2BCjDfFG%2BuVc4GYoUJ%2F4KQB0vw%3D",
                    Price = 240.00M,
                    Category = "Home Kitchen"
                }
            };
        }
    }
}
