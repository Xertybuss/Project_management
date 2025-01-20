namespace Project_management.Models
{
    public class Membre
    {
        public int Id { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public int age { get; set; }
        public string role { get; set; }

        public int idEquipe { get; set; }

        public Equipe equipe { get; set; } = new Equipe();
    }
}
