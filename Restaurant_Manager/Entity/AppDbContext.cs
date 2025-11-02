using Microsoft.EntityFrameworkCore;
using Restaurant_Manager.Entity; 

namespace Restaurant_Manager
{
    public class AppDbContext : DbContext
    {
        
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<Table> Tables { get; set; }
        

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Table) 
                .WithMany(t => t.Orders)
                .HasForeignKey(o => o.TableId) 
                .IsRequired();

        }

        
    }
}