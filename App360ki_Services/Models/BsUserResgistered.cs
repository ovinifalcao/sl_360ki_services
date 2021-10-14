using System;
using System.Collections.Generic;

#nullable disable

namespace App360ki_Services.Models
{
    public partial class BsUserResgistered
    {
        public BsUserResgistered()
        {
            BsOcurrenceReports = new HashSet<BsOcurrenceReport>();
            BsOcurrencesReplies = new HashSet<BsOcurrencesReply>();
        }

        public int UsrgdId { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public int CityZoneId { get; set; }

        public virtual KdCityZone CityZone { get; set; }
        public virtual ICollection<BsOcurrenceReport> BsOcurrenceReports { get; set; }
        public virtual ICollection<BsOcurrencesReply> BsOcurrencesReplies { get; set; }
    }
}
