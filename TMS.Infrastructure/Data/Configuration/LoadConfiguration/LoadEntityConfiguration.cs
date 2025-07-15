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
                .HasConversion(description => description.Description, value => new DescriptionVO(value));

            builder.Property(x => x.Quantity)
                .HasColumnName("Quantity")
                .IsRequired();

            builder.Property(x => x.Type)
                .IsRequired()
                .HasColumnName("Type")
                .HasConversion(type => type.Type, value => new TypeVO(value));


            builder.HasOne(x => x.User)             
                   .WithMany()                      
                   .HasForeignKey(x => x.UserId)    
                   .IsRequired()                    
                   .OnDelete(DeleteBehavior.Restrict); 
        }
    }
}