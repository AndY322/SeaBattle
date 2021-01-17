using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using DomainModel.Models.Identity;

namespace DomainModel.Identity
{
    public class Role : IdentityRole<string>
    {
        public virtual ICollection<User> Users { get; protected set; }
        public virtual ICollection<RoleClaim> RoleClaims { get; protected set; }

        public Role()
        {
        }
    }
}