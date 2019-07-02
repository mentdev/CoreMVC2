using System;
using System.Collections.Generic;

namespace CoreMVC.Models
{
    public partial class Building
    {
        public Building()
        {
            Floor = new HashSet<Floor>();
        }

        public int BuildingId { get; set; }
        public string BuildingName { get; set; }
        public string BuildingCode { get; set; }
        public string Detail { get; set; }
        public string Location { get; set; }

        public virtual ICollection<Floor> Floor { get; set; }
    }
}
