using Microsoft.AspNetCore.Components;
using SchoolingSystem.Services.ApiServices;
using SchoolingSystem.Views.Models;
using System.Collections.Generic;
using Etudiant = SchoolingSystem.Models.Etudiants.Etudiant;

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