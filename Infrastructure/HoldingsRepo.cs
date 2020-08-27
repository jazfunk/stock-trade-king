using System.Collections.Generic;
using System.Reflection;
using Core.Entities;
using Infrastructure.Mappings;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Criterion;

namespace Infrastructure
{
    public interface IHoldingsRepo
    {
        Holdings CreateHolding(Holdings holdingToCreate);

        Holdings ReadHoldingsById(int id);

        IEnumerable<Holdings> ReadHoldingsByUserId(int userId);

        IEnumerable<Holdings> ReadAllHoldings();

        void UpdateHoldings(Holdings holdingToUpdate);

        void DeleteHoldingById(int id);
    }

    public class HoldingsRepo : IHoldingsRepo
    {
        private readonly ISession _session;
        private readonly ISessionFactory _sessionFactory;

        public HoldingsRepo()
        {
            _sessionFactory = Fluently.Configure()
                .Database(PostgreSQLConfiguration.PostgreSQL82
                .ConnectionString(c => c
                    .Host("lallah.db.elephantsql.com")
                    .Port(5432)
                    .Database("naxbdnxa")
                    .Username("naxbdnxa")
                    .Password("LPyftDHimm9fnUArNMViwYm0PIq412ma")
                    ))
                .Mappings(x => x.FluentMappings.AddFromAssembly(Assembly.GetAssembly(typeof(UserMap))))
                .BuildSessionFactory();

            _session = _sessionFactory.OpenSession();
        }

        public Holdings CreateHolding(Holdings holdingToCreate)
        {
            var holdingCreated = new Holdings();
            using (var transaction = _session.BeginTransaction())
            {
                var newId = _session.Save(holdingToCreate);
                holdingCreated = _session.Get<Holdings>(newId);
                transaction.Commit();
            }

            return holdingCreated;
        }

        public Holdings ReadHoldingsById(int id)
        {
            var holdingRead = new Holdings();
            using (var transaction = _session.BeginTransaction())
            {
                holdingRead = _session.Get<Holdings>(id);
                transaction.Commit();
            }

            return holdingRead;
        }

        public IEnumerable<Holdings> ReadHoldingsByUserId(int userId)
        {
            var transaction = _session.BeginTransaction();
            var items = _session.CreateCriteria<Holdings>().Add(Restrictions.Eq("UserId", userId)).List<Holdings>();
            transaction.Commit();
            return items;
        }

        public IEnumerable<Holdings> ReadAllHoldings()
        {
            var transaction = _session.BeginTransaction();
            var items = _session.CreateCriteria<Holdings>().List<Holdings>();
            transaction.Commit();
            return items;
        }

        public void UpdateHoldings(Holdings holdingsToUpdate)
        {
            using (var transaction = _session.BeginTransaction())
            {
                _session.Update(holdingsToUpdate);
                transaction.Commit();
            }

        }

        public void DeleteHoldingById(int id)
        {
            using (var transaction = _session.BeginTransaction())
            {
                _session.Delete(_session.Get<Holdings>(id));
                transaction.Commit();
            }
        }
    }
}
