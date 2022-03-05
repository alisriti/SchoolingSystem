using SchoolingSystem.Consts.Ar.Ressources.Consts;
using SchoolingSystem.Models.Etudiants;
using System;
using static AtelierGL.Validations.Validators;

namespace SchoolingSystem.Services.Foundations.Etudiants
{
    public partial class EtudiantService
    {
        private void ValidateEtudiantforInsert(Etudiant etudiant)
        {
            ValidateNotNull(etudiant);

            ValidateNumCarte(etudiant.NumCarte);

            ValidateEntry(etudiant.Nom, "Vous devez spécifier le nom de l'étudiant");
            ValidateEntry(etudiant.Prenom, "Vous devez spécifier le prénom de l'étudiant");
            ValidateEntry(etudiant.DDN, Messages.InvalidDateTime);
            ValidateEntry(etudiant.LDN, Messages.LDNRequired);
            ValidateEntry(etudiant.Email, Messages.EmailRequired);
            etudiant.Telephone ??= String.Empty;
        }

        private void ValidateNumCarte(string numCarte)
        {
            ValidateEntry(numCarte, Messages.NumCarteRequired);
            ValidateNumCarteNotExists(numCarte);
        }

        private void ValidateNumCarteNotExists(string numCarte)
        {
            if (NumCarteExists(numCarte))
            {
                throw new NumCarteAlreadyExistsException(numCarte);
            }
        }
    }
}