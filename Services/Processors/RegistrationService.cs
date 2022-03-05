using SchoolingSystem.Managers.IDManagers;
using SchoolingSystem.Models.Accounts;
using SchoolingSystem.Models.Etudiants;
using SchoolingSystem.Services.Foundations.Accounts;
using SchoolingSystem.Services.Foundations.Etudiants;
using SchoolingSystem.Services.Mappers.Etudiants;

namespace SchoolingSystem.Services.Processors
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IIDGenerator idGenerator;
        private readonly IEtudiantMapper etudiantMapper;
        private readonly IEtudiantService etudiantService;
        private readonly IAccountService accountService;

        public RegistrationService(
            IIDGenerator idGenerator,
            IEtudiantMapper etudiantMapper,
            IEtudiantService etudiantService,
            IAccountService accountService)
        {
            this.idGenerator = idGenerator;
            this.etudiantMapper = etudiantMapper;
            this.etudiantService = etudiantService;
            this.accountService = accountService;
        }

        public void RegisterEtudiant(NewEtudiantModel etudiant)
        {
            string newId = idGenerator.GenerateId();

            Etudiant etudiantToCreate = etudiantMapper.ToEtudiant(etudiant);
            etudiantToCreate.ID = newId;

            Account newAccount = new Account()
            {
                Id = newId,
                Email = etudiant.Email,
                Profile = Profile.Etudiant,
                Password = "1122222222",
                Status = AccountStatus.Active
            };

            etudiantService.CreateEtudiant(etudiantToCreate);
            accountService.CreateAccount(newAccount);
        }
    }
}