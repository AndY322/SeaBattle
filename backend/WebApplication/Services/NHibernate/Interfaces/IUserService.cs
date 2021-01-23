using DomainModel.Identity;
using Services.NHibernate.Base.Interfaces;

namespace Services.Interfaces
{
    /// <summary>
    /// IUserService
    /// </summary>
    public interface IUserService : IRepository<User>
    {
        User GetByUserName(string userName);
        
        User GetByUserEmail(string email);
    }
}