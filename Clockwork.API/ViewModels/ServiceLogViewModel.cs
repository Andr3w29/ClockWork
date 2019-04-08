using System;

namespace Clockwork.API.ViewModels
{
    public class ServiceLogViewModel
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string Domain { get; set; }
        public string WorkStation { get; set; }
        public string Day { get; set; }
        public string Month { get; set; }
        public string DayOfWeek { get; set; }
        public string Time { get; set; }
        public string LogType { get; set; }
        public string Message { get; set; }
        public string MessageDisplay { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
