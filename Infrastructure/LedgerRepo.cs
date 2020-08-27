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
    public interface ILedgerRepo
    {
        Ledger CreateLedger(Ledger ledgerToCreate);

        Ledger ReadLedgerById(int id);

        IEnumerable<Ledger> ReadLedgerByHoldingsId(int holdingsId);

        IEnumerable<Ledger> ReadLedgerByUserId(int userId);

        IEnumerable<Ledger> ReadAllLedgerItems(); 

        void UpdateLedger(Ledger ledgerToUpdate);

        void DeleteLedgerById(int id);
    }

    public class LedgerRepo : ILedgerRepo
    {
        private readonly ISession _session;
        private readonly ISessionFactory _sessionFactory;

        public LedgerRepo()
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
                .Mappings(x => x.FluentMappings.AddFromAssembly(Assembly.GetAssembly(typeof(LedgerMap))))
                .BuildSessionFactory();

            _session = _sessionFactory.OpenSession();
        }

        public Ledger CreateLedger(Ledger ledgerToCreate)
        {
            var ledgerCreated = new Ledger();
            using (var transaction = _session.BeginTransaction())
            {
                var newId = _session.Save(ledgerToCreate);
                ledgerCreated = _session.Get<Ledger>(newId);
                transaction.Commit();
            }

            return ledgerCreated;
        }

        public Ledger ReadLedgerById(int id)
        {
            var ledgerRead = new Ledger();
            using (var transaction = _session.BeginTransaction())
            {
                ledgerRead = _session.Get<Ledger>(id);
                transaction.Commit();
            }

            return ledgerRead;
        }

        public IEnumerable<Ledger> ReadLedgerByUserId(int userId)
        {
            var transaction = _session.BeginTransaction();
            var items = _session.CreateCriteria<Ledger>().Add(Restrictions.Eq("UserId", userId)).List<Ledger>();
            transaction.Commit();
            return items;
        }

        public IEnumerable<Ledger> ReadLedgerByHoldingsId(int holdingsId)
        {
            var transaction = _session.BeginTransaction();
            var items = _session.CreateCriteria<Ledger>().Add(Restrictions.Eq("HoldingsId", holdingsId)).List<Ledger>();
            transaction.Commit();
            return items;
        }

        public IEnumerable<Ledger> ReadAllLedgerItems()
        {
            var transaction = _session.BeginTransaction();
            var items = _session.CreateCriteria<Ledger>().List<Ledger>();
            transaction.Commit();
            return items;
        }

        public void UpdateLedger(Ledger ledgerToUpdate)
        {
            using (var transaction = _session.BeginTransaction())
            {
                _session.Update(ledgerToUpdate);
                transaction.Commit();
            }
        }

        public void DeleteLedgerById(int id)
        {
            using (var transaction = _session.BeginTransaction())
            {
                _session.Delete(_session.Get<Ledger>(id));
                transaction.Commit();
            }
        }
    }
}
