using SchoolingSystem.Models.Etudiants;
using System;

namespace SchoolingSystem.Services.Mappers.Etudiants
{
    public class EtudiantMapper : IEtudiantMapper
    {
        public Etudiant ToEtudiant(NewEtudiantModel newEtudiant)
        {
            var etudiant = new Etudiant();
            etudiant.NumCarte = newEtudiant.NumCarte;
            etudiant.Nom = newEtudiant.Nom;
            etudiant.Prenom = newEtudiant.Prenom;
            etudiant.DDN = Convert.ToDateTime(newEtudiant.DDN);
            etudiant.LDN = newEtudiant.LDN;
            etudiant.Telephone = newEtudiant.Telephone ?? "";
            etudiant.Email = newEtudiant.Email;
            return etudiant;
        }
    }
}