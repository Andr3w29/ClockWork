using Clockwork.API.Core.Models;
using Clockwork.API.Enum;

namespace Clockwork.API.Models
{
    public class ServiceLogging: BaseModel
    {
        public string User { get; set; }
        public string Domain { get; set; }
        public string WorkStation { get; set; }
        public LogType Type { get; set; }
        public string Message { get; set; }
    }
}
