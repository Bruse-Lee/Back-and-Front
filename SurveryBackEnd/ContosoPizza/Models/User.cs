using System.Collections.Generic;
namespace ContosoPizza.Models
{
    public class User : EntityBase
    {

        public string Username { get; set; }

        public string Password { get; set; }

        public virtual IEnumerable<UserRole> UserRole { get; set; }
    }
}