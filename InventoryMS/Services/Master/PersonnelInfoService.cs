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
    public class PersonnelInfoService: IPersonnelInfoService
    {
        private readonly AppDbContext _context;

        public PersonnelInfoService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> DeleteById(int id)
        {
            _context.PersonnelInfo.Remove(_context.PersonnelInfo.Find(id));
            return 1 == await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<PersonnelInfo>> GetAll()
        {
            return await _context.PersonnelInfo.AsNoTracking().ToListAsync();
        }

        public async Task<PersonnelInfo> GetById(int id)
        {
            return await _context.PersonnelInfo.Where(x => x.ID == id).FirstOrDefaultAsync();
        }

        public async Task<int> Save(PersonnelInfo entity)
        {
            if (entity.ID != 0)
                _context.PersonnelInfo.Update(entity);
            else
                _context.PersonnelInfo.Add(entity);
            await _context.SaveChangesAsync();
            return entity.ID;
        }
    }
}
