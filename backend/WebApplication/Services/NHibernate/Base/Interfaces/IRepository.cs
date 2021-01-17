using NHibernate;

namespace Services.NHibernate.Base.Interfaces
{
    public interface IRepository<T>
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
        void CloseTransaction();
        void Save(T entity);
        void Delete(T entity);
 
        IQueryOver<T> GetQueryOver { get; }
    }
}