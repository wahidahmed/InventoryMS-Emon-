using InventoryMS.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryMS.Services.Master.Interface
{
    public interface IProductSaleMasterService
    {
        Task<int> Save(ProductSaleMaster entity);
        Task<IEnumerable<ProductSaleMaster>> GetAll();
        Task<ProductSaleMaster> GetById(int id);
        Task<bool> DeleteById(int id);
    }
}
