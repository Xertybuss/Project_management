namespace Project_management.Models
{
    public class Tache
    {
        public int Id { get; set; }
        public string titre { get; set; }
        public string etat { get; set; }
        public string description { get; set; }
        public DateTime dateDebut { get; set; }
        public DateTime dateFin { get; set; }
        public int idProjet { get; set; }

        public Projet projet { get; set; } = new Projet();
    }
}
