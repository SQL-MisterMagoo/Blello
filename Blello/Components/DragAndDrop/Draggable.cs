using Blello.Helpers;
using Microsoft.AspNetCore.Components;
using System;

namespace Blello.Components.DragAndDrop
{
    public class Draggable<TItem> : ComponentBase
    {
        /// <summary>
        /// html element id - defaults to pseudo random to prevent diff problems
        /// </summary>
        [Parameter] protected string ID { get; set; } = Math.Abs(Guid.NewGuid().GetHashCode()).ToString();
        /// <summary>
        /// place your markup here
        /// </summary>
        [Parameter] protected RenderFragment<TItem> DragContent { get; set; }
        /// <summary>
        /// A data item to identify the thing being dragged and for rendering the DragContent
        /// </summary>
        [Parameter] protected TItem DataItem { get; set; }
        /// <summary>
        /// HTML5 drag type allowed for this item - required - default is "move"
        /// </summary>
        [Parameter] protected string DragType { get; set; } = "move";
        /// <summary>
        /// CSS class for the draggable item - optional
        /// </summary>
        [Parameter] protected string DraggableClass { get; set; }
        /// <summary>
        /// Should you need to apply an inline style, I'm not going to stop you
        /// </summary>
        [Parameter] protected string DraggableStyle { get; set; }
        /// <summary>
        /// Flag that identifies if this item is the thing being dragged
        /// </summary>
        [Parameter] protected bool IsDragItem { get; set; }
        /// <summary>
        /// CSS class to apply when IsDragItem is true
        /// </summary>
        [Parameter] protected string DragItemClass { get; set; }
        /// <summary>
        /// Flag to enable console logging
        /// </summary>
        [Parameter] protected bool Debug { get; set; }

        [Parameter] protected Action<UIDragEventArgs, TItem> OnDragStart { get; set; }
        [Parameter] protected Action<UIDragEventArgs, TItem> OnDragEnd { get; set; }

        string ClassList => new CssBuilder()
          .AddClass(DraggableClass, !IsDragItem)
          .AddClass(DragItemClass, IsDragItem)
          .Build();

        void MyDragStart(UIDragEventArgs args)
        {
            if (Debug) Console.WriteLine($"DS: {DataItem}");
            args.DataTransfer.EffectAllowed = DragType;
            args.DataTransfer.Types = new string[] { "text/plain" };
            args.DataTransfer.Items = new UIDataTransferItem[] { new UIDataTransferItem() { Kind = "string", Type = "text/plain" } };
            OnDragStart?.Invoke(args, DataItem);
        }
        void MyDragEnd(UIDragEventArgs args)
        {
            if (Debug) Console.WriteLine($"DE: {DataItem}");
            OnDragEnd?.Invoke(args, DataItem);
        }
        string DragStartJS => "event.dataTransfer.effectAllowed = 'move'; event.dataTransfer.setData('text/plain', event.target.id);";
        string DragEndJS => "event.stopPropagation();";

        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.RenderTree.RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);
            int c = 0;
            builder.OpenElement(c++, "drag-item");
            builder.AddAttribute(c++, "id", ID);
            if (!string.IsNullOrWhiteSpace(ClassList))
            {
                builder.AddAttribute(c++, "class", ClassList);
            }
            builder.AddAttribute(c++, "draggable", "true");
            if (!string.IsNullOrWhiteSpace(DraggableStyle))
            {
                builder.AddAttribute(c++, "style", DraggableStyle);
            }
            builder.AddAttribute(c++, "ondragstart", DragStartJS);
            builder.AddAttribute(c++, "ondragend", DragEndJS);
            builder.AddAttribute(c++, "ondragstart", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.UIDragEventArgs>(this, MyDragStart));
            builder.AddAttribute(c++, "ondragend", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.UIDragEventArgs>(this, MyDragEnd));
            builder.AddContent(c++, DragContent(DataItem));
            builder.CloseElement();
        }
    }
}