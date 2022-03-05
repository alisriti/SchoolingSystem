using Microsoft.Extensions.Configuration;
using SchoolingSystem.Managers.Mappers;
using SchoolingSystem.Models.Auditables;
using SchoolingSystem.Models.Etudiants;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SchoolingSystem.Managers.Storages.Etudiants
{
    public class EtudiantStore : IEtudiantStore
    {
        private readonly IStorageMapper storageMapper;
        private readonly string connectionString;

        //private const string insertEtudiantCommand =
        //    "INSERT ETUDIANTS VALUES(@aId, @aNumCarte, @aNom, @aPrenom, @aDDN, " +
        //    "@aLDN, @aEmail, @aTelephone, @aCreatedBy, @aCreationDate)";
        private const string insertEtudiantCommand =
            "dbo.InsertEtudiant";

        private const string selectEtudiantByNumCarteQuery =
            "select * from ETUDIANTS WHERE NumCarte = @aNumCarte";

        public EtudiantStore(IConfiguration configuration, IStorageMapper storageMapper)
        {
            this.storageMapper = storageMapper;
            connectionString = configuration.GetConnectionString("Scolarite");
        }

        public List<Etudiant> SelectEtudiants()
        {
            DataTable dt = new DataTable();

            using var connection = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("select * from ETUDIANTS", connection);
            connection.Open();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return storageMapper.ToListEtudiant(dt);
        }

        public Etudiant SelectEtudiantById(string id)
        {
            DataTable dt = new DataTable();

            using var connection = new SqlConnection(connectionString);

            SqlCommand cmd =
                new SqlCommand("select * from ETUDIANTS WHERE ID = @aId", connection);
            cmd.Parameters.AddWithValue("@aId", id);
            connection.Open();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return dt.Rows.Count == 0
                ? null
                : storageMapper.ToEtudiant(dt.Rows[0]);
        }

        public void InsertEtudiant(Etudiant newEtudiant, Auditable auditable)
        {
            using var connection = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand(insertEtudiantCommand, connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@aId", newEtudiant.ID);
            cmd.Parameters.AddWithValue("@aNumCarte", newEtudiant.NumCarte);
            cmd.Parameters.AddWithValue("@aNom", newEtudiant.Nom);
            cmd.Parameters.AddWithValue("@aPrenom", newEtudiant.Prenom);
            cmd.Parameters.AddWithValue("@aDDN", newEtudiant.DDN);
            cmd.Parameters.AddWithValue("@aLDN", newEtudiant.LDN);
            cmd.Parameters.AddWithValue("@aEmail", newEtudiant.Email);
            cmd.Parameters.AddWithValue("@aTelephone", newEtudiant.Telephone);

            cmd.Parameters.AddWithValue("@aCreatedBy", auditable.CreatedBy);
            cmd.Parameters.AddWithValue("@aCreationDate", auditable.CreationDate);

            connection.Open();
            cmd.ExecuteNonQuery();
        }

        public Etudiant SelectEtudiantByNumCarte(string numCarte)
        {
            DataTable dt = new DataTable();

            using var connection = new SqlConnection(connectionString);

            SqlCommand cmd =
                new SqlCommand(selectEtudiantByNumCarteQuery, connection);
            cmd.Parameters.AddWithValue("@aNumCarte", numCarte);
            connection.Open();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return dt.Rows.Count == 0
                ? null
                : storageMapper.ToEtudiant(dt.Rows[0]);
        }
    }
}