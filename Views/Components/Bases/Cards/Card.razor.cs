using Microsoft.AspNetCore.Components;

namespace SchoolingSystem.Views.Components.Bases.Cards
{
    public partial class Card
    {
        [Parameter] public string Width { get; set; } = "300px";
        [Parameter] public RenderFragment CardHeader { get; set; }
        [Parameter] public RenderFragment CardBody { get; set; }
        [Parameter] public RenderFragment CardFooter { get; set; }
    }
}