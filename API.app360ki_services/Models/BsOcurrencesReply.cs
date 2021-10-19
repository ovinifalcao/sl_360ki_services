using System;
using System.Collections.Generic;

#nullable disable

namespace API.app360ki_services.Models
{
    public partial class BsOcurrencesReply
    {
        public int RptFk { get; set; }
        public int UsrgdFk { get; set; }
        public int KindId { get; set; }
        public DateTime Moment { get; set; }

        public virtual BsOcurrenceReport RptFkNavigation { get; set; }
        public virtual BsUserResgistered UsrgdFkNavigation { get; set; }
    }
}
