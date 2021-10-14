using System;
using System.Collections.Generic;

#nullable disable

namespace App360ki_Services.Models
{
    public partial class BsOcurrenceReport
    {
        public BsOcurrenceReport()
        {
            BsOcurrencesReplies = new HashSet<BsOcurrencesReply>();
        }

        public int RptId { get; set; }
        public int UsrgdOwnerFk { get; set; }
        public string Title { get; set; }
        public int KindId { get; set; }
        public string Place { get; set; }
        public int CityZoneId { get; set; }
        public DateTime Moment { get; set; }
        public byte[] Photo { get; set; }

        public virtual KdCityZone CityZone { get; set; }
        public virtual KdOcurrence Kind { get; set; }
        public virtual BsUserResgistered UsrgdOwnerFkNavigation { get; set; }
        public virtual ICollection<BsOcurrencesReply> BsOcurrencesReplies { get; set; }
    }
}
