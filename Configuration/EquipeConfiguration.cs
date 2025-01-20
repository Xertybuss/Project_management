 using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_management.Models;

namespace Project_management.Configuration
{
    public class EquipeConfiguration : IEntityTypeConfiguration<Equipe>
    {
        public void Configure(EntityTypeBuilder<Equipe> builder)
        {

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).UseIdentityColumn();

            builder.Property(e => e.nomEquipe).IsRequired();

            builder.HasMany(e => e.Membres).WithOne(m => m.equipe).HasForeignKey(e => e.idEquipe);

            builder.ToTable("Equipes");
        }
    }
}
