using Blazor.Blello.Helpers;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;

namespace Blazor.Blello.DragAndDrop
{
    public class DropZone<TItem> : ComponentBase
    {
        /// <summary>
        /// Place your own markup / razor syntax in here
        /// </summary>
        [Parameter] public RenderFragment<TItem> DropContent { get; set; }
        /// <summary>
        /// Data that will identify this drop zone
        ///</summary>
        [Parameter] public TItem DataItem { get; set; }
        /// <summary>
        /// What type of drop to allow - default to "move"
        ///</summary>
        [Parameter] public string DropType { get; set; } = "move";
        /// <summary>
        /// CSS class to use on the dropzone
        ///</summary>
        [Parameter] public string DropZoneClass { get; set; } 
        /// <summary>
        /// CSS class to use when this is the active dropzone
        ///</summary>
        [Parameter] public string ActiveClass { get; set; }
        /// <summary>
        /// Flag to indicate if this is the active dropzone
        ///</summary>
        [Parameter] public bool IsDropTarget { get; set; }
        /// <summary>
        /// Flag to enable console logging
        ///</summary>
        [Parameter] public bool Debug { get; set; }

        [Parameter] public Action<DragEventArgs, object> OnDragEnter { get; set; }
        [Parameter] public Action<DragEventArgs, object> OnDragDrop { get; set; }
        [Parameter] public Action<DragEventArgs, object> OnDragLeave { get; set; }

        string OuterClassList => new CssBuilder()
            .AddClass(DropZoneClass)
            .AddClass(ActiveClass, IsDropTarget)
            .Build();

        string DragOverJS => $"if (event.preventDefault) {{ event.preventDefault(); }}; event.dataTransfer.dropEffect = '{DropType}'; return false;";
        string DragDropJS => "if (event.preventDefault) event.preventDefault(); if (event.stopPropagation) event.stopPropagation();";

        void MyDragEnter(DragEventArgs args)
        {
            if (Debug) Console.WriteLine($"DZ:{DataItem} ENTER");
            IsDropTarget = true;
            OnDragEnter?.Invoke(args, DataItem);
        }

        void MyDragLeave(DragEventArgs args)
        {
            if (Debug) Console.WriteLine($"DZ:{DataItem} LEAVE");
            IsDropTarget = false;
            OnDragLeave?.Invoke(args, DataItem);
        }

        void MyDragDrop(DragEventArgs args)
        {
            if (Debug) Console.WriteLine($"DZ:{DataItem} DROP");
            IsDropTarget = false;
            OnDragDrop?.Invoke(args, DataItem);
        }
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);
            int c = 0;
            builder.OpenElement(c++, "drop-zone");
            builder.AddAttribute(c++, "ondragover", DragOverJS);
            builder.AddAttribute(c++, "ondrop", DragDropJS);
            builder.AddAttribute(c++, "ondragleave", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.DragEventArgs>(this, MyDragLeave));
            builder.AddAttribute(c++, "ondrop", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.DragEventArgs>(this, MyDragDrop));
            builder.AddAttribute(c++, "ondragenter", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.DragEventArgs>(this, MyDragEnter));
            if (!string.IsNullOrWhiteSpace(OuterClassList))
            {
                c = 10; //Ensure attribute always has the same sequence
                builder.AddAttribute(c++, "class", OuterClassList);
            }
            c = 98; // ensure the closing content is always in sequence
            builder.AddContent(c++, DropContent(DataItem));
            builder.CloseElement();
        }
    }
}
