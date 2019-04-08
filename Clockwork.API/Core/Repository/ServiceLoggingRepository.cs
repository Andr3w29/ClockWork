using Clockwork.API.Enum;
using Clockwork.API.Interface;
using Clockwork.API.Models;
using Clockwork.API.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clockwork.API.Repository
{
    public class ServiceLoggingRepository : IServiceLoggingRepository
    {
        public ServiceLoggingRepository()
        {
      
        }
        public async Task<int> Add(ServiceLogging serviceLogging)
        {
            using (var context = new ClockworkContext())
            {
                context.ServiceLoggings.Add(serviceLogging);
                return await context.SaveChangesAsync();
            }
          
        }

        public async Task<ServiceLogViewModel> GetServiceLogById(int logId)
        {
            using (var context = new ClockworkContext())
            {
                return await context.ServiceLoggings.Where(x => x.ID== logId).Select(x => new ServiceLogViewModel()
                {
                    Id = x.ID,
                    CreatedOn = x.CreatedOn.Value,
                    LogType = x.Type == LogType.Request ? "Request" : "Response",
                    Domain = x.Domain,
                    MessageDisplay = x.Message.Length > 100 ? x.Message.Substring(0, 100) : x.Message,
                    Month = x.CreatedOn.Value.ToString("MMM"),
                    DayOfWeek = x.CreatedOn.Value.DayOfWeek.ToString(),
                    Day = x.CreatedOn.Value.Day.ToString(),
                   Time= x.CreatedOn.Value.ToString("HH:mm:ss"),
                    User = x.User,
                    WorkStation = x.WorkStation
                }).FirstOrDefaultAsync();
            }
        }

        public async Task<List<ServiceLogViewModel>> GetServiceLogs()
        {
            using (var context = new ClockworkContext())
            { 
                return  await context.ServiceLoggings.OrderByDescending(x => x.CreatedOn).Take(20).Select(x=> new ServiceLogViewModel()
                {
                    Id = x.ID,
                    CreatedOn = x.CreatedOn.Value,
                    LogType = x.Type == LogType.Request ? "Request" : "Response",
                    Domain = x.Domain,

                    MessageDisplay = x.Message.Length > 200 ? x.Message.Substring(0, 200) : x.Message,
                    User = x.User,
                    WorkStation = x.WorkStation
                }).ToListAsync();
            }
        }
    }
}
