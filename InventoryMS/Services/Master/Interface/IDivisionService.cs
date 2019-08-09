using InventoryMS.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryMS.Services.Master.Interface
{
    public interface IDivisionService
    {
        Task<int> Save(Division entity);
        Task<IEnumerable<Division>> GetAll();
        Task<Division> GetById(int id);
        Task<bool> DeleteById(int id);
    }
}
