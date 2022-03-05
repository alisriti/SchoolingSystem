using SchoolingSystem.Models.Etudiants;

namespace SchoolingSystem.Services.Mappers.Etudiants
{
    public interface IEtudiantMapper
    {
        Etudiant ToEtudiant(NewEtudiantModel newEtudiant);
    }
}