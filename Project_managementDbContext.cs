using Microsoft.EntityFrameworkCore;
using Project_management.Configuration;
using Project_management.Models;



namespace Project_management
{
    public class Project_managementDbContext : DbContext
    {
        public DbSet<Projet> Projets { get; set; }
        public DbSet<Tache> Taches { get; set; }
        public DbSet<Equipe> Equipes { get; set; }


        public Project_managementDbContext(DbContextOptions<Project_managementDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.ApplyConfiguration(new ProjetConfiguration());

            builder.ApplyConfiguration(new TacheConfiguration());

            builder.ApplyConfiguration(new EquipeConfiguration());

            builder.ApplyConfiguration(new MembreConfiguration());
        }
        public DbSet<Project_management.Models.Membre> Membre { get; set; } = default!;
    }
}
