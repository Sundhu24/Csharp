namespace ProjectManagementAPI.Models
{
    public class Project
    {
        public int Id { get; set; }
               
        public string Project_name { get; set; }
        public string Project_desc { get; set; }
        public int Client_id { get; set; }
        public DateTime Created_date { get; set; }
        public int Project_manager_id { get; set; }
        public string Status { get; set; }

    }
    public class Project_Status
    {
        public int Id { get; set; }
        public string Project_name { get; set; }
        public int Project_manager_id { get; set; }
        public string Status { get; set; }

    }
}
