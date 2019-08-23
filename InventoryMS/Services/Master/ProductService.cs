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
    public class ProductService: IProductService
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> DeleteById(int id)
        {
            _context.Products.Remove(_context.Products.Find(id));
            return 1 == await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Products.AsNoTracking().ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            return await _context.Products.Where(x => x.ID == id).FirstOrDefaultAsync();
        }

        public async Task<int> Save(Product entity)
        {
            if (entity.ID != 0)
                _context.Products.Update(entity);
            else
                _context.Products.Add(entity);
            await _context.SaveChangesAsync();
            return entity.ID;
        }

        //public async Task<IEnumerable<Product>> aaa()
        //{
        //    return await _context.Products.Select(x=>new {prod=x.ProductName}).ToListAsync();
        //}
    }
}
