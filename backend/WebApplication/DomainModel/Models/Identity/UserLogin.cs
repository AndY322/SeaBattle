using DomainModel.Identity;
using NHibernate.AspNetCore.Identity;

namespace DomainModel.Models.Identity
{
    public class UserLogin : IdentityUserLogin
    {
        public virtual User User { get; set; }
    }
}