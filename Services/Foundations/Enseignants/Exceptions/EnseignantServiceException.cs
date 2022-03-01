using System;

namespace SchoolingSystem.Services.Foundations.Enseignants.Exceptions
{
    public class EnseignantServiceException : Exception
    {
        public EnseignantServiceException(EmptyEnseignantsListException emptyList) :
            base("Aucun enseignant trouvé")
        {
        }

        public EnseignantServiceException(EnseignantNotFoundException notFound) : base(notFound.Message)
        {
        }

        public EnseignantServiceException(Exception exception) :
            base($"Le service à généré l'erreur suivante : {exception.Message}. Veuillez contacter l'administrateur.")
        {
        }
    }
}