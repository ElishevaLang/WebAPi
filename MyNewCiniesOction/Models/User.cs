using System.ComponentModel.DataAnnotations;

namespace MyNewCiniesOction.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        [Phone]
        public string UserPhone { get; set; }
        [EmailAddress]
        public string UserEmail { get; set; }
        public bool UserIsAdmin { get; set; }
    }
}
