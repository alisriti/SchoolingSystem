using Microsoft.AspNetCore.Components;
using SchoolingSystem.Models.Etudiants;
using SchoolingSystem.Services.Processors;
using System;

namespace SchoolingSystem.Views.Pages.Etudiants
{
    public partial class NewEtudiantPage
    {
        [Inject] public NavigationManager navigationManager { get; set; }

        [Inject] public IRegistrationService RegistrationService { get; set; }

        private NewEtudiantModel newEtudiant;

        private bool hasError = false;
        private string errorMessage = string.Empty;

        protected override void OnInitialized()
        {
            newEtudiant = new NewEtudiantModel();
        }

        private void creerEtudiant()
        {
            hasError = false;
            try
            {
                RegistrationService.RegisterEtudiant(newEtudiant);

                navigationManager.NavigateTo("/etudiants");
            }
            catch (Exception e)
            {
                errorMessage = $"{e.Message} : {e.InnerException?.Message}";
                hasError = true;
            }
        }
    }
}