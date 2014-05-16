using Agenda.Dominio.IRepositorio;
using Agenda.Repositorio.Helper;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Linq;

namespace Agenda.Repositorio.Repositorio
{
    public class RepositorioBase<T> : IRepositorioBase<T> where T : class
    {
        public T RetornaPorId(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                return session.Get<T>(id);
        }

        public IList<T> RetornaTodos()
        {
            using (ISession session = NHibernateHelper.OpenSession())
                return (from t in session.Linq<T>()
                        select t).ToList();
        }

        public IList<T> RetornaPorHql(string hql)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                return session.CreateQuery(hql).List<T>();
        }

        public T Salva(T entity)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(entity);
                    transaction.Commit();
                }
            }
            return entity;
        }

        public T Exclui(T entity)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(entity);
                    transaction.Commit();
                }
            }
            return entity;
        }
    }
}
