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
    public class ProductSaleMasterService: IProductSaleMasterService
    {
        private readonly AppDbContext _context;

        public ProductSaleMasterService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> DeleteById(int id)
        {
            _context.ProductSaleMaster.Remove(_context.ProductSaleMaster.Find(id));
            return 1 == await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductSaleMaster>> GetAll()
        {
            return await _context.ProductSaleMaster.AsNoTracking().ToListAsync();
        }

        public async Task<ProductSaleMaster> GetById(int id)
        {
            return await _context.ProductSaleMaster.Where(x => x.ID == id).FirstOrDefaultAsync();
        }

        public async Task<int> Save(ProductSaleMaster entity)
        {
            if (entity.ID != 0)
                _context.ProductSaleMaster.Update(entity);
            else
                _context.ProductSaleMaster.Add(entity);
            await _context.SaveChangesAsync();
            return entity.ID;
        }
    }
}
