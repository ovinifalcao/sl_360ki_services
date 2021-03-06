using System;
using System.Collections.Generic;

#nullable disable

namespace API.app360ki_services.Models
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
        public virtual OpUserService OpUserService { get; set; }
        public virtual ICollection<BsOcurrenceReport> BsOcurrenceReports { get; set; }
        public virtual ICollection<BsOcurrencesReply> BsOcurrencesReplies { get; set; }
    }
}
