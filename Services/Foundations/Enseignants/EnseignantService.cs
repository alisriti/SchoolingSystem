using SchoolingSystem.Managers.Storages.Enseignants;
using SchoolingSystem.Models.Ensignants;
using SchoolingSystem.Services.Foundations.Enseignants.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolingSystem.Services.Foundations.Enseignants
{
    public class EnseignantService : IEnseignantService
    {
        private readonly IEnseignantStore enseignantStore;

        public EnseignantService(IEnseignantStore enseignantStore)
        {
            this.enseignantStore = enseignantStore;
        }

        public List<Enseignant> GetEnseignant()
        {
            try
            {
                List<Enseignant> selectedEnseignant = enseignantStore.SelectEnseignants();

                if (!selectedEnseignant.Any())
                    throw new EmptyEnseignantsListException();

                return selectedEnseignant;
            }
            catch (EmptyEnseignantsListException emptyList)
            {
                throw new EnseignantServiceException(emptyList);
            }
            catch (Exception exception)
            {
                throw new EnseignantServiceException(exception);
            }
        }

        public Enseignant GetEnseignantById(string id)
        {
            try
            {
                Enseignant selectedEnseignant = enseignantStore.SelectEnseignantById(id);

                if (selectedEnseignant is null)
                    throw new EnseignantNotFoundException(id);

                return selectedEnseignant;
            }
            catch (EnseignantNotFoundException notFound)
            {
                throw new EnseignantServiceException(notFound);
            }
            catch (Exception exception)
            {
                throw new EnseignantServiceException(exception);
            }
        }
    }
}