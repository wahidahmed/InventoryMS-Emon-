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
    public class CatagoryService: ICatagoryService
    {
        private readonly AppDbContext _context;

        public CatagoryService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> DeleteById(int id)
        {
            _context.Catagories.Remove(_context.Catagories.Find(id));
            return 1 == await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Catagory>> GetAll()
        {
            return await _context.Catagories.AsNoTracking().ToListAsync();
        }

        public async Task<Catagory> GetById(int id)
        {
            return await _context.Catagories.Where(x => x.ID == id).FirstOrDefaultAsync();
        }

        public async Task<int> Save(Catagory entity)
        {
            if (entity.ID != 0)
                _context.Catagories.Update(entity);
            else
                _context.Catagories.Add(entity);
            await _context.SaveChangesAsync();
            return entity.ID;
        }
    }
}
