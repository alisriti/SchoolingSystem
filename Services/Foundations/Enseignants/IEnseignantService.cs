using SchoolingSystem.Models.Ensignants;
using System.Collections.Generic;

namespace SchoolingSystem.Services.Foundations.Enseignants
{
    internal interface IEnseignantService
    {
        List<Enseignant> GetEnseignant();

        Enseignant GetEnseignantById(string id);
    }
}