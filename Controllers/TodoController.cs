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
            string query = @"SELECT * FROM Todo WHERE Status = 1 ORDER BY 1 DESC";
            DataTable dt = new DataTable();
            SqlDataReader sqlDataReader;
            using (SqlConnection myCon = new SqlConnection(_configuration.GetConnectionString("AttendanceAppCon")))
            {
                myCon.Open();
                using (SqlCommand sc = new SqlCommand(query, myCon))
                {
                    sqlDataReader = sc.ExecuteReader();
                    dt.Load(sqlDataReader);
                    sqlDataReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(dt);
        }

        [HttpPost]
        public JsonResult Post(Todo todo)
        {
            string query = @"INSERT INTO Todo VALUES(@Todo,@Category,@Priority,1,@Due_Date)";
            DataTable dt = new DataTable();
            SqlDataReader sqlDataReader;
            using (SqlConnection myCon = new SqlConnection(_configuration.GetConnectionString("AttendanceAppCon")))
            {
                myCon.Open();
                using (SqlCommand sc = new SqlCommand(query, myCon))
                {
                    sc.Parameters.AddWithValue("@Todo", todo.todo);
                    sc.Parameters.AddWithValue("@Category", todo.Category);
                    sc.Parameters.AddWithValue("@Priority", todo.Priority);
                    sc.Parameters.AddWithValue("@Due_Date", todo.Due_Date);
                    sqlDataReader = sc.ExecuteReader();
                    dt.Load(sqlDataReader);
                    sqlDataReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Todo Added Successfully");
        }

        [HttpPut]
        public JsonResult Put(Todo todo)
        {
            string query = @"UPDATE Todo 
                            SET Todo = @Todo,
                                Category = @Category,
                                priority = @Priority,
                                Due_Date = @Due_Date
                            WHERE TID = @TID";
            DataTable dt = new DataTable();
            SqlDataReader sqlDataReader;
            using (SqlConnection myCon = new SqlConnection(_configuration.GetConnectionString("AttendanceAppCon")))
            {
                myCon.Open();
                using (SqlCommand sc = new SqlCommand(query, myCon))
                {
                    sc.Parameters.AddWithValue("@Todo", todo.todo);
                    sc.Parameters.AddWithValue("@Category", todo.Category);
                    sc.Parameters.AddWithValue("@Priority", todo.Priority);
                    sc.Parameters.AddWithValue("@Due_Date", todo.Due_Date);
                    sc.Parameters.AddWithValue("@TID", todo.TID);
                    sqlDataReader = sc.ExecuteReader();
                    dt.Load(sqlDataReader);
                    sqlDataReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Todo Updated Successfully");
        }

        [HttpDelete]
        public JsonResult Delete(Todo todo)
        {
            string query = @"UPDATE Todo SET Status = 0 WHERE TID = @TID";
            DataTable dt = new DataTable();
            SqlDataReader sqlDataReader;
            using (SqlConnection myCon = new SqlConnection(_configuration.GetConnectionString("AttendanceAppCon")))
            {
                myCon.Open();
                using (SqlCommand sc = new SqlCommand(query, myCon))
                {
                    sc.Parameters.AddWithValue("@TID", todo.TID);
                    sqlDataReader = sc.ExecuteReader();
                    dt.Load(sqlDataReader);
                    sqlDataReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Todo Deleted Successfully");
        }
    }
}

