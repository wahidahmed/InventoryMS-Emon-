using InventoryMS.DAL;
using InventoryMS.DAL.Entity;
using InventoryMS.Services.Master.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryMS.Services.Master
{
    public class CountryService: ICountryService
    {
        private readonly AppDbContext _context;

        public CountryService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> DeleteById(int id)
        {
            _context.Countries.Remove(_context.Countries.Find(id));
            return 1 == await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Country>> GetAll()
        {
            return await _context.Countries.AsNoTracking().ToListAsync();
        }

        public async Task<Country> GetById(int id)
        {
            return await _context.Countries.Where(x => x.ID == id).FirstOrDefaultAsync();
        }

        public async Task<int> Save(Country entity)
        {
            if (entity.ID != 0)
                _context.Countries.Update(entity);
            else
                _context.Countries.Add(entity);
            await _context.SaveChangesAsync();
            return entity.ID;
        }
    }
}
