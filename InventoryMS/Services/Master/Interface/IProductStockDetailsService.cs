using InventoryMS.DAL.Entity;
using InventoryMS.DAL.SqlModel;
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

        Task<IEnumerable<ProductStockDetails>> GetByProduct(int? productId);

        Task<IEnumerable<ProductDetailsForStock>> GetProductDetailsForStock(int? id);
    }
}
