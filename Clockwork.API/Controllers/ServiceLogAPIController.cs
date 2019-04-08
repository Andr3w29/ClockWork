using Clockwork.API.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Clockwork.API.Controllers
{
    [Produces("application/json")]
    [Route("/api/servicelog")]
    public class ServiceLogAPIController : Controller
    {
        private readonly IServiceLoggingRepository _serviceLoggingRepository;
        public ServiceLogAPIController(IServiceLoggingRepository serviceLoggingRepository)
        {
            _serviceLoggingRepository = serviceLoggingRepository;
        }
        [Route("getserviceogs")]
        [HttpGet]
        public async  Task<JsonResult> GetServiceLogs()
        {
            return Json(new
            {
                success = true,
                data = await _serviceLoggingRepository.GetServiceLogs()
            });
       
        }
        [Route("getservicelogbyid/{logid}")]
        [HttpGet]
        public async Task<JsonResult> GetServiceLogById(int logid)
        {
            return Json(new
            {
                success = true,
                data = await _serviceLoggingRepository.GetServiceLogById(logid)
            });

        }
    }
}
