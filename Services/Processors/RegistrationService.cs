using SchoolingSystem.Managers.IDManagers;
using SchoolingSystem.Models.Accounts;
using SchoolingSystem.Models.Etudiants;
using SchoolingSystem.Services.ApiServices;
using SchoolingSystem.Services.Foundations.Accounts;
using SchoolingSystem.Services.Mappers.Etudiants;
using System;
using System.Transactions;

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
            using TransactionScope transaction = new TransactionScope();
            try
            {
                string newId = idGenerator.GenerateId();

                Etudiant etudiantToCreate = etudiantMapper.ToEtudiant(etudiant);
                etudiantToCreate.ID = newId;

                Account accountToCreate = new Account()
                {
                    Id = newId,
                    Profile = Profile.Etudiant,
                    Email = etudiant.Email,
                    Password = "1122222222",
                    Status = AccountStatus.Active
                };

                etudiantService.CreateEtudiant(etudiantToCreate);
                accountService.CreateAccount(accountToCreate);

                transaction.Complete();
            }
            catch (Exception exception)
            {
                throw new RegisterEtudiantException(exception);
            }
            finally
            {
                transaction.Dispose();
            }
        }
    }

    public class RegisterEtudiantException : Exception
    {
        //public RegisterEtudiantException(CreateEtudiantException exception) :
        //    base("Echec de l'enregistrement de l'étudiant", exception)
        //{
        //}

        public RegisterEtudiantException(CreateAccountException exception) :
            base("Echec de l'enregistrement de l'étudiant", exception)
        {
        }

        public RegisterEtudiantException(Exception exception) :
            base("Echec de l'enregistrement de l'étudiant", exception)
        {
        }
    }
}