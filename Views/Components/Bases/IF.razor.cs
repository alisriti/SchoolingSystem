using Microsoft.AspNetCore.Components;

namespace SchoolingSystem.Views.Components.Bases
{
    public partial class IF
    {
        [Parameter] public bool Condition { get; set; }
        [Parameter] public RenderFragment Then { get; set; }
        [Parameter] public RenderFragment Else { get; set; }
    }
}