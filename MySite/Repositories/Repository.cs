using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using MySite.Models;
using NHibernate;

namespace MySite.Repositories
{
    public class Repository<T>
    {
        ISessionFactory sessionFactory; /* = Fluently.Configure()
            .Database(MsSqlConfiguration.MsSql2012.ConnectionString(c => c.Server("localhost")
                                                                .Database("MySiteModel")
                                                                .TrustedConnection()))
            .Mappings(m => m.AutoMappings
                            .Add(AutoMap.AssemblyOf<Log>()))
            .BuildSessionFactory();*/

        protected Repository()
        { }

        public Repository(ISessionFactory session)
        {
            sessionFactory = session;
        }

        public void Add(T anObject)
        {
            try
            {
                var session = sessionFactory.OpenSession();
                session.Save(anObject);
                session.Flush();
            }
            catch
            {
                throw;
            }
            finally
            {
                sessionFactory.Close();
            }
        }

        public T Get(object id)
        {
            try
            {
                return sessionFactory.OpenSession().Get<T>(id);
            }
            catch (System.Exception)
            {

                throw;
            }
            finally
            {
                sessionFactory.Close();
            }
        }
    }
}