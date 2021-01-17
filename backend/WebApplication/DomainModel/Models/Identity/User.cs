using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using DomainModel.Models.Identity;

namespace DomainModel.Identity
{
    public class User : IdentityUser<string>
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