using System;

namespace Clockwork.API.Core.Models
{
    public class CurrentTimeQuery: BaseModel
    {
        public DateTime Time { get; set; }
        public string ClientIp { get; set; }
        public DateTime UTCTime { get; set; }
        public string DisplayName { get; set; }
        public string DisplayId { get; set; }
    }
}
