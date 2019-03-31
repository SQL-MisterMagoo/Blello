using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.RenderTree;
using System;

namespace Blello.Components.Helpers
{
    public class Focus : ComponentBase
    {
        [Parameter] protected string FocusElementId { get; set; }
        [Parameter] protected string FocusChildId { get; set; }
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);
            if (string.IsNullOrWhiteSpace(FocusElementId) && string.IsNullOrWhiteSpace(FocusChildId))
            {
                return;
            }
            builder.OpenElement(0, "img");
            builder.AddAttribute(1, "src", $"/{Guid.NewGuid()}");
            if (!string.IsNullOrWhiteSpace(FocusElementId))
            {
                builder.AddAttribute(2, "onerror", $"document.getElementById('{FocusElementId}').focus()");
            }
            else
            {
                builder.AddAttribute(2, "onerror", $"document.getElementById('{FocusChildId}').querySelector('[tabindex]').focus()");
            }
            builder.AddAttribute(3, "style", "display:none;");
            builder.CloseElement();
            FocusElementId = "";
        }
    }
}
