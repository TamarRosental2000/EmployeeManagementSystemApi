using EmployeeManagementSystemDb.Map;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;
using FluentNHibernate.Mapping;
using NHibernate;
using System.Reflection;

namespace Logic.Utils
{
    public sealed class SessionFactory
    {
        private const string CONNECTION_STRING = "Database=EmployeeManagement;Server=Laptop-10JSI7Q1;Trusted_Connection=True;Encrypt=false";
        private readonly ISessionFactory _factory;

        public SessionFactory()
        {

            _factory = BuildSessionFactory();
        }

        internal ISession OpenSession()
        {
            return _factory.OpenSession();
        }

        private static ISessionFactory BuildSessionFactory()
        {
            //FluentConfiguration configuration = Fluently.Configure()
            //    .Database(MsSqlConfiguration.MsSql2012.ConnectionString(CONNECTION_STRING))
            //    .Mappings(m => m.FluentMappings
            //        .AddFromAssembly(Assembly.GetExecutingAssembly())
            //        .Conventions.Add(
            //            //ForeignKey.EndsWith("ID"),
            //            ConventionBuilder.Property.When(criteria => criteria.Expect(x => x.Nullable, Is.Not.Set), x => x.Not.Nullable()))
            //        .Conventions.Add<OtherConversions>()
            //        .Conventions.Add<TableNameConvention>()
            //        .Conventions.Add<HiLoConvention>()
            //    );
            //FluentConfiguration configuration = Fluently.Configure()
            //    .Database(
            //        MsSqlConfiguration.MsSql2012.ConnectionString(CONNECTION_STRING) // Set your SQL Server connection string here
            //    )
            //    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<EmployeeMap>()
            //               .AddFromAssemblyOf<ProjectMap>());


            var configuration = Fluently.Configure()
    .Database(
        MsSqlConfiguration.MsSql2012
        .ConnectionString(CONNECTION_STRING)
        .ShowSql() // Optional: Show SQL statements in the console
    )
    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<EmployeeMap>()
                           .AddFromAssemblyOf<ProjectMap>());

            //var sessionFactory = fluentConfiguration.BuildSessionFactory();
            return configuration.BuildSessionFactory();


        }

        private class OtherConversions : IHasManyConvention, IReferenceConvention
        {
            public void Apply(IOneToManyCollectionInstance instance)
            {
                instance.LazyLoad();
                instance.AsBag();
                instance.Cascade.SaveUpdate();
                instance.Inverse();
            }

            public void Apply(IManyToOneInstance instance)
            {
                instance.LazyLoad(Laziness.Proxy);
                instance.Cascade.None();
                instance.Not.Nullable();
            }
        }

        public class TableNameConvention : IClassConvention
        {
            public void Apply(IClassInstance instance)
            {
                instance.Table(instance.EntityType.Name);
            }
        }

        public class HiLoConvention : IIdConvention
        {
            public void Apply(IIdentityInstance instance)
            {
                instance.Column(instance.EntityType.Name + "ID");
                instance.GeneratedBy.Native();
            }
        }
    }
}
