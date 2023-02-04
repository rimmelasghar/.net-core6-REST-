using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public TodoController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]

        public JsonResult Get()
        {
            System.Data.DataTable dt = new Todo().Get_All(_configuration);
            return new JsonResult(dt);
        }

        [HttpPost]
        public JsonResult Post(Todo todo)
        {
            string res = new Todo().Insert_One(_configuration, todo);
            return new JsonResult(res);
        }

        [HttpPut]
        public JsonResult Put(Todo todo)
        {
            string res = new Todo().Update_One(_configuration, todo);
            return new JsonResult(res);
        }

        [HttpDelete]
        public JsonResult Delete(Todo todo)
        {
            string res = new Todo().Delete_One(_configuration, todo);
            return new JsonResult(res);
        }
    }
}

