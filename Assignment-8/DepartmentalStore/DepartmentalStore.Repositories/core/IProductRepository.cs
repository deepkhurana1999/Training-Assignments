using DepartmentalStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentalStore.Repositories.core
{
    public interface IProductRepository: IGeneralRepository
    {
        public Task<List<Product>> GetAllProducts(bool includeInventory);
        public Task<List<Product>> GetProductByName(string firstName, bool includeInventory);
        public Task<Product> GetProductByProductCode(string code, bool includeInventory);
    }
}
