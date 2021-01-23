using System.Collections.Generic;
using DomainModel.Models.Identity;
using NHIdentityRole = NHibernate.AspNetCore.Identity.IdentityRole;

namespace DomainModel.Identity
{
    public class Role : NHIdentityRole
    {
        public virtual ICollection<User> Users { get; protected set; }
        public virtual ICollection<RoleClaim> RoleClaims { get; protected set; }
    }
}