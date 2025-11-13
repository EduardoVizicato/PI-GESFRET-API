using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Domain.Entites;
using TMS.Domain.ValueObjects;

namespace TMS.Infrastructure.Data.Configuration.VehicleConfiguration
{
    internal class VehicleEntityConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.HasKey(v => v.Id);

            builder.Property(v => v.Name)
                .HasMaxLength(50)
                .HasColumnName("Name")
                .IsRequired();

            builder.Property(v => v.VehicleRegistrationPlate)
                .HasColumnName("VehicleRegistrationPlate")
                .IsRequired()
                .HasConversion(registrationPlate => registrationPlate.RegistrationPlate, value => new VehicleRegistrationPlateVO(value));

            builder.Property(v => v.TruckType)
                .IsRequired()
                .HasColumnName("Type");

            builder.Property(v => v.WheelType)
                .IsRequired()
                .HasColumnName("Rodado");

            builder.Property(v => v.BodyType)
                .IsRequired()
                .HasColumnName("Carroceria");

            builder.HasMany(v => v.Travels)
                .WithOne(t => t.Truck)
                .HasForeignKey(t => t.TruckId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
