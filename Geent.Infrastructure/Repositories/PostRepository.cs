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
    public class PostRepository : IPostRepository
    {
        private readonly PostgresDbContext _context;

        public PostRepository(PostgresDbContext context)
        {
            _context = context;
        }

        public async Task CreateItem(Item post)
        {
            await _context.Items.AddAsync(post);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteItem(int id)
        {
            var item = await _context.Items.FirstOrDefaultAsync(c => c.Id == id);
             _context.Items.Remove(item);
        }

        public async Task<List<Item>> GetAllItems()
        {
           return await _context.Items.ToListAsync();
        }

        public async  Task<Item> GetById(int id)
        {
            return await _context.Items.FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
