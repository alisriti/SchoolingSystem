using System;

namespace SchoolingSystem.Services.Foundations.Etudiants.Exceptions
{
    public class EtudiantNotFoundException : Exception
    {
        public EtudiantNotFoundException(string id) :
            base($"L'etudiant avec l'ID : {id} n'existe pas.")
        {
        }
    }
}