using SchoolingSystem.Managers.Storages.Etudiants;
using SchoolingSystem.Models.Etudiants;
using SchoolingSystem.Services.Foundations.Etudiants.Exceptions;
using System;
using System.Collections.Generic;

namespace SchoolingSystem.Services.Foundations.Etudiants
{
    public class EtudiantService : IEtudiantService
    {
        private readonly IEtudiantStore etudiantStore;

        public EtudiantService(IEtudiantStore etudiantStore) => this.etudiantStore = etudiantStore;

        public List<Etudiant> GetEtudiants()
        {
            return etudiantStore.SelectEtudiants();
        }

        public Etudiant GetEtudiantById(string id)
        {
            try
            {
                Etudiant selectedEtudiant = etudiantStore.SelectEtudiantById(id);

                if (selectedEtudiant == null)
                    throw new EtudiantNotFoundException(id);

                return selectedEtudiant;
            }
            catch (EtudiantNotFoundException notFound)
            {
                throw new EtudiantServiceException(notFound);
            }
            catch (Exception exception)
            {
                throw new EtudiantServiceException(exception);
            }
        }
    }
}