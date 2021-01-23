using System.Collections.Generic;
using DomainModel.Models.Identity;
using NHIdentityUser = NHibernate.AspNetCore.Identity.IdentityUser;

namespace DomainModel.Identity
{
    public class User : NHIdentityUser
    {
        public virtual ICollection<Role> Roles { get; protected set; }
        public virtual ICollection<UserLogin> UserLogins { get; protected set; }
        public virtual ICollection<UserToken> UserTokens { get; protected set; }
        public virtual ICollection<UserClaim> UserClaims { get; protected set; }

        public User()
        {
        }
    }
}