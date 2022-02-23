using Microsoft.AspNetCore.Components;
using SchoolingSystem.Views.Models;

namespace SchoolingSystem.Views.Components.Bases.Switchers
{
    public partial class ListModeSwitcher
    {
        [Parameter] public ListViewMode ViewMode { get; set; }
        [Parameter] public RenderFragment TableMode { get; set; }
        [Parameter] public RenderFragment CardMode { get; set; }

        private RenderFragment GetFragment() =>
            ViewMode switch
            {
                ListViewMode.Table => TableMode,
                ListViewMode.Cards => CardMode
            };
    }
}