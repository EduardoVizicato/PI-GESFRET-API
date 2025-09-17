using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TMS.Domain.Entites;
using TMS.Domain.Entities;
using TMS.Domain.ValueObjects;

namespace TMS.Infrastructure.Data.Configuration.TravelConfiguration
{
    internal class TravelEntityConfiguration : IEntityTypeConfiguration<Travel>
    {
        public void Configure(EntityTypeBuilder<Travel> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.TravelName)
                .IsRequired()
                .HasColumnName("TravelName")
                .HasMaxLength(100);

            builder.Property(t => t.StartDate)
                .HasColumnName("StartDate")
                .IsRequired();

            builder.Property(t => t.EndDate)
                .HasColumnName("EndData")
                .IsRequired();

            builder.Property(t => t.CreatedAt)
                .HasColumnName("DateCreate")
                .IsRequired();

            builder.Property(t => t.Load)
            .HasConversion(
                load => JsonSerializer.Serialize(load, (JsonSerializerOptions)null),
                value => JsonSerializer.Deserialize<LoadVO>(value, (JsonSerializerOptions)null))
             .HasColumnName("Load");

            builder.Property(t => t.Description)
                .IsRequired()
                .HasConversion(description => description.Description, value => new DescriptionVO(value))
                .HasColumnName("Description");

            builder.Property(t => t.Price)
                .IsRequired()
                .HasColumnName("Price");

        }
    }
}
