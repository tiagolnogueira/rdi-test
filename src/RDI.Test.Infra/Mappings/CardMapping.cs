using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RDI.Test.Domain.Entities;

namespace RDI.Test.Infra.Mappings
{
    public class CardMapping : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(c => c.CardNumber)
               .IsRequired()
               .HasColumnType("BIGINT");

            builder.Property(c => c.CVV)
               .IsRequired()
               .HasColumnType("INTEGER");

            builder.ToTable("Cards");
        }
    }
}