using System;
using System.Collections.Generic;

namespace CoreMVC.Models
{
    public partial class Asset
    {
        public Asset()
        {
            AssetInRoom = new HashSet<AssetInRoom>();
        }

        public int AssetId { get; set; }
        public string AssetCode { get; set; }
        public string AssetName { get; set; }

        public virtual ICollection<AssetInRoom> AssetInRoom { get; set; }
    }
}
