using Geent.Domain.Entidade;
using Geent.Domain.Interface;
using Geent.Infrastructure.ConfigurationDB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geent.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly PostgresDbContext _context;

        public UserRepository(PostgresDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByEmailAndPasswordAsync(string email, string password)
        {
            return await _context.Users
                .SingleOrDefaultAsync(u => u.Email == email && u.Password == password);
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users
                .SingleOrDefaultAsync(u => u.Email == email);
        }

        public async Task AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

    }

}
