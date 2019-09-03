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
    public class ProductStockService: IProductStockService
    {
        private readonly AppDbContext _context;

        public ProductStockService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> DeleteById(int id)
        {
            _context.ProductStock.Remove(_context.ProductStock.Find(id));
            return 1 == await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductStock>> GetAll()
        {
            return await _context.ProductStock.Include(x=>x.Products).AsNoTracking().ToListAsync();
        }

        public async Task<ProductStock> GetById(int id)
        {
            return await _context.ProductStock.Where(x => x.ID == id).FirstOrDefaultAsync();
        }

        public async Task<int> Save(ProductStock entity)
        {
            if (entity.ID != 0)
                _context.ProductStock.Update(entity);
            else
                _context.ProductStock.Add(entity);
            await _context.SaveChangesAsync();
            return entity.ID;
        }

        public async Task<IEnumerable<ProductStock>> GetByProductId(int? productId)
        {
            return await _context.ProductStock.Where(x => x.ProductsID == productId).AsNoTracking().ToListAsync();
        }
    }
}
