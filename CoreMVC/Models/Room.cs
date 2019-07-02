using System;
using System.Collections.Generic;

namespace CoreMVC.Models
{
    public partial class Room
    {
        public Room()
        {
            AssetInRoom = new HashSet<AssetInRoom>();
        }

        public int RoomId { get; set; }
        public int? FloorId { get; set; }
        public string RoomName { get; set; }
        public string Detail { get; set; }

        public virtual Floor Floor { get; set; }
        public virtual ICollection<AssetInRoom> AssetInRoom { get; set; }
    }
}
