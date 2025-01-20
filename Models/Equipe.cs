using System.Collections.ObjectModel;
using System;

namespace Project_management.Models
{
    public class Equipe
    {
        public int Id { get; set; }
        public string nomEquipe { get; set; }
        public List<Membre> Membres { get; set; } = new List<Membre>();
    }
}
