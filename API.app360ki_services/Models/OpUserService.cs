using System;
using System.Collections.Generic;

#nullable disable

namespace API.app360ki_services.Models
{
    public partial class OpUserService
    {
        public int UsrgdFk { get; set; }
        public long PhoneNum { get; set; }
        public string Wsp { get; set; }

        public virtual BsUserResgistered UsrgdFkNavigation { get; set; }
    }
}
