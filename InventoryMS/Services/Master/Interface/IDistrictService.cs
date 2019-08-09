using InventoryMS.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryMS.Services.Master.Interface
{
    public interface IDistrictService
    {
        Task<int> Save(District entity);
        Task<IEnumerable<District>> GetAll();
        Task<District> GetById(int id);
        Task<bool> DeleteById(int id);
    }
}
