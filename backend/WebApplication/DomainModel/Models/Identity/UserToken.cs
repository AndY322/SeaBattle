using System;
using DomainModel.Identity;
using Microsoft.AspNetCore.Identity;
using NHibernate.AspNetCore.Identity;

namespace DomainModel.Models.Identity
{
    public class UserToken : IdentityUserToken
    {
        public virtual User User { get; set; }

        public UserToken()
        {   
        }

        public UserToken(UserToken token)
        {
            if (token == null)
                throw new ArgumentNullException(nameof(token));
            this.Name = token.Name;
            this.UserId = token.UserId;
            this.LoginProvider = token.LoginProvider;
            this.Value = token.Value;
        }

        protected bool Equals(UserToken other) {
            return UserId == other.UserId
                   && LoginProvider == other.LoginProvider
                   && Name == other.Name;
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj)) {
                return false;
            }
            if (ReferenceEquals(this, obj)) {
                return true;
            }
            if (obj.GetType() != GetType()) {
                return false;
            }
            return Equals((UserToken)obj);
        }

        public override int GetHashCode() {
            unchecked {
                var hashCode = 0;
                hashCode = UserId.GetHashCode();
                hashCode = (hashCode * 397) ^ LoginProvider.GetHashCode();
                hashCode = (hashCode * 397) ^ Name.GetHashCode();
                return hashCode;
            }
        }
    }
}