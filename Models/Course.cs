
using System.Data;
using System.Data.SqlClient;

namespace TodoApi.Models
{
    public class Course
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public float CourseFee { get; set; }
        public string CreditHour { get; set; }
        public string CourseCode { get; set; }
        public int Status { get; set; }

        public DataTable Get_All(IConfiguration configuration)
        {
            string query = @"SELECT * FROM tbl_Course WHERE Status = 1 ORDER BY 1 DESC";
            DataTable dt = new DataTable();
            SqlDataReader sqlDataReader;
            SqlConnection myCon = new SqlConnection(configuration.GetConnectionString("AttendanceAppCon"));
            using (myCon)
            {
                myCon.Open();
                SqlCommand sc = new SqlCommand(query, myCon);
                using (sc)
                {
                    sqlDataReader = sc.ExecuteReader();
                    dt.Load(sqlDataReader);
                    sqlDataReader.Close();
                    myCon.Close();

                }
            }
            return dt;
        }
    }
}
