using LinkSharedBlazor.Data;
using LinkSharedBlazor.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkSharedBlazor.Services
{
    public class UserServices
    {
        private readonly LinkSharedContext _context; 
        public UserServices(IDbContextFactory<LinkSharedContext> context)
        {
            _context = context.CreateDbContext(); 
        }
        public async Task AddAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }
        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        } 
    }
}
