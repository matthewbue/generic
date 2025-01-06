using Geent.Domain.Entidade;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geent.Infrastructure.ConfigurationDB
{
    public class PostgresDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        public PostgresDbContext(DbContextOptions<PostgresDbContext> options) : base(options) { }

    }
}
