using System;

namespace SchoolingSystem.Services.Foundations.Etudiants.Exceptions
{
    public class CreateEtudiantException : Exception
    {
        public CreateEtudiantException(Exception exception)
        {
            throw new EtudiantServiceException("Echec de la création de l'étudiant.",
                exception);
        }
    }
}