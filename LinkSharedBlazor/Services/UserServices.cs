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
        private readonly LinkSharedContext _context;
        readonly AuthenticationStateProvider _authenticationStateProvider;
        public UserServices(IDbContextFactory<LinkSharedContext> context,
            AuthenticationStateProvider authenticationStateProvider)
        {
            _context = context.CreateDbContext();
            _authenticationStateProvider = authenticationStateProvider;
        }
        public string GetCurrentUserEmail()
        {
            var authState = _authenticationStateProvider.GetAuthenticationStateAsync();
            return authState.Result.User.FindFirst(ClaimTypes.Email)?.Value;
        }
        public User GetCurrentEmployee()
        {
            var email = GetCurrentUserEmail(); 
            return _context.Users.FirstOrDefault(f => f.Email == email);
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
