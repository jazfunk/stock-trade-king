using System.Collections.Generic;
using System.Reflection;
using Core.Entities;
using Infrastructure.Mappings;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace Infrastructure
{
    public interface IUserPortfolioRepo
    {
        UserPortfolio CreatePortfolioItem(UserPortfolio portfolioItem);
        UserPortfolio ReadPortfolioItemById(int id);
        IEnumerable<UserPortfolio> ReadPortfolioItems();
        void UpdatePortfolioItem(UserPortfolio portfolioItem);
        void DeletePortfolioItem(int id);
    }

    public class UserPortfolioRepo : IUserPortfolioRepo
    {
        private readonly ISession _session;
        private readonly ISessionFactory _sessionFactory;

        public UserPortfolioRepo()
        {
            _sessionFactory = Fluently.Configure()
                .Database(PostgreSQLConfiguration.PostgreSQL82
                .ConnectionString(c => c
                    .Host("kingpgsql.postgres.database.azure.com")
                    .Port(5432)
                    .Database("stocktradeking")
                    .Username("kingadmin@kingpgsql")
                    .Password("dbp@$$222")
                    ))
                .Mappings(x => x.FluentMappings.AddFromAssembly(Assembly.GetAssembly(typeof(UserPortfolioMap))))
                .BuildSessionFactory();

            _session = _sessionFactory.OpenSession();
        }

        public UserPortfolio CreatePortfolioItem(UserPortfolio portfolioItem)
        {
            var itemCreated = new UserPortfolio();
            using (var transaction = _session.BeginTransaction())
            {
                var newId = _session.Save(portfolioItem);
                itemCreated = _session.Get<UserPortfolio>(newId);
                transaction.Commit();
            }

            return itemCreated;
        }

        public UserPortfolio ReadPortfolioItemById(int id)
        {
            var itemRead = new UserPortfolio();
            using (var transaction = _session.BeginTransaction())
            {
                itemRead = _session.Get<UserPortfolio>(id);
                transaction.Commit();
            }

            return itemRead;
        }

        public IEnumerable<UserPortfolio> ReadPortfolioItems()
        {
            var transaction = _session.BeginTransaction();
            var items = _session.CreateCriteria<UserPortfolio>().List<UserPortfolio>();
            transaction.Commit();
            return items;
        }

        public void UpdatePortfolioItem(UserPortfolio portfolioItem)
        {
            using (var transaction = _session.BeginTransaction())
            {
                _session.Update(portfolioItem);
                transaction.Commit();
            }
        }

        public void DeletePortfolioItem(int id)
        {
            using (var transaction = _session.BeginTransaction())
            {
                _session.Delete(_session.Get<UserPortfolio>(id));
                transaction.Commit();
            }
        }
    }
}
