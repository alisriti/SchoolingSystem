using Microsoft.Extensions.Configuration;
using SchoolingSystem.Managers.Mappers;
using SchoolingSystem.Models.Ensignants;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SchoolingSystem.Managers.Storages.Enseignants
{
    public class EnseignantStore : IEnseignantStore

    {
        private readonly IStorageMapper storageMapper;
        private readonly string connectionString;

        public EnseignantStore(IConfiguration configuration, IStorageMapper storageMapper)
        {
            this.storageMapper = storageMapper;
            connectionString = configuration.GetConnectionString("Scolarite");
        }

        public List<Enseignant> SelectEnseignants()
        {
            DataTable dt = new DataTable();

            using var connection = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("select * from ENSEIGNANTS ", connection);
            connection.Open();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return storageMapper.ToListEnseignant(dt);
        }

        public Enseignant SelectEnseignantById(string Id)
        {
            DataTable dt = new DataTable();

            using var connection = new SqlConnection(connectionString);

            SqlCommand cmd =
                new SqlCommand("select * from ENSEIGNANTS WHERE ID = @aId", connection);
            cmd.Parameters.AddWithValue("@aId", Id);
            connection.Open();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return dt.Rows.Count == 0
                ? null
                : storageMapper.ToEnseignant(dt.Rows[0]);
        }
    }
}