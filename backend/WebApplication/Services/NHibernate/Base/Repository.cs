using NHibernate;
using Services.NHibernate.Base.Interfaces;

namespace Services.NHibernate.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ISession _session;
        private ITransaction _transaction;

        protected Repository(ISession session)
        {
            _session = session;
        }
        
        public void BeginTransaction()
        {
            _transaction = _session.BeginTransaction();
        }

        public void Commit()
        {
            _transaction.Commit();
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }

        public void CloseTransaction()
        {
            if(_transaction != null)
            {
                _transaction.Dispose();
                _transaction = null;
            }
        }

        public void Save(T entity)
        {
            _session.Save(entity);
        }

        public void Delete(T entity)
        {
            _session.Delete(entity);
        }

        public virtual IQueryOver<T, T> GetQueryOver() => _session.QueryOver<T>();
    }
}