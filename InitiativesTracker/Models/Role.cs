using System.ComponentModel.DataAnnotations;

namespace InitiativesTracker.Models
{
    public class Role
    {
        public int Id { get; set; }

        [Required]
        public string role { get; set; }
    }
}
