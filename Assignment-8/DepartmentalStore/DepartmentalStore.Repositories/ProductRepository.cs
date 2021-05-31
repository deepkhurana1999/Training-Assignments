using DepartmentalStore.Data;
using DepartmentalStore.Domain;
using DepartmentalStore.Repositories.core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentalStore.Repositories
{
    public class ProductRepository : GeneralRepository, IProductRepository
    {
        public ProductRepository(DepartmentalStoreContext _context, ILogger<ProductRepository> logger) : base(_context, logger)
        { }
        private async Task<List<Product>> FindAll(System.Linq.Expressions.Expression<Func<Product, bool>> query, bool includeInventory)
        {
            IQueryable<Product> products = _context.Product.AsNoTracking();

            if (includeInventory)
                products = products.Include(product => product.Inventory);

            return await products.Where(query).ToListAsync();
        }
        private async Task<Product> Find(System.Linq.Expressions.Expression<Func<Product, bool>> query, bool includeInventory)
        {
            IQueryable<Product> products = _context.Product.AsNoTracking();

            if (includeInventory)
                products = products.Include(product => product.Inventory);

            return await products.Where(query).FirstOrDefaultAsync();
        }
        public async Task<List<Product>> GetAllProducts(bool includeInventory = false)
        {
            return await this.FindAll(product => true, includeInventory);
        }

        public async Task<List<Product>> GetProductByName(string name, bool includeInventory = false)
        {
            return await this.FindAll(product => product.Name == name, includeInventory);
        }

        public async Task<Product> GetProductByProductCode(string code, bool includeInventory)
        {
            return await this.Find(product => product.Code.Equals(code), includeInventory);
        }
    }
}
