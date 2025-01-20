using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_management.Models;

namespace Project_management.Configuration
{
    public class MembreConfiguration : IEntityTypeConfiguration<Membre>
    {
        public void Configure(EntityTypeBuilder<Membre> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id).UseIdentityColumn();

            builder.Property(a => a.nom).IsRequired();

            builder.Property(a => a.prenom).IsRequired();

            builder.Property(a => a.username).IsRequired();

            builder.Property(a => a.password).IsRequired();

            builder.Property(a => a.age).IsRequired();

            builder.Property(a => a.role).IsRequired();
        }
    }
}
