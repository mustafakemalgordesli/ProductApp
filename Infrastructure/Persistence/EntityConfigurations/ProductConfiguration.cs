using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityConfigurations;

public class ProductConfiguration : BaseEntityConfiguration<Product>
{
    public override void Configure(EntityTypeBuilder<Product> builder)
    {
        base.Configure(builder);

        builder.ToTable("products", ApplicationDbContext.DEFAULT_SCHEMA);

        builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Quantity).IsRequired();
        builder.Property(x => x.Value).IsRequired();

        builder.HasOne(i => i.Category)
            .WithMany(i => i.Products)
            .HasForeignKey(i => i.CategoryId);
    }
}
