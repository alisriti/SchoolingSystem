using Microsoft.Extensions.Configuration;
using SchoolingSystem.Managers.Mappers;
using SchoolingSystem.Models.Accounts;
using System.Data.SqlClient;

namespace SchoolingSystem.Managers.Storages.Accounts
{
    public class AccountStore : IAccountStore
    {
        private readonly string connectionString;

        private const string insertAccountCommand =
            "INSERT ACCOUNTS VALUES(@aId, @aProfile, @aEmail, @aPassword, @aStatus)";

        public AccountStore(IConfiguration configuration, IStorageMapper storageMapper)
        {
            connectionString = configuration.GetConnectionString("Scolarite");
        }

        public void InsertAccount(Account account)
        {
            using var connection = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand(insertAccountCommand, connection);

            cmd.Parameters.AddWithValue("@aId", account.Id);
            cmd.Parameters.AddWithValue("@aProfile", account.Profile);
            cmd.Parameters.AddWithValue("@aEmail", account.Email);
            cmd.Parameters.AddWithValue("@aPassword", account.Password);
            cmd.Parameters.AddWithValue("@aStatus", account.Status);

            connection.Open();
            cmd.ExecuteNonQuery();
        }
    }
}