using Blello.Helpers;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blello.Components.DragAndDrop
{
    public class DropZone<TItem> : ComponentBase
    {
        /// <summary>
        /// Place your own markup / razor syntax in here
        /// </summary>
        [Parameter] protected RenderFragment<TItem> DropContent { get; set; }
        /// <summary>
        /// Data that will identify this drop zone
        ///</summary>
        [Parameter] protected TItem DataItem { get; set; }
        /// <summary>
        /// What type of drop to allow - default to "move"
        ///</summary>
        [Parameter] protected string DropType { get; set; } = "move";
        /// <summary>
        /// CSS class to use on the dropzone
        ///</summary>
        [Parameter] protected string DropZoneClass { get; set; } 
        /// <summary>
        /// CSS class to use when this is the active dropzone
        ///</summary>
        [Parameter] protected string ActiveClass { get; set; }
        /// <summary>
        /// Flag to indicate if this is the active dropzone
        ///</summary>
        [Parameter] protected bool IsDropTarget { get; set; }
        /// <summary>
        /// Flag to enable console logging
        ///</summary>
        [Parameter] protected bool Debug { get; set; }

        [Parameter] protected Action<UIDragEventArgs, object> OnDragEnter { get; set; }
        [Parameter] protected Action<UIDragEventArgs, object> OnDragDrop { get; set; }
        [Parameter] protected Action<UIDragEventArgs, object> OnDragLeave { get; set; }

        string OuterClassList => new CssBuilder()
            .AddClass(DropZoneClass)
            .AddClass(ActiveClass, IsDropTarget)
            .Build();

        string DragOverJS => $"if (event.preventDefault) {{ event.preventDefault(); }}; event.dataTransfer.dropEffect = '{DropType}'; return false;";

        void MyDragEnter(UIDragEventArgs args)
        {
            if (Debug) Console.WriteLine($"DZ:{DataItem} ENTER");
            IsDropTarget = true;
            OnDragEnter?.Invoke(args, DataItem);
        }

        void MyDragLeave(UIDragEventArgs args)
        {
            if (Debug) Console.WriteLine($"DZ:{DataItem} LEAVE");
            IsDropTarget = false;
            OnDragLeave?.Invoke(args, DataItem);
        }

        void MyDragDrop(UIDragEventArgs args)
        {
            if (Debug) Console.WriteLine($"DZ:{DataItem} DROP");
            IsDropTarget = false;
            OnDragDrop?.Invoke(args, DataItem);
        }
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.RenderTree.RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);
            int c = 0;
            builder.OpenElement(c++, "drop-zone");
            if (!string.IsNullOrWhiteSpace(OuterClassList))
            {
                builder.AddAttribute(c++, "class", OuterClassList);
            }
            builder.AddAttribute(c++, "ondragover", DragOverJS);
            builder.AddAttribute(c++, "ondragleave", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.UIDragEventArgs>(this, MyDragLeave));
            builder.AddAttribute(c++, "ondrop", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.UIDragEventArgs>(this, MyDragDrop));
            builder.AddAttribute(c++, "ondragenter", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.UIDragEventArgs>(this, MyDragEnter));
            builder.AddContent(c++, DropContent(DataItem));
            builder.CloseElement();
        }
    }
}
