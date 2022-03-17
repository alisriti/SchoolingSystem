using SchoolingSystem.Models.Etudiants;
using Etudiant = SchoolingSystem.Models.Etudiants.Etudiant;

namespace SchoolingSystem.Services.Mappers.Etudiants
{
    public interface IEtudiantMapper
    {
        Etudiant ToEtudiant(NewEtudiantModel newEtudiant);
    }
}