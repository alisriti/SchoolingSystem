using System;

namespace SchoolingSystem.Services.Foundations.Enseignants.Exceptions
{
    public class EnseignantNotFoundException : Exception
    {
        public EnseignantNotFoundException(string id) : base($"L'enseignant avec l'ID : {id} n'existe pas.")
        {
        }
    }
}