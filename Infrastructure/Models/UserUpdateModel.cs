using System.ComponentModel.DataAnnotations;
namespace Infrastructure.Models
{
    public class UserUpdateModel
    {
        [Required]
        public virtual string FirstName { get; set; }

        [Required]
        public virtual string LastName { get; set; }

        [Required]
        public virtual string Email { get; set; }

        [Required]
        public virtual string PassWord { get; set; }
    }
}
