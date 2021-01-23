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

        public User GetByUserName(string userName)
        {
            return GetQueryOver()
                .Where(x => x.NormalizedUserName == userName.ToUpper())
                .SingleOrDefault();
        }

        public User GetByUserEmail(string email)
        {
            return GetQueryOver()
                .Where(x => x.NormalizedEmail == email.ToUpper())
                .SingleOrDefault();
        }
    }
}