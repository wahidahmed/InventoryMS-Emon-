using InventoryMS.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryMS.Services.Master.Interface
{
    public interface IPersonnelInfoService
    {
        Task<int> Save(PersonnelInfo entity);
        Task<IEnumerable<PersonnelInfo>> GetAll();
        Task<PersonnelInfo> GetById(int id);
        Task<bool> DeleteById(int id);
    }
}
