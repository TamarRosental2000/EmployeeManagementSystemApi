using System.Data;
using NHibernate;

namespace Logic.Utils
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly ISession _session;
        private readonly ITransaction _transaction;
        private bool _isAlive = true;

        public UnitOfWork(SessionFactory sessionFactory)
        {

            _session = sessionFactory.OpenSession();
            _transaction = _session.BeginTransaction();
        }

        public void Commit()
        {
            if (!_isAlive)
                return;

            try
            {
                _transaction.Commit();
            }
            finally
            {
            }
        }

        public T Get<T>(int id)
            where T : class
        {
            return _session.Get<T>(id);
        }
        public void SaveOrUpdate<T>(T entity)
        {
            _session.SaveOrUpdate(entity);
        }

        public void Delete<T>(T entity)
        {
            _session.Delete(entity);
        }

        public IQueryable<T> Query<T>()
        {
            return _session.Query<T>();
        }

        public ISQLQuery CreateSQLQuery(string q)
        {
            return _session.CreateSQLQuery(q);
        }
    }
}
