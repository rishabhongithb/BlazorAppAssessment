using System.ComponentModel.DataAnnotations;

namespace BlazorAppAssessmentLibrary
{
    public class Employee
    {
        [Key]
        public Guid UID { get; set; }

        [Required( ErrorMessage = "Please enter First Name")]
        public string FirstName { get; set; } = string.Empty;


        [Required(ErrorMessage = "Please enter Last Name")]
        public string LastName { get; set; } = string.Empty;


        [Required(ErrorMessage = "Please enter Email")]
        [EmailAddress(ErrorMessage = "Please enter valid email address")]
        public string Email { get; set; } = string.Empty;


        [Required(ErrorMessage = "Please enter Address")]
        public string Address { get; set; } = string.Empty;
    }
}
