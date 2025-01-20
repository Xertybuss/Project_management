using System.Collections.ObjectModel;

namespace Project_management.Models
{
    public class Projet
    {
        public int Id { get; set; }
        public string? titre { get; set; }
        public string? etat { get; set; }
        public string? description { get; set; }
        public DateTime dateDebut { get; set; }
        public DateTime dateFin { get; set; }
        public List<Tache> Taches { get; set; } = new List<Tache>();
    }
}
