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
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Table)
                .WithMany(t => t.Orders)
                .HasForeignKey(o => o.TableId)
                .IsRequired();

            modelBuilder.Entity<User>()
                .HasOne<Role>()
                .WithMany()
                .HasForeignKey(u => u.RoleId)
                .IsRequired();

            modelBuilder.Entity<Order>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(o => o.UserId)
                .IsRequired();

            modelBuilder.Entity<Shift>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(s => s.UserId)
                .IsRequired();

            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<Role>().HasKey(r => r.Id);
            modelBuilder.Entity<MenuItem>().HasKey(m => m.Id);
            modelBuilder.Entity<Order>().HasKey(o => o.Id);
            modelBuilder.Entity<Table>().HasKey(t => t.Id);
            modelBuilder.Entity<Shift>().HasKey(s => s.Id);

            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Адміністратор" },
                new Role { Id = 2, Name = "Менеджер" },
                new Role { Id = 3, Name = "Офіціант" },
                new Role { Id = 4, Name = "Кухар" },
                new Role { Id = 5, Name = "Бармен" },
                new Role { Id = 6, Name = "Клієнт" }
           );
        }
    }
}