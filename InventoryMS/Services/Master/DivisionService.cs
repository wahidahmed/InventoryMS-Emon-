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
    public class DivisionService: IDivisionService
    {
        private readonly AppDbContext _context;

        public DivisionService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> DeleteById(int id)
        {
            _context.Divisions.Remove(_context.Divisions.Find(id));
            return 1 == await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Division>> GetAll()
        {
            return await _context.Divisions.AsNoTracking().ToListAsync();
        }

        public async Task<Division> GetById(int id)
        {
            return await _context.Divisions.Where(x => x.ID == id).FirstOrDefaultAsync();
        }

        public async Task<int> Save(Division entity)
        {
            if (entity.ID != 0)
                _context.Divisions.Update(entity);
            else
                _context.Divisions.Add(entity);
            await _context.SaveChangesAsync();
            return entity.ID;
        }
    }
}
