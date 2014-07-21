using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySite.Mappings;
using MySite.Models;
using MySite.Repositories;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySite.Tests.Repositories
{
    [TestClass]
    public class LogRepository
    {
        protected static ISessionFactory _sessionFactory;
        protected static FluentConfiguration _configuration;

        protected static void CreateSchema()
        {
            _configuration = Fluently.Configure()
              .Database(
                  MsSqlConfiguration.MsSql2012.ShowSql().ConnectionString(@"Server=localhost;Database=MySiteModel;Trusted_Connection=True;"))
              .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Log>());

            _sessionFactory = _configuration.BuildSessionFactory(); ;

            new SchemaExport(_configuration.BuildConfiguration()).Create(false, true);
        }

        [TestMethod]
        public void PuedoCrearUnLogValido()
        {
            var id = 1;
            var severity = 1;
            var message = "un log";

            var aLog = new Log(id, severity, message);
            Assert.IsNotNull(aLog);
            Assert.AreEqual(id, aLog.Id);
            Assert.AreEqual(severity, aLog.Severity);
            Assert.AreEqual(message, aLog.Message);
        }

        [TestMethod]
        public void PuedoAgregarUnLogValido()
        {
            CreateSchema();

            var aLog = new Log(1, 1, "un log");
            var unRepo = new Repository<Log>(_sessionFactory);
            unRepo.Add(aLog);
            Assert.AreEqual(unRepo.Get(1), aLog);
        }
    }
}
