﻿using InventoryMS.DAL;
using InventoryMS.DAL.Entity;
using InventoryMS.DAL.SqlModel;
using InventoryMS.Services.Master.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryMS.Services.Master
{
    public class ProductStockDetailsService: IProductStockDetailsService
    {
        private readonly AppDbContext _context;

        public ProductStockDetailsService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> DeleteById(int id)
        {
            _context.ProductStockDetails.Remove(_context.ProductStockDetails.Find(id));
            return 1 == await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductStockDetails>> GetAll()
        {
            return await _context.ProductStockDetails.Include(x=>x.Products).AsNoTracking().ToListAsync();
        }

        public async Task<ProductStockDetails> GetById(int id)
        {
            return await _context.ProductStockDetails.Where(x => x.ID == id).FirstOrDefaultAsync();
        }

        public async Task<int> Save(ProductStockDetails entity)
        {
            if (entity.ID != 0)
                _context.ProductStockDetails.Update(entity);
            else
                _context.ProductStockDetails.Add(entity);
            await _context.SaveChangesAsync();
            return entity.ID;
        }

        public async Task<IEnumerable<ProductStockDetails>> GetByProduct(int ?productId)
        {
            return await _context.ProductStockDetails.Where(x=>x.ProductsID== productId).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<ProductDetailsForStock>> GetProductDetailsForStock(int? id)
        {
            return await _context.ProductDetailsForStock.FromSql("Sp_GetProductDetailsForStock @p0",id).ToListAsync();
        }
    }
}
