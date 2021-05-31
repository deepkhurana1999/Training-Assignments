using DepartmentalStore.Data;
using DepartmentalStore.Domain;
using DepartmentalStore.Repositories.core;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentalStore.Repositories
{
    public class GeneralRepository : IGeneralRepository
    {
        protected readonly DepartmentalStoreContext _context;
        protected readonly ILogger<GeneralRepository> _logger;

        public GeneralRepository(DepartmentalStoreContext context, ILogger<GeneralRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void Add<T>(T item) where T : class
        {
            _context.Add(item);
        }

        public void Delete<T>(T item) where T : class
        {
            _context.Remove(item);
            
        }
        public EntityEntry<T> Update<T>(T item) where T : class
        {
            return _context.Update(item);

        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
