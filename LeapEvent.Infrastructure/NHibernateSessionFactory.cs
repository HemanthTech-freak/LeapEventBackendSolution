using LeapEvent.Infrastructure.Interfaces;
using NHibernate.Mapping.ByCode;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;

namespace LeapEvent.Infrastructure
{
    public class NHibernateSessionFactory : INHibernateSessionFactory
    {
        public ISessionFactory SessionFactory { get; }

        public NHibernateSessionFactory(string connectionString)
        {
            var config = new Configuration();

            config.DataBaseIntegration(db =>
            {
                db.ConnectionString = connectionString;
                db.Dialect<SQLiteDialect>();
                db.Driver<SQLite20Driver>();
                db.LogFormattedSql = true;
                db.LogSqlInConsole = true;
            });

            var mapper = new ModelMapper();
            mapper.AddMapping<EventMapping>();
            mapper.AddMapping<TicketSaleMapping>();

            config.AddMapping(mapper.CompileMappingForAllExplicitlyAddedEntities());

            SessionFactory = config.BuildSessionFactory();
        }
    }
}
