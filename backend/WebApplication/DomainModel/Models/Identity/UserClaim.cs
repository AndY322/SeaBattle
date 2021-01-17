using DomainModel.Identity;
using NHibernate.AspNetCore.Identity;

namespace DomainModel.Models.Identity
{
    public class UserClaim : IdentityUserClaim
    {
        public virtual User User { get; set; }
    }
}