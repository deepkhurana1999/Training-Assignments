using DepartmentalStore.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentalStore.Repositories.core
{
    public interface IStaffRepository: IGeneralRepository
    {
        public Task<List<Staff>> GetAllStaffs(bool includeAddress, bool includeDesignation);
        public Task<List<Staff>> GetStaffByName(string firstName,bool includeAddress, bool includeDesignation);

        public Task<Staff> GetStaffByID(int id, bool includeAddress, bool includeDesignation);
    }
}
