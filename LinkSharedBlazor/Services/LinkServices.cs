using LinkSharedBlazor.Data;
using LinkSharedBlazor.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkSharedBlazor.Services
{
    public class LinkServices
    {
        private readonly LinkSharedContext _context;
        public LinkServices(IDbContextFactory<LinkSharedContext> context)
        {
            _context = context.CreateDbContext();
        }
        public async Task<List<Link>> GetAllAsync()
        {
            return await _context.Links
                .Include(x=>x.SocialNavigation)
                .Include(x=>x.UserNavigation)
                .ToListAsync();
        }
        public async Task<List<Link>> GetByUserIdAsync(Guid userId)
        {
            return await _context.Links
                .Include(x => x.SocialNavigation)
                .Include(x => x.UserNavigation) 
                .Where(x => x.UserId == userId)
                .ToListAsync();
        }
        public async Task AddAsync(Link link)
        {
            _context.Links.Add(link);
            await _context.SaveChangesAsync();
            _context.Entry(link).Reference(r => r.SocialNavigation).Load();
            _context.Entry(link).Reference(r => r.UserNavigation).Load();
        }
        public async Task UpdateAsync(Link link)
        {
            _context.Links.Update(link);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int socialId, Guid userId)
        {
            _context.Remove(_context.Links.FirstOrDefault(x => x.SocialId == socialId && x.UserId == userId));
            await _context.SaveChangesAsync();
        }
    }
}
