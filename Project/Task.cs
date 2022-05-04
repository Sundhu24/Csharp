namespace ProjectManagementAPI.Models
{
    public class Task1
    {
       
        public int Project_Id { get; set; }

        public string Task_Title { get; set; }
        public string Status { get; set; }
        public int Assigned_to { get; set; }
        public int Assigned_by { get; set; }

        public DateTime Created_date { get; set; }

        public DateTime Updated_date { get; set; }

        public int Updated_by { get; set; }

        public DateTime End_date { get; set; }


    }
    public class Taskstatus
    {
        public string Task_Title { get; set; }
        public string Status { get; set; }

    }
    public class Task_followup
    {
        public int Id { get; set; }
        public string Activity_name { get; set; }
        public int Task_id { get; set; }
        public string Description { get; set; }
        public int Project_Id { get; set; }
        public DateTime Update_date { get; set; }
             
    }
    public class Team_member
    {
        public int Id { get; set; }
        public int Team_id { get; set; }
        public int Employee_id { get; set; }
        public int Role_id { get; set; }
        public int Project_id { get; set; }

    }
}
