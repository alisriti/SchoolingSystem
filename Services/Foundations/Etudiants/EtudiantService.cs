using AtelierGL.Exceptions;
using SchoolingSystem.Managers.IDManagers;
using SchoolingSystem.Managers.Storages.Etudiants;
using SchoolingSystem.Models.Auditables;
using SchoolingSystem.Models.Etudiants;
using SchoolingSystem.Services.Foundations.Etudiants.Exceptions;
using SchoolingSystem.Services.Mappers.Etudiants;
using System;
using System.Collections.Generic;
using static AtelierGL.Validations.Validators;

namespace SchoolingSystem.Services.Foundations.Etudiants
{
    public partial class EtudiantService : IEtudiantService
    {
        private readonly IEtudiantStore etudiantStore;
        private readonly IEtudiantMapper etudiantMapper;
        private readonly IIDGenerator idGenerator;

        public EtudiantService(
            IEtudiantStore etudiantStore,
            IEtudiantMapper etudiantMapper,
            IIDGenerator idGenerator)
        {
            this.etudiantStore = etudiantStore;
            this.etudiantMapper = etudiantMapper;
            this.idGenerator = idGenerator;
        }

        public List<Etudiant> GetEtudiants()
        {
            return etudiantStore.SelectEtudiants();
        }

        public Etudiant GetEtudiantById(string id)
        {
            try
            {
                ValidateEntry(id, "Vous devez spécifier l'ID de l'étudiant");
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

        public Etudiant GetEtudiantByNumCarte(string numCarte)
        {
            try
            {
                ValidateEntry(numCarte, "Vous devez spécifier un numero de carte");
                Etudiant selectedEtudiant = etudiantStore.SelectEtudiantByNumCarte(numCarte);

                if (selectedEtudiant == null)
                    throw new EtudiantNotFoundException(numCarte);

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

        public void CreateEtudiant(Etudiant etudiantToInsert)
        {
            try
            {
                Auditable auditable = new Auditable()
                {
                    CreatedBy = "sriti ali",
                    CreationDate = DateTime.UtcNow
                };

                ValidateEtudiantforInsert(etudiantToInsert);

                etudiantStore.InsertEtudiant(etudiantToInsert, auditable);
            }
            catch (NullValueException nullEntry)
            {
                throw new CreateEtudiantException(nullEntry);
            }
            catch (InvalidEntryException invalidEntry)
            {
                throw new CreateEtudiantException(invalidEntry);
            }
            catch (InvalidDateException invalidDate)
            {
                throw new CreateEtudiantException(invalidDate);
            }
            catch (InvalidEmailException invalidEmail)
            {
                throw new CreateEtudiantException(invalidEmail);
            }
            catch (NumCarteAlreadyExistsException alreadyExists)
            {
                throw new CreateEtudiantException(alreadyExists);
            }
            catch (Exception exception)
            {
                throw new CreateEtudiantException(exception);
            }
        }

        public bool NumCarteExists(string numCarte) =>
            etudiantStore.SelectEtudiantByNumCarte(numCarte) != null;
    }
}