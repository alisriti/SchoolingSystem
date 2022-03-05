using System;

namespace SchoolingSystem.Services.Foundations.Etudiants
{
    internal class NumCarteAlreadyExistsException : Exception
    {
        public NumCarteAlreadyExistsException(string numCarte) : base($"Le numero de carte {numCarte} est déja utilisé")
        {
        }
    }
}