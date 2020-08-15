

using System.ComponentModel.DataAnnotations;

namespace Core
{
    public class User
    {
        [Key]
        public virtual int Id { get; set; }

        [Required]
        public virtual string FirstName { get; set; }

        [Required]
        public virtual string LastName { get; set; }

        [Required]
        public virtual string PassWord { get; set; }

        [Required]
        public virtual string Email { get; set; }
    }
}
