using System.ComponentModel.DataAnnotations;
namespace ProjectManagementAPI.Models
{
    public class Login
    {
        public int Id { get; set; }

        public string User_name { get; set; }
        [Required]
        [MinLength(8)]
        public string Password { get; set; }
        public int User_role_id { get; set; }
        public int User_id { get; set; }
       
    }
}
