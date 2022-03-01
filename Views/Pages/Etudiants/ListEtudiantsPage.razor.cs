using Microsoft.AspNetCore.Components;
using SchoolingSystem.Models.Etudiants;
using SchoolingSystem.Services.Foundations.Etudiants;
using SchoolingSystem.Views.Models;
using System.Collections.Generic;

namespace SchoolingSystem.Views.Pages.Etudiants
{
    public partial class ListEtudiantsPage
    {
        [Inject] private IEtudiantService etudiantService { get; set; }

        private List<Etudiant> etudiants;
        private ListViewMode viewMode = ListViewMode.Table;

        protected override void OnInitialized()
        {
            etudiants = etudiantService.GetEtudiants();
        }

        private void switchToTable() => viewMode = ListViewMode.Table;

        private void switchToCards() => viewMode = ListViewMode.Cards;
    }
}