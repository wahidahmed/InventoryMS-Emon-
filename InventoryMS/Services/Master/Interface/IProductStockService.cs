using InventoryMS.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryMS.Services.Master.Interface
{
    public interface IProductStockService
    {
        Task<int> Save(ProductStock entity);
        Task<IEnumerable<ProductStock>> GetAll();
        Task<ProductStock> GetById(int id);
        Task<bool> DeleteById(int id);

        Task<IEnumerable<ProductStock>> GetByProductId(int? productId);
    }
}
