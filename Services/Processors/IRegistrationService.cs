using SchoolingSystem.Models.Etudiants;

namespace SchoolingSystem.Services.Processors
{
    public interface IRegistrationService
    {
        void RegisterEtudiant(NewEtudiantModel etudiant);
    }
}