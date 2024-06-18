using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASPProjekat.DomainLayer;
using ASPProjekat.DomainLayer.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
namespace ASPProjekat.DataAccess
{
    public class ASPContext : DbContext
    {
        private readonly string _connectionString;
        public ASPContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        public ASPContext()
        {
            _connectionString = "Data Source=DESKTOP-54K3IOI\\SQLEXPRESS;Initial Catalog=ASPBookstore;Integrated Security=True;Trust Server Certificate=True";
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);

            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }
        public override int SaveChanges()
        {
            IEnumerable<EntityEntry> entries = this.ChangeTracker.Entries();

            foreach (EntityEntry entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    if (entry.Entity is Entity e)
                    {
                        e.CreatedAt = DateTime.UtcNow;
                    }
                }

                if (entry.State == EntityState.Modified)
                {
                    if (entry.Entity is Entity e)
                    {
                        e.ModifiedAt = DateTime.UtcNow;
                    }
                }
            }

            return base.SaveChanges();
        }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UseCase> UseCases { get; set; }
        public DbSet<RoleUseCase> RolesUseCases { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Edition> Editions { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<UseCaseLog> UseCaseLogs { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<StoreEdition> StoresEditions { get; set; }
        public DbSet<BookGenre> BooksGenres { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

    }
}
