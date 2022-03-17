using SchoolingSystem.Models.Etudiants;
using System.Collections.Generic;

namespace SchoolingSystem.Services.ApiServices
{
    public interface IEtudiantService
    {
        List<Etudiant> GetEtudiants();

        Etudiant GetEtudiantById(string Id);

        void CreateEtudiant(Etudiant etudiant);
    }
}