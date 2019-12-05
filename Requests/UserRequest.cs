using System.ComponentModel.DataAnnotations;

namespace WebApplication3GraphQL.Requests
{
    public class UserRequest
    {
        [Required(ErrorMessage = "Username field is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email field is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password field is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "First name field is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name field is required")]
        public string LastName { get; set; }
    }
}