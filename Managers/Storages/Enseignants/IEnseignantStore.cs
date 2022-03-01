using SchoolingSystem.Models.Ensignants;
using System.Collections.Generic;

namespace SchoolingSystem.Managers.Storages.Enseignants
{
    public interface IEnseignantStore
    {
        List<Enseignant> SelectEnseignants();

        Enseignant SelectEnseignantById(string Id);
    }
}