using System;

namespace SchoolingSystem.Services.Foundations.Etudiants.Exceptions
{
    public class EtudiantServiceException : Exception
    {
        public EtudiantServiceException(EtudiantNotFoundException notFound) : base(notFound.Message)
        {
        }

        public EtudiantServiceException(Exception exception) :
            base($"Le service à généré l'erreur suivante : {exception.Message}. Veuillez contacter l'administrateur.")
        {
        }

        public EtudiantServiceException(string Message, Exception innerException) :
            base(Message, innerException)
        {
        }
    }
}