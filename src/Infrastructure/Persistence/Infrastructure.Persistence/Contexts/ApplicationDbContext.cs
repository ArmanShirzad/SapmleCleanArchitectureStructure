using Core.Domain.Common;
using Core.Domain.Entities;
using Infrastructure.Persistence.FluentApiConfigurations;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Contexts
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Comment> Comments { get; set; }



        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // add single config
            //builder.ApplyConfiguration<Book>(new BookEntityConfiguration());
            // or use
            builder.Entity<Product>().Property(p => p.Price).HasPrecision(18, 3);
            builder.Entity<ProductImage>()
           .HasOne(pi => pi.Product)
           .WithMany(p => p.Images)
           .HasForeignKey(pi => pi.ProductId);

            builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

            base.OnModelCreating(builder);

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var item in ChangeTracker.Entries<AuditableEntity>())
            {
                if (item.State == EntityState.Added)
                    item.Entity.CreateDate = DateTime.Now;
                else if(item.State == EntityState.Modified)
                    item.Entity.ModifyDate = DateTime.Now;
            }
            return base.SaveChangesAsync(cancellationToken);
        }

    }
}
