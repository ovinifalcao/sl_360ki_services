using System.Collections.Generic;

namespace API.app360ki_services.Models.Application
{
    public class ReportsAppInfo
    {
        public BsOcurrenceReport Report { get; set; }
        public List<RepliesAppInfo> Replies { get; set; }
    }
}
