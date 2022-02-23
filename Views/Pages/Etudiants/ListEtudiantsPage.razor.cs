using Microsoft.AspNetCore.Components;
using SchoolingSystem.Managers.Storages.Etudiants;
using SchoolingSystem.Models.Etudiants;
using System.Collections.Generic;

namespace SchoolingSystem.Views.Pages.Etudiants
{
    public partial class ListEtudiantsPage
    {
        [Inject] private IEtudiantStore etudiantStore { get; set; }

        private List<Etudiant> etudiants;

        protected override void OnInitialized()
        {
            etudiants = etudiantStore.SelectEtudiants();
        }
    }
}