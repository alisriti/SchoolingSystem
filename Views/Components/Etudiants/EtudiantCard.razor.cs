using Microsoft.AspNetCore.Components;
using SchoolingSystem.Models.Etudiants;

namespace SchoolingSystem.Views.Components.Etudiants
{
    public partial class EtudiantCard
    {
        [Parameter] public Etudiant Etudiant { get; set; }
    }
}