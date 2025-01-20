using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_management.Models;

namespace Project_management.Configuration
{
    public class TacheConfiguration : IEntityTypeConfiguration<Tache>
    {
        public void Configure(EntityTypeBuilder<Tache> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id).UseIdentityColumn();
        }
    }
}
