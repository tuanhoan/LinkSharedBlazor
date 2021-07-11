using LinkSharedBlazor.Data;
using LinkSharedBlazor.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LinkSharedBlazor.Services
{
    public class UserServices
    {
        private readonly IDbContextFactory<LinkSharedContext> _context;
        readonly AuthenticationStateProvider _authenticationStateProvider;
        public UserServices(IDbContextFactory<LinkSharedContext> context,
            AuthenticationStateProvider authenticationStateProvider)
        {
            _context = context;
            _authenticationStateProvider = authenticationStateProvider;
        }
        public string GetCurrentUserEmail()
        { 
            var authState = _authenticationStateProvider.GetAuthenticationStateAsync();
            return authState.Result.User.FindFirst(ClaimTypes.Email)?.Value;
        }
        public User GetCurrentEmployee()
        {
            var context = _context.CreateDbContext();
            var email = GetCurrentUserEmail(); 
            return context.Users.FirstOrDefault(f => f.Email == email);
        }
        public async Task AddAsync(User user)
        {
            var context = _context.CreateDbContext();
            context.Users.Add(user);
            await context.SaveChangesAsync();
        }
        public async Task<List<User>> GetAllAsync()
        {
            var context = _context.CreateDbContext();
            return await context.Users.ToListAsync();
        } 
        public async Task UpdateAsync(User user)
        {
            var context = _context.CreateDbContext();
            context.Users.Update(user);
            await context.SaveChangesAsync();
        }
    }
}
