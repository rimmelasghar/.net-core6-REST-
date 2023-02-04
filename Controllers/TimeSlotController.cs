using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeSlotController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public TimeSlotController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get() 
        {
            DataTable dt = new TimeSlot().Get_All(_configuration);
            return new JsonResult(dt);
        }

        [HttpPost]
        public JsonResult Post(TimeSlot timeSlot)
        {
            string res = new TimeSlot().Insert_One(_configuration, timeSlot);
            return new JsonResult(res);

        }
    }
}
