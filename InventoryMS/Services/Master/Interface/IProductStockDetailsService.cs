using InventoryMS.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryMS.Services.Master.Interface
{
    public interface IProductStockDetailsService
    {
        Task<int> Save(ProductStockDetails entity);
        Task<IEnumerable<ProductStockDetails>> GetAll();
        Task<ProductStockDetails> GetById(int id);
        Task<bool> DeleteById(int id);
    }
}
