using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class BoxConfiguration : IEntityTypeConfiguration<Box>
    {
        public void Configure(EntityTypeBuilder<Box> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Code).IsRequired().HasMaxLength(50);
            builder.Property(p => p.DestructionFlag).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Reference).HasMaxLength(50);
            builder.Property(p => p.DateLeftOffice);

            
        }
    }
}