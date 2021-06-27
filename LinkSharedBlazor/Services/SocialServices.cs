using LinkSharedBlazor.Data;
using LinkSharedBlazor.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkSharedBlazor.Services
{
    public class SocialServices
    {
        private readonly LinkSharedContext _context;
        public SocialServices(IDbContextFactory<LinkSharedContext> context)
        {
            _context = context.CreateDbContext();
        }
        public async Task AddAsync(Social social)
        {
            _context.Socials.Add(social);
            await _context.SaveChangesAsync();
        }
        public async Task<List<Social>> GetAllAsync()
        {
            return await _context.Socials
                .OrderBy(x=>x.CreatedAt)
                .ToListAsync();
        }
        public async Task<Social> GetByIdAsync(int Id)
        {
            return await _context.Socials.FirstOrDefaultAsync(x => x.Id == Id);
        }
        public async Task UpdateAsync(Social social)
        {
            _context.Socials.Update(social);
            await _context.SaveChangesAsync();
        }
    }
}
