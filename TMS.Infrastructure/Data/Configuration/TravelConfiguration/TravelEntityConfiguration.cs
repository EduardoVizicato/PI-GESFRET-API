using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            builder.HasKey(x => x.Id);

            builder.Property(x => x.TravelName)
                .IsRequired()
                .HasColumnName("TravelName")
                .HasMaxLength(100);

            builder.Property(x => x.StartDate)
                .HasColumnName("StartDate")
                .IsRequired();

            builder.Property(x => x.EndDate)
                .HasColumnName("EndData")
                .IsRequired();

            builder.Property(x => x.DateCreate)
                .HasColumnName("DateCreate")
                .IsRequired();

            builder.Property(x => x.Load)
                .IsRequired()
                .HasConversion(load => new { load.Name, load.Weight, load.LoadType }, value => new LoadVO(value.Name, value.Weight, value.LoadType))
                .HasColumnName("Load");

            builder.Property(x => x.Description)
                .IsRequired()
                .HasConversion(description => description.Description, value => new DescriptionVO(value))
                .HasColumnName("Description");
        }
    }
}
