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
    public class ProductSalesDetailsService: IProductSalesDetailsService
    {
        private readonly AppDbContext _context;

        public ProductSalesDetailsService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> DeleteById(int id)
        {
            _context.ProductSalesDetails.Remove(_context.ProductSalesDetails.Find(id));
            return 1 == await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductSalesDetails>> GetAll()
        {
            return await _context.ProductSalesDetails.AsNoTracking().ToListAsync();
        }

        public async Task<ProductSalesDetails> GetById(int id)
        {
            return await _context.ProductSalesDetails.Where(x => x.ID == id).FirstOrDefaultAsync();
        }

        public async Task<int> Save(ProductSalesDetails entity)
        {
            if (entity.ID != 0)
                _context.ProductSalesDetails.Update(entity);
            else
                _context.ProductSalesDetails.Add(entity);
            await _context.SaveChangesAsync();
            return entity.ID;
        }
    }
}
