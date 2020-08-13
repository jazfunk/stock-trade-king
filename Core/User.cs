using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class User
    {
        public virtual int Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string PassWord { get; set; }
        public virtual string Email { get; set; }
    }
}
