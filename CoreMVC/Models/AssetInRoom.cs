using System;
using System.Collections.Generic;

namespace CoreMVC.Models
{
    public partial class AssetInRoom
    {
        public int AssetInRoomId { get; set; }
        public int? RoomId { get; set; }
        public int? AssetTypeId { get; set; }
        public int? AssetId { get; set; }
        public string Detail { get; set; }
        public int? Amount { get; set; }
        public DateTime? CreateDate { get; set; }
        public string UserCreate { get; set; }
        public DateTime? LastUpdate { get; set; }
        public string UserUpdate { get; set; }
        public bool? RecSt { get; set; }

        public virtual Asset Asset { get; set; }
        public virtual AssetType AssetType { get; set; }
        public virtual Room Room { get; set; }
    }
}
