using System;

namespace SchoolingSystem.Models.Etudiants
{
    public class Etudiant
    {
        public string ID { get; set; }
        public string NumCarte { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime DDN { get; set; }
        public string LDN { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
    }
}