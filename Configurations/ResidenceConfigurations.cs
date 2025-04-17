using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace WebApplication1.Configurations
{
    internal class ResidenceConfigurations : IEntityTypeConfiguration<Residence>
    {
        public void Configure(EntityTypeBuilder<Residence> builder)
        {
            builder.HasKey(r => r.ResidenceId);
            builder.Property(r => r.ResidenceId).UseIdentityColumn(1000,1);
            builder.Property(r => r.Status).IsRequired();
            builder.Property(r => r.Street).IsRequired();
            builder.Property(r => r.Rent_Fee).IsRequired();


        }
    }
}
