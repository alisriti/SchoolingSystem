using Microsoft.AspNetCore.Components;
using SchoolingSystem.Models.Etudiants;

namespace SchoolingSystem.Views.Components.Etudiants
{
    public partial class EtudiantViewCard
    {
        [Parameter] public Etudiant Etudiant { get; set; }
    }
}