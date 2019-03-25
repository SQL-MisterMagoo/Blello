using System;

namespace Blello.Model
{
    public class BoardItem
    {
        public int BoardId { get; set; }
        public string Content { get; set; }
        public string ItemID { get; set; }

        public BoardItem()
        {
            ItemID = Math.Abs(Guid.NewGuid().GetHashCode()).ToString();
        }
    }
}
