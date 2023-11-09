using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Utils
{
    public interface IUnitOfWork
    {
        T Get<T>(int id) where T : class;
        void SaveOrUpdate<T>(T entity);
        void Delete<T>(T entity);
        IQueryable<T> Query<T>();
        ISQLQuery CreateSQLQuery(string queryString);
        void Commit();
    }

}
