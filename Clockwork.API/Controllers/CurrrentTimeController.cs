using Clockwork.API.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Clockwork.API.Controllers
{
    [Route("api/currenttime")]
    public class CurrentTimeController : Controller
    {
        private readonly ICurrentTimeRepository _currentTimeRepository;
        public CurrentTimeController(ICurrentTimeRepository currentTimeRepository)
        {
            _currentTimeRepository = currentTimeRepository;
        }
        [Route("get")]
        // GET api/currenttime
        [HttpGet]
        public async Task<JsonResult> Get()
        {
            return  Json(new
            {
                success = true,
                data = await _currentTimeRepository.Get()
            }); 
        }
    }
}
