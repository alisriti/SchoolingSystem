using SchoolingSystem.Models.Accounts;

namespace SchoolingSystem.Managers.Storages.Accounts
{
    public interface IAccountStore
    {
        void InsertAccount(Account account);
    }
}