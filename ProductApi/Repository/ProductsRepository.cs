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
                //Add products here
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
