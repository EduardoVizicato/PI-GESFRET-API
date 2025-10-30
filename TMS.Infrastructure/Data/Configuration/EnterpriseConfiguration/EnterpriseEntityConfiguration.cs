using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Domain.Entities;
using TMS.Domain.ValueObjects;

namespace TMS.Infrastructure.Data.Configuration.EnterpriseConfiguration
{
    internal class EnterpriseEntityConfiguration : IEntityTypeConfiguration<Enterprise>
    {
        public void Configure(EntityTypeBuilder<Enterprise> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name)
                .HasColumnName("Name")
                .IsRequired();

            builder.Property(t => t.Email)
                .HasColumnName("Email")
                .IsRequired();

            builder.Property(x => x.TaxId)
                 .IsRequired()
                 .HasColumnName("TaxID")
                 .HasConversion(taxId => taxId.TaxId, value => new TaxIdVO(value));

            builder.Property(x => x.UpdatedAt)
                .HasColumnName("UpdatedAt")
                .HasColumnType("datetime2");

            builder.Property(x => x.IsActive)
                .IsRequired()
                .HasColumnName("IsActive")
                .HasColumnType("bit");

            builder.Property(t => t.CreatedAt)
                .HasColumnName("DateCreate")
                .IsRequired();
        }
    }
}
