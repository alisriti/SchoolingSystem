using SchoolingSystem.Managers.ApiManagers;
using SchoolingSystem.Models.Etudiants;
using System;
using System.Collections.Generic;

namespace SchoolingSystem.Services.ApiServices
{
    public class EtudiantService : IEtudiantService
    {
        private readonly IApiManager apiManager;

        public EtudiantService(IApiManager apiManager)
        {
            this.apiManager = apiManager;
        }

        public List<Etudiant> GetEtudiants()
        {
            try
            {
                return apiManager.GetEtudiants();
            }
            catch (Exception e)
            {
                throw new ApiManagerExecption(e);
            }
        }

        public Etudiant GetEtudiantById(string Id)
        {
            try
            {
                return apiManager.GetEtudiantById(Id);
            }
            catch (Exception e)
            {
                throw new ApiManagerExecption(e);
            }
        }

        public void CreateEtudiant(Etudiant etudiant)
        {
            try
            {
                apiManager.CreateEtudiant(etudiant);
            }
            catch (Exception e)
            {
                throw new ApiManagerExecption(e);
            }
        }
    }

    public class ApiManagerExecption : Exception
    {
        public ApiManagerExecption(Exception exception) :
            base("Echec de l'interfacage avec l'API", exception)
        {
            throw new NotImplementedException();
        }
    }
}