using Microsoft.EntityFrameworkCore;
using OkulYönetim.Entity.concrete;
using OkulYönetim.Entity.EntityFramework.Context.Mapper;
using OkulYönetim.Utilities;

namespace OkulYönetim.Entity.EntityFramework.Context
{
    public class ApplicationDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(localdb)\\mssqllocaldb; database=SchoolDb; Trusted_Connection=True; MultipleActiveResultSets=true");

            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Ders> Dersler { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<UserClass> UserClasses { get; set; }
        public DbSet<UserDers> UserDers { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            byte[] Salt;
            byte[] hash;

            modelBuilder.Entity<UserRole>().HasData(new UserRole
            {
                Id = 4,
                IsActive = true,
                RoleName="Admin",               
            });

            HashingHelper.CreatePasswordHash("Admin123*", out Salt, out hash);
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 10,
                Surname = "AmidnUser",           
                Name = "AmidnUser",
                PasswordSalt = Salt,
                PasswordHash = hash,
                Email="adminuser123@gmail.com",
                Branch="Admin",
                UserRoleId=4,
            });
            
            
            modelBuilder.Entity < User> ()
            .HasIndex(t => t.Email)
            .IsUnique();
            modelBuilder.ApplyConfiguration(new UserMapper());
            base.OnModelCreating(modelBuilder);
        }
    }
}
