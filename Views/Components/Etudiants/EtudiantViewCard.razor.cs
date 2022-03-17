using Microsoft.AspNetCore.Components;
using Etudiant = SchoolingSystem.Models.Etudiants.Etudiant;

namespace SchoolingSystem.Views.Components.Etudiants
{
    public partial class EtudiantViewCard
    {
        [Parameter] public Etudiant Etudiant { get; set; }
    }
}