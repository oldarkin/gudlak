using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GL.DAL
{
    public class HibernateHelper
    {
        private static ISessionFactory mIsessionFactory;

        public static ISession OpenSession()
        {
            //if (mIsessionFactory == null)
            //{
            //    Configuration configuration = new Configuration();
            //    configuration.Configure();
            //    mIsessionFactory = configuration.BuildSessionFactory();
            //}

            return mIsessionFactory.OpenSession();
        }

        public static ISessionFactory SessionFactory
        {
            get { return mIsessionFactory; }
            set { mIsessionFactory = value; }
        }
    }
}
