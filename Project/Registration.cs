using System.ComponentModel.DataAnnotations;
namespace ProjectManagementAPI.Models
{
    public class Registration
    {
        public int Id { get; set; }

        public string User_name { get; set; }
        [Required]
        [MinLength(8)]
        public string UserPassword { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public bool Is_project_manager { get; set; }

        public DateTime Registrationtime { get; set; }
    }
}
