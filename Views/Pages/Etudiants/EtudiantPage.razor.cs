using Microsoft.AspNetCore.Components;
using SchoolingSystem.Services.ApiServices;
using System;
using Etudiant = SchoolingSystem.Models.Etudiants.Etudiant;

namespace SchoolingSystem.Views.Pages.Etudiants
{
    public partial class EtudiantPage
    {
        [Inject] public IEtudiantService etudiantService { get; set; }

        [Parameter] public string ID { get; set; }

        private Etudiant etudiant;
        private bool hasError = false;
        private string errorMessage = String.Empty;

        protected override void OnInitialized()
        {
            try
            {
                hasError = false;
                errorMessage = String.Empty;
                etudiant = etudiantService.GetEtudiantById(ID);
            }
            catch (Exception e)
            {
                hasError = true;
                errorMessage = e.Message;
            }
        }
    }
}