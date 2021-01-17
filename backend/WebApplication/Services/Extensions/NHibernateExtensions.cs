using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DomainModel.Identity;
using FluentNHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Mapping;
using FluentNHibernate.Mapping.Providers;
using Microsoft.Extensions.DependencyInjection;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using Services.Interfaces;

namespace Services.Extensions
{
    public static class NHibernateExtensions
    {
        public static IServiceCollection AddNHibernate(this IServiceCollection services, string connectionString)
        {
            ISessionFactory sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connectionString).ShowSql())
                .Mappings(m =>m.FluentMappings.AddFromAssemblyOf<User>(t => t.Namespace.StartsWith("DomainModel.Mappings"))) 
                .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true)) 
                .BuildSessionFactory(); 
 
            services.AddSingleton(sessionFactory);
            services.AddScoped(factory => sessionFactory.OpenSession());
            services.AddScoped<IUserService, UserService>();

            return services;
        }
        
        public static FluentMappingsContainer AddFromAssemblyOf<T>(
            this FluentMappingsContainer mappings,
            Predicate<Type> where)
        {
            if (where == null)
                return mappings.AddFromAssemblyOf<T>();

            var mappingClasses = typeof(T).Assembly.GetExportedTypes()
                .Where(x => (typeof(IMappingProvider).IsAssignableFrom(x)
                             || typeof(IExternalComponentMappingProvider).IsAssignableFrom(x))
                            && where(x));

            foreach (var type in mappingClasses)
            {
                mappings.Add(type);
            }

            return mappings;
        }
    }
}