using SchoolingSystem.Models.Etudiants;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SchoolingSystem.Managers.Mappers
{
    public partial class StorageMapper
    {
        public Etudiant ToEtudiant(DataRow row) =>
            new Etudiant()
            {
                ID = (string)row["ID"],
                NumCarte = (string)row["NumCarte"],
                Nom = (string)row["Nom"],
                Prenom = (string)row["Prenom"],
                DDN = (DateTime)row["DDN"],
                LDN = (string)row["LDN"],
                Email = (string)row["Email"],
                Telephone = (string)row["Telephone"],
            };

        public List<Etudiant> ToListEtudiant(DataTable table) =>
            (from DataRow row in table.Rows select ToEtudiant(row)).ToList();
    }
}