using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Domain.Entities;

namespace TMS.Infrastructure.Data.Configuration.CteConfiguration
{
    internal class CteEntityConfiguration : IEntityTypeConfiguration<Cte>
    {
        public void Configure(EntityTypeBuilder<Cte> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name)
                .HasColumnName("Name")
                .IsRequired();

            builder.Property(t => t.Description)
                .HasColumnName("Description")
                .IsRequired();

            builder.Property(x => x.File)
                 .HasColumnName("File")
                 .IsRequired();

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
