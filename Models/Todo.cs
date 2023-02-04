using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace TodoApi.Models
{
    public class Todo
    {
        public int TID { get; set; }
        public string todo { get; set; }
        public string Category { get; set; }
        public string? Priority { get; set; }
        public int Status { get; set; }
        public string? Due_Date { get; set; }

        public DataTable Get_All(IConfiguration configuration)
        {
            string query = @"SELECT * FROM Todo WHERE Status = 1 ORDER BY 1 DESC";
            DataTable dt = new DataTable();
            SqlDataReader sqlDataReader;
            using (SqlConnection myCon = new SqlConnection(configuration.GetConnectionString("AttendanceAppCon")))
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
            return dt;
        }

        public String Insert_One(IConfiguration configuration,Todo todo)
        {
            string query = @"INSERT INTO Todo VALUES(@Todo,@Category,@Priority,1,@Due_Date)";
            DataTable dt = new DataTable();
            SqlDataReader sqlDataReader;
            using (SqlConnection myCon = new SqlConnection(configuration.GetConnectionString("AttendanceAppCon")))
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
            return "New Todo Added";
        }

        public String Update_One(IConfiguration configuration,Todo todo) 
        {
            string query = @"UPDATE Todo 
                            SET Todo = @Todo,
                                Category = @Category,
                                priority = @Priority,
                                Due_Date = @Due_Date
                            WHERE TID = @TID";

            DataTable dt = new DataTable();
            SqlDataReader sqlDataReader;
            SqlConnection myCon = new SqlConnection(configuration.GetConnectionString("AttendanceAppCon"));
            using (myCon)
            {
                myCon.Open();
                using (SqlCommand sc = new SqlCommand(query,myCon))
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
            return "Todo Updated Successfully";
        }

        public String Delete_One(IConfiguration configuration,Todo todo)
        {

            string query = @"UPDATE Todo SET Status = 0 WHERE TID = @TID";
            DataTable dt = new DataTable();
            SqlDataReader sqlDataReader;
            using (SqlConnection myCon = new SqlConnection(configuration.GetConnectionString("AttendanceAppCon")))
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
            return ("Todo Deleted Successfully");
        }
    }
}
