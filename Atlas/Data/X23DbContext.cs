using Microsoft.EntityFrameworkCore;
using Atlas.Data;

namespace Atlas.Data
{
    public class X23DbContext: DbContext
    {
        public X23DbContext(DbContextOptions<X23DbContext> opts): base(opts)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(X23DbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
        
        public DbSet<Venues> Venues { get; set; }
        public DbSet<Atlas.Data.Events> Events { get; set; } = default!;
        public DbSet<Atlas.Data.Artists> Artists { get; set; } = default!;
    
    }
}

