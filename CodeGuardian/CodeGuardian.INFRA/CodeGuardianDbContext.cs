using CodeGuardian.DOMAINE.Entity;
using Microsoft.EntityFrameworkCore;


namespace CodeGuardian.INFRA
{
    public class CodeGuardianDbContext : DbContext
    {
        public CodeGuardianDbContext(DbContextOptions<CodeGuardianDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        public DbSet<Application> Applications { get; set; }
        public DbSet<License> Licenses { get; set; }
        public DbSet<UserPermission> UserPermissions { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Administrator> Administrators { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Application table
            modelBuilder.Entity<Application>().HasKey(k => k.Id);
            modelBuilder.Entity<Application>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Application>()
                .Property(p => p.Name)
                .IsRequired();
            modelBuilder.Entity<Application>()
                .Property(p => p.Description)
                .IsRequired();

            // License table
            modelBuilder.Entity<License>().HasKey(k => k.Id);
            modelBuilder.Entity<License>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<License>()
                .Property(p => p.ApplicationId)
                .IsRequired();
            modelBuilder.Entity<License>()
                .HasOne(l => l.Application)
                .WithMany(a => a.Licenses)
                .HasForeignKey(l => l.ApplicationId);

            // User table
            modelBuilder.Entity<User>().HasKey(k => k.Id);
            modelBuilder.Entity<User>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<User>()
                .Property(p => p.FirstName)
                .IsRequired();
            modelBuilder.Entity<User>()
                .Property(p => p.LastName)
                .IsRequired();
            modelBuilder.Entity<User>()
                .HasMany(u => u.Permissions)
                .WithOne(up => up.User)
                .HasForeignKey(up => up.UserId);

            // Permission table
            modelBuilder.Entity<Permission>().HasKey(k => k.Id);
            modelBuilder.Entity<Permission>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Permission>()
                .Property(p => p.Name)
                .IsRequired();

            // UserPermission table
            modelBuilder.Entity<UserPermission>().HasKey(up => new { up.UserId, up.PermissionId });
            modelBuilder.Entity<UserPermission>()
                .HasOne(up => up.User)
                .WithMany(u => u.Permissions)
                .HasForeignKey(up => up.UserId);
            modelBuilder.Entity<UserPermission>()
                .HasOne(up => up.Permission)
                .WithMany()
                .HasForeignKey(up => up.PermissionId);

            // Administrator table
            modelBuilder.Entity<Administrator>().HasData(
                new Administrator() { Id = 1, FirstName = "Hugo", LastName = "Abric", IsAdmin = true }
            );

            // User table
            modelBuilder.Entity<User>().HasData(
                new User() { Id = 2, FirstName = "userTest", LastName = "ususerTest", IsAdmin = false }
            );

            // Permission table
            modelBuilder.Entity<Permission>().HasData(
                new Permission() { Id = 1, Name = "ViewApplications" },
                new Permission() { Id = 2, Name = "ManageOwnApplications" },
                new Permission() { Id = 3, Name = "ViewLicenses" }
                // ... Ajoutez d'autres permissions
            );

            // UserPermission table
            modelBuilder.Entity<UserPermission>().HasData(
                new UserPermission() { UserId = 2, PermissionId = 1 }, 
                new UserPermission() { UserId = 2, PermissionId = 2 } 
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}

