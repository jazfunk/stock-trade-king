using System.Collections.Generic;
using System.Reflection;
using Core.Entities;
using Infrastructure.Mappings;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace Infrastructure
{
    public interface IUsersRepo
    {
        User CreateUser(User userToCreate);
        User ReadUserById(int id);
        IEnumerable<User> ReadUsers();
        User UpdateUser(User userToUpdate);
        User DeleteUserById(int id);
    }

    public class UsersRepo : IUsersRepo
    {

        private readonly ISession _session;
        private readonly ISessionFactory _sessionFactory;

        public UsersRepo()
        {
            _sessionFactory = Fluently.Configure()
                .Database(PostgreSQLConfiguration.PostgreSQL82
                .ConnectionString(c => c
                    .Host("localhost")
                    .Port(5432)
                    .Database("stockappdb")
                    .Username("production")
                    .Password("dbp@$$")
                    ))
                .Mappings(x => x.FluentMappings.AddFromAssembly(Assembly.GetAssembly(typeof(UserMap))))
                .BuildSessionFactory();

            _session = _sessionFactory.OpenSession();
        }

        public User CreateUser(User userToCreate)
        {
            var userCreated = new User();
            using (var transaction = _session.BeginTransaction())
            {
                var newId = _session.Save(userToCreate);
                userCreated = _session.Get<User>(newId);
                transaction.Commit();
            }

            return userCreated;
        }

        public User ReadUserById(int id)
        {
            var userRead = new User();
            using (var transaction = _session.BeginTransaction())
            {
                userRead = _session.Get<User>(id);
                transaction.Commit();
            }

            return userRead;            
        }

        public IEnumerable<User> ReadUsers()
        {
            var transaction = _session.BeginTransaction();
            var users = _session.CreateCriteria<User>().List<User>();
            transaction.Commit();
            return users;
        }

        public User UpdateUser(User userToUpdate)
        {
            var userUpdates = new User();
            using (var transaction = _session.BeginTransaction())
            {
                userUpdates.FirstName = userToUpdate.FirstName;
                userUpdates.LastName = userToUpdate.LastName;
                userUpdates.PassWord = userToUpdate.PassWord;
                userUpdates.Email = userToUpdate.Email;

                _session.SaveOrUpdate(userUpdates);
                transaction.Commit();
            }

            return userUpdates;
        }

        public User DeleteUserById(int id)
        {
            var userToDelete = new User();
            using (var transaction = _session.BeginTransaction())
            {
                userToDelete = _session.Get<User>(id);
                _session.Delete(userToDelete);
                transaction.Commit();
            }

            return userToDelete;
        }
    }
}
