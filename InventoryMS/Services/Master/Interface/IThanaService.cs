using InventoryMS.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryMS.Services.Master.Interface
{
    public interface IThanaService
    {
        Task<int> Save(Thana entity);
        Task<IEnumerable<Thana>> GetAll();
        Task<Thana> GetById(int id);
        Task<bool> DeleteById(int id);
    }
}
