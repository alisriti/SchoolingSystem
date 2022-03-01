using System.Collections.Generic;
using System.Data;
using SchoolingSystem.Models.Ensignants;

namespace SchoolingSystem.Managers.Mappers
{
    public partial interface IStorageMapper
    {
        Enseignant ToEnseignant(DataRow row);
        List<Enseignant> ToListEnseignant(DataTable table);
    }
}