using DomainModel.Identity;
using NHibernate.AspNetCore.Identity;

namespace DomainModel.Models.Identity
{
    public class RoleClaim : IdentityRoleClaim
    {
        public virtual Role Role { get; set; }
    }
}
