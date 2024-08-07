using System.ComponentModel.DataAnnotations;

namespace CDNFreelancers.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        public string Skillsets { get; set; }

        public string Hobby { get; set; }
    }
}
