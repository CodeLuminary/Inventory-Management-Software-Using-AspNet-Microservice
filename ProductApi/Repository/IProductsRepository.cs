using ProductApi.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApi.Repository
{
    public interface IProductsRepository
    {
        public Task<List<Products>> GetProductsAsync();
        public Task<List<Products>> addProducts(Products product);
    }
}
