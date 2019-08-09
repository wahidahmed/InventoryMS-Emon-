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
    public class DistrictService: IDistrictService
    {
        private readonly AppDbContext _context;

        public DistrictService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> DeleteById(int id)
        {
            _context.Districts.Remove(_context.Districts.Find(id));
            return 1 == await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<District>> GetAll()
        {
            return await _context.Districts.AsNoTracking().ToListAsync();
        }

        public async Task<District> GetById(int id)
        {
            return await _context.Districts.Where(x => x.ID == id).FirstOrDefaultAsync();
        }

        public async Task<int> Save(District entity)
        {
            if (entity.ID != 0)
                _context.Districts.Update(entity);
            else
                _context.Districts.Add(entity);
            await _context.SaveChangesAsync();
            return entity.ID;
        }
    }
}
