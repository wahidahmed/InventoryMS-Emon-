using InventoryMS.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryMS.Services.Master.Interface
{
    public interface IProductService
    {
        Task<int> Save(Product entity);
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetById(int id);
        Task<bool> DeleteById(int id);
    }
}
