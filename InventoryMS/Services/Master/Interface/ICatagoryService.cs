using InventoryMS.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryMS.Services.Master.Interface
{
    public interface ICatagoryService
    {
        Task<int> Save(Catagory entity);
        Task<IEnumerable<Catagory>> GetAll();
        Task<Catagory> GetById(int id);
        Task<bool> DeleteById(int id);
    }
}
