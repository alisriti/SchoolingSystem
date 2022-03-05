using AtelierGL.Validations;
using SchoolingSystem.Managers.Storages.Accounts;
using SchoolingSystem.Models.Accounts;
using System;
using AtelierGL.Exceptions;

namespace SchoolingSystem.Services.Foundations.Accounts
{
    public class AccountService : IAccountService
    {
        private readonly IAccountStore accountStore;

        public AccountService(IAccountStore accountStore)
        {
            this.accountStore = accountStore;
        }

        public void CreateAccount(Account account)
        {
            try
            {
                ValidateAccountforInsertion(account);
                accountStore.InsertAccount(account);
            }
            catch (NullValueException nullException)
            {
                throw new CreateAccountException(nullException);
            }
            catch (InvalidEntryException invalidEntry)
            {
                throw new CreateAccountException(invalidEntry);
            }
            catch (Exception exception)
            {
                throw new CreateAccountException(exception);
            }
        }

        private void ValidateAccountforInsertion(Account account)
        {
            Validators.ValidateNotNull(account);
            Validators.ValidateEntry(account.Id, "Vous devez spécifier un Id");
            Validators.ValidateEntry(account.Email, "Vous devez specifier un email valide");
            Validators.ValidateEntry(account.Password, "Vous devez entrer le mot de passe");
        }
    }

    public class CreateAccountException : Exception
    {
        public CreateAccountException(Exception exception) :
            base("Echec de la création du compte", exception)
        {
        }
    }
}