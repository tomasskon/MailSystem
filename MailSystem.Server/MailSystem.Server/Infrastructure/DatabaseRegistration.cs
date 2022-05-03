using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using MailSystem.Repositories.Entities;
using Microsoft.Extensions.DependencyInjection;
using NHibernate.Dialect;
using NHibernate.Tool.hbm2ddl;

namespace MailSystem.Server.Infrastructure
{
    public static class DatabaseRegistration
    {
        public static void RegisterDatabaseFactory(this IServiceCollection services)
        {
            services.AddSingleton(Fluently
                .Configure()
                .Database(
                    PostgreSQLConfiguration.Standard
                        .ConnectionString(c =>
                            c.Host("localhost")
                                .Port(5432)
                                .Database("mailsystem")
                                .Username("postgres")
                                .Password("postgres"))
                        .Dialect<PostgreSQL82Dialect>()
                        .ShowSql())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<UserEntityMap>())
                .ExposeConfiguration(c => new SchemaUpdate(c).Execute(false, true))
                .BuildSessionFactory());
        }
    }
}