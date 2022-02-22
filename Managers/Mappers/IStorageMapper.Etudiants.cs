using System.Collections.Generic;
using System.Data;
using SchoolingSystem.Models.Etudiants;

namespace SchoolingSystem.Managers.Mappers
{
    public partial interface IStorageMapper
    {
        Etudiant ToEtudiant(DataRow row);
        List<Etudiant> ToListEtudiant(DataTable table);
    }
}