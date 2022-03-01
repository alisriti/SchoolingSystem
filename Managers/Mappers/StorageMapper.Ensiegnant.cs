using SchoolingSystem.Models.Ensignants;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SchoolingSystem.Managers.Mappers
{
    public partial class StorageMapper
    {
        public Enseignant ToEnseignant(DataRow row) =>
            new Enseignant()
            {
                ID = (string)row["ID"],
                Nom = (string)row["Nom"],
                Prenom = (string)row["Prenom"],
                Grade = (string)row["Grade"],
                Email = (string)row["Email"],
                Telephone = (string)row["Telephone"],
            };

        public List<Enseignant> ToListEnseignant(DataTable table) =>
            (from DataRow row in table.Rows select ToEnseignant(row)).ToList();
    }
}