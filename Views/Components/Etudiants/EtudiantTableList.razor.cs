using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using Etudiant = SchoolingSystem.Models.Etudiants.Etudiant;

namespace SchoolingSystem.Views.Components.Etudiants
{
    public partial class EtudiantTableList
    {
        [Parameter] public List<Etudiant> Etudiants { get; set; }
    }
}