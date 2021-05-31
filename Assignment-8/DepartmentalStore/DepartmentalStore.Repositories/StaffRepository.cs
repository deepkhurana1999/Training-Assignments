using DepartmentalStore.Data;
using DepartmentalStore.Domain;
using DepartmentalStore.Repositories.core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepartmentalStore.Repositories
{
    public class StaffRepository: GeneralRepository, IStaffRepository
    {
        public StaffRepository(DepartmentalStoreContext _context, ILogger<StaffRepository> logger) : base(_context, logger)
        { }

        private async Task<List<Staff>> FindAll(System.Linq.Expressions.Expression<Func<Staff,bool>> query, bool includeAddress, bool includeDesignation)
        {
            IQueryable<Staff> staffs = _context.Staff.AsNoTracking();

            if (includeAddress)
                staffs = staffs.Include(staff => staff.Address);
            if (includeDesignation)
                staffs = staffs.Include(staff => staff.Designation);

            return await staffs.Where(query).ToListAsync();
        }
        private async Task<Staff> Find(System.Linq.Expressions.Expression<Func<Staff, bool>> query, bool includeAddress, bool includeDesignation)
        {
            IQueryable<Staff> staffs = _context.Staff.AsNoTracking();

            if (includeAddress)
                staffs = staffs.Include(staff => staff.Address);
            if (includeDesignation)
                staffs = staffs.Include(staff => staff.Designation);

            return await staffs.Where(query).FirstOrDefaultAsync();
        }
        public async Task<List<Staff>> GetAllStaffs(bool includeAddress = false, bool includeDesignation = false)
        {
            return await this.FindAll(staff => true, includeAddress, includeDesignation);
        }

        public async Task<List<Staff>> GetStaffByName(string firstName, bool includeAddress = false, bool includeDesignation=false)
        {
            return await this.FindAll(staff => staff.FirstName == firstName, includeAddress, includeDesignation);
        }

        public async Task<Staff> GetStaffByID(int id, bool includeAddress, bool includeDesignation)
        {
            return await this.Find(staff => staff.ID == id, includeAddress, includeDesignation);
        }
    }
}
