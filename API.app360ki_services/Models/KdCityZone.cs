using System;
using System.Collections.Generic;

#nullable disable

namespace API.app360ki_services.Models
{
    public partial class KdCityZone
    {
        public KdCityZone()
        {
            BsOcurrenceReports = new HashSet<BsOcurrenceReport>();
            BsUserResgistereds = new HashSet<BsUserResgistered>();
        }

        public int KdCtZnId { get; set; }
        public string KdCtZnDesc { get; set; }

        public virtual ICollection<BsOcurrenceReport> BsOcurrenceReports { get; set; }
        public virtual ICollection<BsUserResgistered> BsUserResgistereds { get; set; }
    }
}
