using SchoolingSystem.Models.Etudiants;
using System.Collections.Generic;

namespace SchoolingSystem.Services.Foundations.Etudiants
{
    public interface IEtudiantService
    {
        List<Etudiant> GetEtudiants();

        Etudiant GetEtudiantById(string id);
    }
}