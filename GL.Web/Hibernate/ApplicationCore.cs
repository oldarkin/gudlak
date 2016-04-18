using NHibernate;

namespace GL.Web
{
    public class ApplicationCore
    {
        private static ISessionFactory mIsessionFactory;

        public static ISession OpenSession()
        {
            return mIsessionFactory.OpenSession();
        }

        public static ISessionFactory SessionFactory
        {
            get { return mIsessionFactory; }
            set { mIsessionFactory = value; }
        }
    }
}