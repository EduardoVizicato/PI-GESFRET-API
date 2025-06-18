using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TMS.Domain.Entities;
using TMS.Domain.ValueObjects;

namespace TMS.Infrastructure.Data.Configuration.LoadConfiguration
{
    internal class LoadEntityConfiguration : IEntityTypeConfiguration<Load>
    {
        public void Configure(EntityTypeBuilder<Load> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Description)
                .IsRequired()
                .HasColumnName("Description")
                .HasConversion(description => description.Value, value => new DescriptionVO(value));

            builder.Property(x => x.Quantity)
                .HasColumnName("Quantity")
                .IsRequired();

            builder.Property(x => x.Type)
                .IsRequired()
                .HasColumnName("Type")
                .HasConversion(type => type.Value, value => new TypeVO(value));


            builder.HasOne(l => l.User)             
                   .WithMany()                      
                   .HasForeignKey(l => l.UserId)    
                   .IsRequired()                    
                   .OnDelete(DeleteBehavior.Restrict); 
        }
    }
}