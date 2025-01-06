using Geent.Domain.Entidade;
using Geent.Domain.Interface;
using Geent.Infrastructure.ConfigurationDB;
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

        public async Task CreatePost(Post post)
        {
            await _context.Post.AddAsync(post);
            await _context.SaveChangesAsync();

        }
    }
}
