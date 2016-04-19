using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace GL.DAL
{
    public abstract class BaseEntity<T>
    {
        public virtual T Insert(T data)
        {
            using (var session = HibernateHelper.OpenSession())
            using(var tran = session.BeginTransaction())
            {
                try
                {
                    session.SaveOrUpdate(data);
                }
                catch (NHibernate.HibernateException exception)
                {
                    System.Diagnostics.Trace.WriteLine(exception.Message);
                    System.Diagnostics.Trace.WriteLine(exception.StackTrace);
                    tran.Rollback();
                }
                finally
                {
                    tran.Commit();
                }
            }

            return data;
        }

        public virtual T Update(T data)
        {
            return data;
        }

        public virtual bool Delete(int id)
        {
            return true;
        }

        public virtual IList<T> GetAll()
        {
            using (var session = HibernateHelper.OpenSession())
            {
                ICriteria hibObject = session.CreateCriteria(typeof(T));
                return hibObject.List<T>();
            }
        }

        public virtual IQueryable<T> GetByID<T>() where T:class 
        {
            using (var session = HibernateHelper.OpenSession())
            {
                return session.QueryOver<T>().List().AsQueryable();
            }
        }
    }
}
