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
    public class ThanaService: IThanaService
    {
        private readonly AppDbContext _context;

        public ThanaService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> DeleteById(int id)
        {
            _context.Thanas.Remove(_context.Thanas.Find(id));
            return 1 == await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Thana>> GetAll()
        {
            return await _context.Thanas.AsNoTracking().ToListAsync();
        }

        public async Task<Thana> GetById(int id)
        {
            return await _context.Thanas.Where(x => x.ID == id).FirstOrDefaultAsync();
        }

        public async Task<int> Save(Thana entity)
        {
            if (entity.ID != 0)
                _context.Thanas.Update(entity);
            else
                _context.Thanas.Add(entity);
            await _context.SaveChangesAsync();
            return entity.ID;
        }
    }
}
