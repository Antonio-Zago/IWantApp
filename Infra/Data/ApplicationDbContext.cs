using Flunt.Notifications;
using IWantApp.Domain.Products;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IWantApp.Infra.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categoryes { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


        //Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); //Chamando o onModelCreating da classe pai

            modelBuilder.Ignore<Notification>();
            modelBuilder.Entity<Product>()
                .Property(p => p.Description).HasMaxLength(500);
            modelBuilder.Entity<Product>()
                .Property(p => p.Name).IsRequired();


            modelBuilder.Entity<Category>()
                .Property(c => c.Name).IsRequired();

        }

        protected override void ConfigureConventions(ModelConfigurationBuilder modelConfigurationBuilder) 
        {
            modelConfigurationBuilder.Properties<string>()
                .HaveMaxLength(100);
        }
    }
}
