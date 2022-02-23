using Microsoft.AspNetCore.Components;
using SchoolingSystem.Managers.Storages.Etudiants;
using SchoolingSystem.Models.Etudiants;
using SchoolingSystem.Views.Models;
using System.Collections.Generic;

namespace SchoolingSystem.Views.Pages.Etudiants
{
    public partial class ListEtudiantsPage
    {
        [Inject] private IEtudiantStore etudiantStore { get; set; }

        private List<Etudiant> etudiants;
        private ListViewMode viewMode = ListViewMode.Table;

        protected override void OnInitialized()
        {
            etudiants = etudiantStore.SelectEtudiants();
        }

        private void switchToTable() => viewMode = ListViewMode.Table;

        private void switchToCards() => viewMode = ListViewMode.Cards;
    }
}