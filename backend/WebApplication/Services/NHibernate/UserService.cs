using DomainModel.Identity;
using NHibernate;
using Services.Interfaces;
using Services.NHibernate.Base;

namespace Services
{
    public class UserService : Repository<User>, IUserService
    {
        public UserService(ISession session) : base(session)
        {
        }
    }
}