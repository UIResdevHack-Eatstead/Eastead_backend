using Eatstead.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eatstead.Infrastructure.Data.Configurations
{
    public class CafeteriaConfiguration : IEntityTypeConfiguration<Cafeteria>
    {
        public void Configure(EntityTypeBuilder<Cafeteria> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.BusinessName).IsRequired();
            builder.Property(p => p.HallName).IsRequired().HasMaxLength(255);
            builder.Property(p => p.ProductPicture).IsRequired();
            builder.Property(p => p.Address).IsRequired();
            
        }
    }
}
