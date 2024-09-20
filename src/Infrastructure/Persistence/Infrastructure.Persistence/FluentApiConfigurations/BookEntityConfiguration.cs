using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.FluentApiConfigurations
{
    public class BookEntityConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            //builder.ToTable("tbl_books");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Title)
                .HasMaxLength(50);

            builder.HasMany(x => x.Writers)
                .WithMany(x => x.Books);
        }
    }
}
