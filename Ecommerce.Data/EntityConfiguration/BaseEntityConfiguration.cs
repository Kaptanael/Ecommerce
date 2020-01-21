using Ecommerce.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Data.EntityConfiguration
{
    public abstract class BaseEntityConfiguration<TEntityType> : IEntityTypeConfiguration<TEntityType>
    where TEntityType : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntityType> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.CreatedDate).HasDefaultValue(DateTime.Now).IsRequired();
            builder.Property(b => b.ModifiedDate).HasDefaultValue(DateTime.MinValue).IsRequired();
            builder.Property(b => b.CreatedBy).IsRequired();
            builder.Property(b => b.ModifiedBy).HasDefaultValue(null).IsRequired();
        }
    }
}
