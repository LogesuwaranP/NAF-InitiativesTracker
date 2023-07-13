using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InitiativesTracker.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string? DataOfBirth { get; set; }
        public string Password { get; set; }

        [Display(Name= "Role")]
        public int UserType { get; set; }

        [Required]
        [ForeignKey("UserType")]
        public virtual Role? Role { get; set; }



    }
}
