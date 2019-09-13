using InventoryMS.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryMS.Services.Master.Interface
{
    public  interface IProductSalesDetailsService
    {
        Task<int> Save(ProductSalesDetails entity);
        Task<IEnumerable<ProductSalesDetails>> GetAll();
        Task<ProductSalesDetails> GetById(int id);
        Task<bool> DeleteById(int id);
    }
}
