﻿using System.Collections.Generic;
using System.Reflection;
using Core.Entities;
using Infrastructure.Mappings;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System;

namespace Infrastructure
{
    public interface IUserRepo
    {
        User CreateUser(User userToCreate);
        User ReadUserById(int id);
        IEnumerable<User> ReadUsers();
        void UpdateUser(User user);
        void DeleteUserById(int id);
    }

    public class UserRepo : IUserRepo
    {
        private readonly ISession _session;
        private readonly ISessionFactory _sessionFactory;

        public UserRepo()
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

        public void UpdateUser(User user)
        {
            using (var transaction = _session.BeginTransaction())
            {
                _session.Update(user);
                transaction.Commit();
            }
        }

        public void DeleteUserById(int id)
        {
            using (var transaction = _session.BeginTransaction())
            {            
                _session.Delete(_session.Get<User>(id));
                transaction.Commit();
            }
        }
    }
}
