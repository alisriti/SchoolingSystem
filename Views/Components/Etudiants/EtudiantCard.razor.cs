using Microsoft.AspNetCore.Components;
using Etudiant = SchoolingSystem.Models.Etudiants.Etudiant;

namespace SchoolingSystem.Views.Components.Etudiants
{
    public partial class EtudiantCard
    {
        [Parameter] public Etudiant Etudiant { get; set; }
    }
}