using Microsoft.AspNetCore.Components;
using SchoolingSystem.Models.Etudiants;
using System.Collections.Generic;

namespace SchoolingSystem.Views.Components.Etudiants
{
    public partial class EtudiantTableList
    {
        [Parameter] public List<Etudiant> Etudiants { get; set; }
    }
}