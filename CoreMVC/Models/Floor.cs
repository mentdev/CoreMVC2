using System;
using System.Collections.Generic;

namespace CoreMVC.Models
{
    public partial class Floor
    {
        public Floor()
        {
            Room = new HashSet<Room>();
        }

        public int FloorId { get; set; }
        public int? BuildingId { get; set; }
        public string FloorName { get; set; }
        public string Detail { get; set; }

        public virtual Building Building { get; set; }
        public virtual ICollection<Room> Room { get; set; }
    }
}
