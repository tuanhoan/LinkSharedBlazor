using LinkSharedBlazor.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LinkSharedBlazor.Services
{
    public class BaseServices<T> where T:class
    {
        readonly IDbContextFactory<LinkSharedContext> _contextFactory;
        private DbSet<T> _dbset;
        public BaseServices(IDbContextFactory<LinkSharedContext> context)
        {
            _contextFactory = context;
            _dbset = context.CreateDbContext().Set<T>();
        }
        public async Task AddAsync(T entity)
        {
            var _context = _contextFactory.CreateDbContext();
            _dbset.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbset.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int Id)
        {
            return await _dbset.FindAsync(Id);
        } 
        public async Task UpdateAsync(T entity)
        {
            var _context = _contextFactory.CreateDbContext();
            _dbset.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
