using Clockwork.API.Models;
using Clockwork.API.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Clockwork.API.Interface
{
    public interface IServiceLoggingRepository
    {
        Task<int> Add(ServiceLogging serviceLogging);
        Task<List<ServiceLogViewModel>> GetServiceLogs();
        Task<ServiceLogViewModel> GetServiceLogById(int logId);
        
    }
}
