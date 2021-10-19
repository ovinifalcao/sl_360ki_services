using System;
using System.Collections.Generic;

#nullable disable

namespace API.app360ki_services.Models
{
    public partial class KdOcurrence
    {
        public KdOcurrence()
        {
            BsOcurrenceReports = new HashSet<BsOcurrenceReport>();
        }

        public int KdOcId { get; set; }
        public string KdOcDesc { get; set; }

        public virtual ICollection<BsOcurrenceReport> BsOcurrenceReports { get; set; }
    }
}
