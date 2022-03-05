using SchoolingSystem.Models.Etudiants;
using System.Collections.Generic;
using System.Data;

namespace SchoolingSystem.Managers.Mappers
{
    public partial interface IStorageMapper
    {
        Etudiant ToEtudiant(DataRow row);

        List<Etudiant> ToListEtudiant(DataTable table);
    }
}