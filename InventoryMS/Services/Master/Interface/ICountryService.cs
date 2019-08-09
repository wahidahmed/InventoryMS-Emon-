using InventoryMS.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryMS.Services.Master.Interface
{
    public interface ICountryService
    {
        Task<int> Save(Country entity);
        Task<IEnumerable<Country>> GetAll();
        Task<Country> GetById(int id);
        Task<bool> DeleteById(int id);
    }
}
