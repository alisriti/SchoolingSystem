using SchoolingSystem.Models.Etudiants;
using System.Collections.Generic;

namespace SchoolingSystem.Services.Foundations.Etudiants
{
    public interface IEtudiantService
    {
        List<Etudiant> GetEtudiants();

        Etudiant GetEtudiantById(string id);

        Etudiant GetEtudiantByNumCarte(string numCarte);

        void CreateEtudiant(Etudiant etudiantToInsert);

        bool NumCarteExists(string numCarte);
    }
}