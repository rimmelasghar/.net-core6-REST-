using System.Data;
using System.Data.SqlClient;

namespace TodoApi.Models
{
    public class TimeSlot
    {
        public int TSID { get; set; }
        public string TSCode { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int Status { get; set; }
        public int RID { get; set; }

        public DataTable Get_All(IConfiguration configuration)
        {
            string query = @"SELECT * FROM tbl_TimeSlot WHERE Status = 1";
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

        public String Insert_One(IConfiguration configuration,TimeSlot timeSlot)
        {
            string query = @"INSERT INTO tbl_TimeSlot VALUES(@TSCODE,@STARTTIME,@ENDTIME,1,@RID)";
            DataTable dt = new DataTable();
            SqlDataReader sqlDataReader;
            SqlConnection myCon = new SqlConnection(configuration.GetConnectionString("AttendanceAppCon"));
            using (myCon)
            {
                myCon.Open();
                SqlCommand sc = new SqlCommand(query, myCon);
                using (sc)
                {
                    sc.Parameters.AddWithValue("@TSCODE", timeSlot.TSCode);
                    sc.Parameters.AddWithValue("@STARTTIME", timeSlot.StartTime);
                    sc.Parameters.AddWithValue("@ENDTIME", timeSlot.EndTime);
                    sc.Parameters.AddWithValue("@RID", timeSlot.RID);
                    sqlDataReader = sc.ExecuteReader();
                    sqlDataReader.Close();
                    myCon.Close();
                }
            }
            return "TimeSlot Added Successfully";
        }
    }
}
