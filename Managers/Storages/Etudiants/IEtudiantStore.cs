using SchoolingSystem.Models.Auditables;
using SchoolingSystem.Models.Etudiants;
using System.Collections.Generic;

namespace SchoolingSystem.Managers.Storages.Etudiants
{
    public interface IEtudiantStore
    {
        List<Etudiant> SelectEtudiants();

        Etudiant SelectEtudiantById(string id);

        void InsertEtudiant(Etudiant newEtudiant, Auditable auditable);

        Etudiant SelectEtudiantByNumCarte(string numCarte);
    }
}