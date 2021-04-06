using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RDI.Test.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RDI.Test.Infra.Mappings
{
    public class CustomerMapping : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(p => p.Id);

            // 1 : 1 => Customer : Card
            builder.HasOne(c => c.Card)
                .WithOne(c => c.Customer);

            builder.ToTable("Customers");
        }
    }
}