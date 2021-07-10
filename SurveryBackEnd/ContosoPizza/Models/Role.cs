using System.Collections.Generic;

namespace ContosoPizza.Models
{
    public class Role : EntityBase
    {

        public string RoleName { get; set; }

        public virtual IEnumerable<UserRole> UserRole { get; set; }
    }
}