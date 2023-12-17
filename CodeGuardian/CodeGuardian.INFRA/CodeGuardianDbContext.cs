using CodeGuardian.DOMAIN.Entity.Application;
using CodeGuardian.DOMAIN.Entity.Client.OrganisationEntity;
using CodeGuardian.DOMAIN.Entity.Client.PowerUser;
using CodeGuardian.DOMAIN.Entity.Users.Admin;
using CodeGuardian.DOMAIN.Entity.Users.Dev;
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
        public DbSet<ApplicationLicences> ApplicationLicences { get; set; }

        public DbSet<License> Licenses { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Administrator> Administrators { get; set; }

        public DbSet<Dev> Users { get; set; }
        public DbSet<DevPermission> UserPermissions { get; set; }

        public DbSet<PowerUser> PowerUsers { get; set; }
        public DbSet<PowerUserAdmins> PowerUsersAdmins { get; set; }
        public DbSet<PowerUserDevs> PowerUsersDevs { get; set; }

        public DbSet<PowerUserApplication> PowerUsersApplications { get; set; }

        public DbSet<Organisation> Organisations { get; set; }
        public DbSet<OrganisationAdmin> OrganisationAdmin { get; set; }
        public DbSet<OrganisationApplication> OrganisationApplication { get; set; }
        public DbSet<OrganisationDevs> OrganisationDevs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Organisation table
            modelBuilder.Entity<Application>().HasKey(k => k.Id);
            modelBuilder.Entity<Application>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Application>()
                .Property(p => p.Uuid)
                .IsRequired();
            modelBuilder.Entity<Application>()
                .Property(p => p.Name)
                .IsRequired();
            modelBuilder.Entity<Application>()
                .Property(p => p.Description)
                .IsRequired();
            modelBuilder.Entity<Application>()
                .HasMany(u => u.ApplicationLicences)
                .WithOne(up => up.Application)
                .HasForeignKey(up => up.ApplicationId);

            // ApplicationLicences table
            modelBuilder.Entity<ApplicationLicences>().HasKey(up => new { up.ApplicationId, up.LicenceID });
            modelBuilder.Entity<ApplicationLicences>()
                .HasOne(up => up.Application)
                .WithMany(u => u.ApplicationLicences)
                .HasForeignKey(up => up.ApplicationId);
            modelBuilder.Entity<ApplicationLicences>()
                .Property(p => p.ApplicationId)
                .IsRequired();
            modelBuilder.Entity<ApplicationLicences>()
                .HasOne(up => up.Application)
                .WithMany()
                .HasForeignKey(up => up.LicenceID);

            // Organisation table
            modelBuilder.Entity<Organisation>().HasKey(k => k.Id);
            modelBuilder.Entity<Organisation>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Organisation>()
                .Property(p => p.Uuid)
                .IsRequired();
            modelBuilder.Entity<Organisation>()
                .Property(p => p.FirstName)
                .IsRequired();
            modelBuilder.Entity<Organisation>()
                .Property(p => p.LastName)
                .IsRequired();
            modelBuilder.Entity<Organisation>()
                .Property(p => p.email)
                .IsRequired();
            modelBuilder.Entity<Organisation>()
                .Property(p => p.phoneNumber)
                .IsRequired();
            modelBuilder.Entity<Organisation>()
                .Property(p => p.country)
                .IsRequired();
            modelBuilder.Entity<Organisation>()
                .HasMany(u => u.OrganisationAdmins)
                .WithOne(up => up.Organisation)
                .HasForeignKey(up => up.OrganisationId);
            modelBuilder.Entity<Organisation>()
                .HasMany(u => u.OrganisationApplications)
                .WithOne(up => up.Organisation)
                .HasForeignKey(up => up.OrganisationId);
            modelBuilder.Entity<Organisation>()
                .HasMany(u => u.OrganisationDevs)
                .WithOne(up => up.Organisation)
                .HasForeignKey(up => up.OrganisationId);

            // OrganisationAdmin table
            modelBuilder.Entity<OrganisationAdmin>().HasKey(up => new { up.OrganisationId, up.AdminId });
            modelBuilder.Entity<OrganisationAdmin>()
                .HasOne(up => up.Organisation)
                .WithMany(u => u.OrganisationAdmins)
                .HasForeignKey(up => up.OrganisationId);
            modelBuilder.Entity<OrganisationAdmin>()
                .Property(p => p.OrganisationId)
                .IsRequired();
            modelBuilder.Entity<OrganisationAdmin>()
                .HasOne(up => up.Admin)
                .WithMany()
                .HasForeignKey(up => up.AdminId);

            // PowerUserAdmin table
            modelBuilder.Entity<OrganisationApplication>().HasKey(up => new { up.OrganisationId, up.ApplicationId });
            modelBuilder.Entity<OrganisationApplication>()
                .HasOne(up => up.Organisation)
                .WithMany(u => u.OrganisationApplications)
                .HasForeignKey(up => up.OrganisationId);
            modelBuilder.Entity<OrganisationApplication>()
                .Property(p => p.OrganisationId)
                .IsRequired();
            modelBuilder.Entity<OrganisationApplication>()
                .HasOne(up => up.Application)
                .WithMany()
                .HasForeignKey(up => up.ApplicationId);

            // PowerUserAdmin table
            modelBuilder.Entity<OrganisationDevs>().HasKey(up => new { up.OrganisationId, up.DevelopperId });
            modelBuilder.Entity<OrganisationDevs>()
                .HasOne(up => up.Organisation)
                .WithMany(u => u.OrganisationDevs)
                .HasForeignKey(up => up.OrganisationId);
            modelBuilder.Entity<OrganisationDevs>()
                .Property(p => p.OrganisationId)
                .IsRequired();
            modelBuilder.Entity<OrganisationDevs>()
                .HasOne(up => up.Developper)
                .WithMany()
                .HasForeignKey(up => up.DevelopperId);

            // PowerUser table
            modelBuilder.Entity<PowerUser>().HasKey(k => k.Id);
            modelBuilder.Entity<PowerUser>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<PowerUser>()
                .Property(p => p.Uuid)
                .IsRequired();
            modelBuilder.Entity<PowerUser>()
                .Property(p => p.FirstName)
                .IsRequired();
            modelBuilder.Entity<PowerUser>()
                .Property(p => p.LastName)
                .IsRequired();
            modelBuilder.Entity<PowerUser>()
                .Property(p => p.email)
                .IsRequired();
            modelBuilder.Entity<PowerUser>()
                .Property(p => p.phoneNumber)
                .IsRequired();
            modelBuilder.Entity<PowerUser>()
                .Property(p => p.country)
                .IsRequired();
            modelBuilder.Entity<PowerUser>()
                .HasMany(u => u.PowerUserAdmins)
                .WithOne(up => up.Poweruser)
                .HasForeignKey(up => up.PowerUserId);
            modelBuilder.Entity<PowerUser>()
                .HasMany(u => u.PowerUserApplications)
                .WithOne(up => up.PowerUser)
                .HasForeignKey(up => up.PowerUserId);
            modelBuilder.Entity<PowerUser>()
                .HasMany(u => u.PowerUserDevs)
                .WithOne(up => up.Poweruser)
                .HasForeignKey(up => up.PowerUserId);

            // PowerUserAdmin table
            modelBuilder.Entity<PowerUserAdmins>().HasKey(up => new { up.PowerUserId, up.AdmininistatorId });
            modelBuilder.Entity<PowerUserAdmins>()
                .HasOne(up => up.Poweruser)
                .WithMany(u => u.PowerUserAdmins)
                .HasForeignKey(up => up.PowerUserId);
            modelBuilder.Entity<PowerUserAdmins>()
                .Property(p => p.PowerUserId)
                .IsRequired();
            modelBuilder.Entity<PowerUserAdmins>()
                .HasOne(up => up.Admininistrator)
                .WithMany()
                .HasForeignKey(up => up.AdmininistatorId);

            // PowerUserAdmin table
            modelBuilder.Entity<PowerUserApplication>().HasKey(up => new { up.PowerUserId, up.ApplicationId });
            modelBuilder.Entity<PowerUserApplication>()
                .HasOne(up => up.PowerUser)
                .WithMany(u => u.PowerUserApplications)
                .HasForeignKey(up => up.PowerUserId);
            modelBuilder.Entity<PowerUserApplication>()
                .Property(p => p.PowerUserId)
                .IsRequired();
            modelBuilder.Entity<PowerUserApplication>()
                .HasOne(up => up.Application)
                .WithMany()
                .HasForeignKey(up => up.ApplicationId);

            // PowerUserAdmin table
            modelBuilder.Entity<PowerUserDevs>().HasKey(up => new { up.PowerUserId, up.DevelopperId });
            modelBuilder.Entity<PowerUserDevs>()
                .HasOne(up => up.Poweruser)
                .WithMany(u => u.PowerUserDevs)
                .HasForeignKey(up => up.PowerUserId);
            modelBuilder.Entity<PowerUserDevs>()
                .Property(p => p.PowerUserId)
                .IsRequired();
            modelBuilder.Entity<PowerUserDevs>()
                .HasOne(up => up.Developper)
                .WithMany()
                .HasForeignKey(up => up.DevelopperId);

            // License table
            modelBuilder.Entity<License>().HasKey(k => k.Id);
            modelBuilder.Entity<License>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<License>()
                .Property(p => p.Uuid);
            modelBuilder.Entity<License>()
                .Property(p => p.ApplicationId)
                .IsRequired();

            // Dev table
            modelBuilder.Entity<Dev>().HasKey(k => k.Id);
            modelBuilder.Entity<Dev>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Dev>()
                .Property(p => p.Uuid)
                .IsRequired();
            modelBuilder.Entity<Dev>()
                .Property(p => p.FirstName)
                .IsRequired();
            modelBuilder.Entity<Dev>()
                .Property(p => p.LastName)
                .IsRequired();
            modelBuilder.Entity<Dev>()
                .HasMany(u => u.Permissions)
                .WithOne(up => up.Dev)
                .HasForeignKey(up => up.DevId);

            // DevPermission table
            modelBuilder.Entity<DevPermission>().HasKey(up => new { up.DevId, up.PermissionId });
            modelBuilder.Entity<DevPermission>()
                .HasOne(up => up.Dev)
                .WithMany(u => u.Permissions)
                .HasForeignKey(up => up.DevId);
            modelBuilder.Entity<DevPermission>()
                .Property(p => p.DevPermissionUuid)
                .IsRequired();
            modelBuilder.Entity<DevPermission>()
                .Property(p => p.DevId)
                .IsRequired();
            modelBuilder.Entity<DevPermission>()
                .HasOne(up => up.Permission)
                .WithMany()
                .HasForeignKey(up => up.PermissionId);

            // Permission table
            modelBuilder.Entity<Permission>().HasKey(k => k.Id);
            modelBuilder.Entity<Permission>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Permission>()
                .Property(p => p.Uuid)
                .IsRequired();
            modelBuilder.Entity<Permission>()
                .Property(p => p.Name)
                .IsRequired();

            // Administrator table
            modelBuilder.Entity<Administrator>().HasData(
                new Administrator() { Id = 1, FirstName = "Hugo", LastName = "Abric" }
            );

            // Dev table
            modelBuilder.Entity<Dev>().HasData(
                new Dev() { Id = 2, FirstName = "devtest", LastName = "devtest" }
            );

            // Permission table
            modelBuilder.Entity<Permission>().HasData(
                new Permission() { Id = 1, Name = "ViewApplications" },
                new Permission() { Id = 2, Name = "ManageOwnApplications" },
                new Permission() { Id = 3, Name = "ViewLicenses" },
                new Permission() { Id = 4, Name = "ManageLicenses" },
                new Permission() { Id = 5, Name = "CreateApplications" },
                new Permission() { Id = 6, Name = "EditApplications" },
                new Permission() { Id = 7, Name = "DeleteApplications" },
                new Permission() { Id = 8, Name = "ManageUsers" },
                new Permission() { Id = 9, Name = "ViewDashboard" },
                new Permission() { Id = 10, Name = "ManageSettings" }
            );

            // DevPermission table
            modelBuilder.Entity<DevPermission>().HasData(
                new DevPermission() { DevId = 2, PermissionId = 1 },
                new DevPermission() { DevId = 2, PermissionId = 2 }
            );

            // Application table
            modelBuilder.Entity<Application>().HasData(
                new Application() { Id = 1, Name = "App1", Description = "Description1" },
                new Application() { Id = 2, Name = "App2", Description = "Description2" }
            );

            // Licence table
            modelBuilder.Entity<License>().HasData(
                new License() { Id = 1, ApplicationId = 1, KeyHash = "LicenseKey1" },
                new License() { Id = 2, ApplicationId = 1, KeyHash = "LicenseKey2" }
            );

            //// ApplicationLicences table
            //modelBuilder.Entity<ApplicationLicences>().HasData(
            //    new ApplicationLicences() { ApplicationId = 1, LicenceID = 1 },
            //    new ApplicationLicences() { ApplicationId = 1, LicenceID = 2 }
            //);

            // OrganisationAdmin table
            modelBuilder.Entity<OrganisationAdmin>().HasData(
                new OrganisationAdmin() { AdminId = 1, OrganisationId = 1 },
                new OrganisationAdmin() { AdminId = 1, OrganisationId = 2 }
            );

            // Organisation table
            modelBuilder.Entity<Organisation>().HasData(
                new Organisation() { Id = 1, FirstName = "Org1", LastName = "Org1", email = "org1@example.com", phoneNumber = "123456789", country = "Country1" },
                new Organisation() { Id = 2, FirstName = "Org2", LastName = "Org2", email = "org2@example.com", phoneNumber = "987654321", country = "Country2" }
            );

            // OrganisationApplication table
            modelBuilder.Entity<OrganisationApplication>().HasData(
                new OrganisationApplication() { OrganisationId = 1, ApplicationId = 1 },
                new OrganisationApplication() { OrganisationId = 2, ApplicationId = 2 }
            );

            // PowerUser table
            modelBuilder.Entity<PowerUser>().HasData(
                new PowerUser() { Id = 1, FirstName = "PowerUser1", LastName = "PowerUser1", email = "poweruser1@example.com", phoneNumber = "111111111", country = "PowerCountry1" },
                new PowerUser() { Id = 2, FirstName = "PowerUser2", LastName = "PowerUser2", email = "poweruser2@example.com", phoneNumber = "222222222", country = "PowerCountry2" }
            );

            // PowerUserAdmins table
            modelBuilder.Entity<PowerUserAdmins>().HasData(
                new PowerUserAdmins() { AdmininistatorId = 1, PowerUserId = 1 },
                new PowerUserAdmins() { AdmininistatorId = 1, PowerUserId = 2 }
            );

            // PowerUserApplication table
            modelBuilder.Entity<PowerUserApplication>().HasData(
                new PowerUserApplication() { ApplicationId = 1, PowerUserId = 1 },
                new PowerUserApplication() { ApplicationId = 2, PowerUserId = 2 }
            );



            base.OnModelCreating(modelBuilder);
        }
    }
}

