using SchoolingSystem.Models.Etudiants;
using System.Collections.Generic;

namespace SchoolingSystem.Managers.ApiManagers
{
    public partial interface IApiManager
    {
        List<Etudiant> GetEtudiants();

        Etudiant GetEtudiantById(string id);

        void CreateEtudiant(Etudiant etudiant);
    }
}