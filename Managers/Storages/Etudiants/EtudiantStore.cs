﻿using Microsoft.Extensions.Configuration;
using SchoolingSystem.Managers.Mappers;
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
    }
}