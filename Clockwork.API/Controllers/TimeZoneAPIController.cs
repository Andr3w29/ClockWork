using Clockwork.API.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Clockwork.API.Controllers
{
    [Produces("application/json")]
    [Route("/api/timezone")]
    public class TimeZoneAPIController : Controller
    {
        private readonly ICurrentTimeRepository _currentTimeRepository;
        public TimeZoneAPIController(ICurrentTimeRepository currentTimeRepository)
        {
            _currentTimeRepository = currentTimeRepository;
        }
        [Route("gettimezones")]
        [HttpGet]
        public async Task<JsonResult> GetTimeZones()
        {
            var timeZones = TimeZoneInfo.GetSystemTimeZones();
            

            return Json(new
            {
                success = true,
                data= timeZones.Select(tz => new SelectListItem()
                {
                    Text = tz.DisplayName,
                    Value = tz.Id
                }).ToList()
            });


        }
        [Route("gettimezone/{timezoneid}")]
        [HttpPost]
        public async Task<JsonResult> GetTimeZone(string timeZoneId)
        {
            try
            {
                if (string.IsNullOrEmpty(timeZoneId))
                    return Json(new
                    {
                        success = false,
                        data = "Please select a time zone in the droplist."
                    });

                var timeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
                var dateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZone);
                await _currentTimeRepository.Add(new Core.Models.CurrentTimeQuery()
                {
                    CreatedOn = DateTime.UtcNow,
                    UTCTime = DateTime.UtcNow,
                    ClientIp = HttpContext.Connection.RemoteIpAddress.ToString(),
                    Time = dateTime,
                    DisplayName = timeZone.DisplayName,
                    DisplayId= timeZoneId

                });
                
                return Json(new
                {
                    success = true,
                    displayName = timeZone.DisplayName,
                    time = dateTime.ToString("HH:mm:ss"),
                    month = dateTime.ToString("MMM"),
                    day = dateTime.Day
                });
            }
            catch(Exception ex)
            {
                return Json(new
                {
                    success = false,
                    errorMessage = ex.Message
                   
                });
            }
           

          

            
        }
    }
}
