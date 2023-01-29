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
    }
}
