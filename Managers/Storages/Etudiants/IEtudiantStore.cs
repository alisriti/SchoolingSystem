using SchoolingSystem.Models.Etudiants;
using System.Collections.Generic;

namespace SchoolingSystem.Managers.Storages.Etudiants
{
    public interface IEtudiantStore
    {
        List<Etudiant> SelectEtudiants();
    }
}