using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TMS.Domain.Entities;
using TMS.Domain.ValueObjects;

namespace TMS.Infrastructure.Data.Configuration.AdressConfiguration;

public class AdressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.City)
            .IsRequired()
            .HasColumnName("City")
            .HasConversion(city => city.City, value => new CityVO(value));
        
        builder.Property(x => x.State)
            .IsRequired()
            .HasColumnName("State")
            .HasConversion(state => state.State, value => new StateVO(value));
        
        builder.Property(x => x.Street)
            .IsRequired()
            .HasColumnName("Street")
            .HasConversion(street => street.Street, value => new StreetVO(value));

        builder.Property(x => x.AdressNumber)
            .IsRequired()
            .HasColumnName("AdressNumber");
        
        builder.Property(x => x.PostalCode)
            .IsRequired()
            .HasColumnName("PostalCode")
            .HasConversion(postalCode => postalCode.PostalCode, value => new PostalCodeVO(value));
        
        builder.HasOne(x => x.Travel)             
            .WithMany()                      
            .HasForeignKey(x => x.TravelId)    
            .IsRequired()                    
            .OnDelete(DeleteBehavior.Restrict); 
    }
}