using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Linq;


namespace AutoBagBench.Persistence
{
    public abstract class Repository <T> : IRepository<T>
    {
            protected Repository()
            {

            }

            public T Get(Guid id)
            {
                
                using (var session = NHibernateHelper.OpenSession())
                    return session.Get<T>(id);
            }
          
            public IEnumerable<T> GetAll()
            {
                using (var session = NHibernateHelper.OpenSession())
                    return session.Query<T>().ToList();
            }

            public T Add(T obj)
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        session.Save(obj);
                        transaction.Commit();
                    }
                    return obj;
                }
            }

            public void Delete(Guid id)
            {
                var obj = Get(id);

                using (var session = NHibernateHelper.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        session.Delete(obj);
                        transaction.Commit();
                    }
                }
            }

            public bool Update(T obj)
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        session.SaveOrUpdate(obj);
                        try
                        {
                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            throw ex ;
                        }
                    }
                    return true;
                }
            }

      
    }
}