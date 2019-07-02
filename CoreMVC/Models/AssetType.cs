using System;
using System.Collections.Generic;

namespace CoreMVC.Models
{
    public partial class AssetType
    {
        public AssetType()
        {
            AssetInRoom = new HashSet<AssetInRoom>();
        }

        public int AssetTypeId { get; set; }
        public string AssetTypeName { get; set; }

        public virtual ICollection<AssetInRoom> AssetInRoom { get; set; }
    }
}
