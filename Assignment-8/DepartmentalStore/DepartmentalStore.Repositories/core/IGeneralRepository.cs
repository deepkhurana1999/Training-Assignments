using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentalStore.Repositories.core
{
    public interface IGeneralRepository
    {
        public void Add<T>(T item) where T:class;
        public void Delete<T>(T item) where T:class;
        public EntityEntry<T> Update<T>(T item) where T : class;
        public Task<bool> SaveChangesAsync();
        
    }
}
