using ProductApi.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApi.Repository
{
    public class ProductsRepository : IProductsRepository
    {
        DatabaseContext dbContext; //Declare a DatabaseContext object
        //ProductsRepository Constructor for injecting DatabaseContext object
        public ProductsRepository(DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
            seedDatabase();
        }
        public void seedDatabase()
        {
            if (!dbContext.products.Any())
            {
                //Add products
                dbContext.products.Add(new Products() {
                    productName = "Chocolatee",
                    productQuantity = 10,
                    costPrice = 200.0,
                    sellingPrice = 250.0,
                    productDescription = "This is just for testing"
                });
                dbContext.products.Add(new Products()
                {
                    productName = "Milk",
                    productQuantity = 30,
                    costPrice = 300.0,
                    sellingPrice = 450.0,
                    productDescription = "This is just for testing tooo"
                });
                dbContext.SaveChanges();
            }
        }
        public async Task<List<Products>> addProducts(Products product)
        {
            dbContext.products.Add(product);
            await dbContext.SaveChangesAsync();
            return await GetProductsAsync();
        }

        public Task<List<Products>> GetProductsAsync()
        {
            return Task.Run(()=>dbContext.products.ToList());
            /*You can also use
             return await dbContext.products.ToListAsync(); and add async to the function
             */
        }
    }
}
