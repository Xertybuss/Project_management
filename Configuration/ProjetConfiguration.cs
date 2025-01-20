using Project_management.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Project_management.Configuration
{
    public class ProjetConfiguration : IEntityTypeConfiguration<Projet>
    {
        public void Configure(EntityTypeBuilder<Projet> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .UseIdentityColumn();

            builder.Property(p => p.titre).IsRequired();

            builder.Property(p => p.etat).IsRequired();

            builder.Property(p => p.description).IsRequired();

            builder.Property(p => p.dateDebut).IsRequired();

            builder.Property(p => p.dateFin).IsRequired();

            builder.HasMany(p => p.Taches).WithOne(t => t.projet)
                .HasForeignKey(t => t.idProjet);

            builder.ToTable("Projets");
        }
    }
}
