namespace ProjectManagementAPI.Models
{
    public class ResponseModel
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<dynamic> Data { get; set; }
    }
    public class StatusResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
    }

    public class DateResponse
    {
        public string Message { get; set; }
        public DateTime Start_date { get; set; }

        public DateTime End_date { get; set; }
    }
}
