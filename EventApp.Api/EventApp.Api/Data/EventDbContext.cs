using EventApp.Api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EventApp.Api.Data
{
    public class EventDbContext : IdentityDbContext<User, Role, int, IdentityUserClaim<int>, UserRole,
        IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Hall> Halls { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<ItemSupplier> ItemSuppliers { get; set; }
        public DbSet<PackageService> PackageServices { get; set; }
        public DbSet<PackageItem> PackageItems { get; set; }
        public DbSet<ServiceSupplier> ServiceSuppliers { get; set; }
        public DbSet<EventService> EventServices { get; set; }
        public DbSet<EventItem> EventItems { get; set; }
        public DbSet<EventEmployee> EventEmployees { get; set; }
        public virtual DbSet<HallFeature> HallFeatures { get; set; }
        public virtual DbSet<Photo> Photos { get; set; }

        public EventDbContext(DbContextOptions<EventDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<UserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                .WithMany(ur => ur.UserRoles)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();

                userRole.HasOne(ur => ur.User)
                .WithMany(ur => ur.UserRoles)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();
            });

            builder.Entity<ItemSupplier>(itemSupplier =>
            {
                itemSupplier.HasKey(IS => new { IS.ItemId, IS.SupplierId });
                itemSupplier.HasOne(ur => ur.Item)
                .WithMany(ur => ur.ItemSuppliers)
                .HasForeignKey(ur => ur.ItemId)
                .OnDelete(DeleteBehavior.Restrict);

                itemSupplier.HasOne(ur => ur.Supplier)
                .WithMany(ur => ur.ItemSuppliers)
                .HasForeignKey(ur => ur.SupplierId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<PackageService>(packageService =>
            {
                packageService.HasKey(IS => new { IS.PackageId, IS.ServiceId });
                packageService.HasOne(P => P.Package)
                .WithMany(P => P.PackageServices)
                .HasForeignKey(P => P.PackageId)
                .OnDelete(DeleteBehavior.Restrict);

                packageService.HasOne(S => S.Service)
                .WithMany(S => S.PackageServices)
                .HasForeignKey(S => S.ServiceId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<PackageItem>(packageItem =>
            {
                packageItem.HasKey(PI => new { PI.ItemId, PI.PackageId });
                packageItem.HasOne(P => P.Package)
                .WithMany(P => P.PackageItems)
                .HasForeignKey(P => P.PackageId)
                .OnDelete(DeleteBehavior.Restrict);

                packageItem.HasOne(I => I.Item)
                .WithMany(I => I.PackageItems)
                .HasForeignKey(I => I.ItemId)
                .OnDelete(DeleteBehavior.Restrict);
            });            

            builder.Entity<ServiceSupplier>(serviceSupplier =>
            {
                serviceSupplier.HasKey(SS => new { SS.ServiceId, SS.SupplierId });
                serviceSupplier.HasOne(S => S.Service)
                .WithMany(S => S.ServiceSuppliers)
                .HasForeignKey(S => S.ServiceId)
                .OnDelete(DeleteBehavior.Restrict);

                serviceSupplier.HasOne(S => S.Supplier)
                .WithMany(S => S.ServiceSuppliers)
                .HasForeignKey(S => S.SupplierId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<EventService>(eventService =>
            {
                eventService.HasKey(ES => new { ES.ServiceId, ES.EventId });
                eventService.HasOne(S => S.Service)
                .WithMany(S => S.EventServices)
                .HasForeignKey(S => S.ServiceId)
                .OnDelete(DeleteBehavior.Restrict);

                eventService.HasOne(E => E.Event)
                .WithMany(E => E.EventServices)
                .HasForeignKey(E => E.EventId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<EventItem>(eventItem =>
            {
                eventItem.HasKey(EI => new { EI.EventId, EI.ItemId });
                eventItem.HasOne(E => E.Event)
                .WithMany(E => E.EventItems)
                .HasForeignKey(E => E.EventId)
                .OnDelete(DeleteBehavior.Restrict);

                eventItem.HasOne(S => S.Item)
                .WithMany(S => S.EventItems)
                .HasForeignKey(S => S.ItemId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<EventEmployee>(eventEmployee =>
            {
                eventEmployee.HasKey(EI => new { EI.EventId, EI.EmployeeId });
                eventEmployee.HasOne(E => E.Event)
                .WithMany(E => E.EventEmployees)
                .HasForeignKey(E => E.EventId)
                .OnDelete(DeleteBehavior.Restrict);

                eventEmployee.HasOne(S => S.Employee)
                .WithMany(S => S.EventEmployees)
                .HasForeignKey(S => S.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<HallFeature>(hallFeature =>
            {
                hallFeature.HasKey(HF => new { HF.HallId, HF.FeatureId });
                hallFeature.HasOne(H => H.Hall)
                .WithMany(H => H.HallFeatures)
                .HasForeignKey(H => H.HallId)
                .OnDelete(DeleteBehavior.Restrict);

                hallFeature.HasOne(F => F.Feature)
                .WithMany(F => F.HallFeatures)
                .HasForeignKey(F => F.FeatureId)
                .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
