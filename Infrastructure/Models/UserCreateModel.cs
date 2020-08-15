using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Models
{
    public class UserCreateModel
    {        
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Email { get; set; }
        public virtual string PassWord { get; set; }
    }
}
