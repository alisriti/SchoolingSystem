using SchoolingSystem.Models.Accounts;

namespace SchoolingSystem.Services.Foundations.Accounts
{
    public interface IAccountService
    {
        void CreateAccount(Account account);
    }
}