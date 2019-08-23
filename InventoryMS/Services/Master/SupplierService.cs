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
    public class SupplierService: ISupplierService
    {
        private readonly AppDbContext _context;

        public SupplierService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> DeleteById(int id)
        {
            _context.Suppliers.Remove(_context.Suppliers.Find(id));
            return 1 == await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Supplier>> GetAll()
        {
            return await _context.Suppliers.Include(x=>x.Countries).Include(x => x.Divisions).Include(x => x.Districts).Include(x => x.Thanas).AsNoTracking().ToListAsync();
        }

        public async Task<Supplier> GetById(int id)
        {
            return await _context.Suppliers.Where(x => x.ID == id).FirstOrDefaultAsync();
        }

        public async Task<int> Save(Supplier entity)
        {
            if (entity.ID != 0)
                _context.Suppliers.Update(entity);
            else
                _context.Suppliers.Add(entity);
            await _context.SaveChangesAsync();
            return entity.ID;
        }
    }
}
