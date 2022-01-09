using Microsoft.EntityFrameworkCore;
using Robust.Domain.Entities;
using Robust.Infra.Mappings;

namespace Robust.Infra.Context
{
    public class RobustContext : DbContext
    {
        public virtual DbSet<User> Users => Set<User>();

        public RobustContext()
        {
        }

        public RobustContext(DbContextOptions<RobustContext> options) : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=db,1433;Database=db;MultipleActiveResultSets=true;User ID=SA;Password=Pass@word");
        //}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserMap());
        }
    }
}
