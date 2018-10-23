using NHibernate.Linq;
using System;
using System.Linq;

namespace NHibernateDemo {
    internal class Program {
        private static void Main() {
            var sessionFactory = NHibernateConf.GetSession();

            PrepareDB.Prepare(sessionFactory);

            Criteria.Queries.Prepare(sessionFactory);
            HQL.Queries.Prepare(sessionFactory);
            Linq.Queries.Prepare(sessionFactory);
            QueryOver.Queries.Prepare(sessionFactory);

            using (var session = sessionFactory.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                var query = session.QueryOver<Customer>().List<Customer>();

                var c = query.First();
                c.FirstName = "Jonathan";
                session.Update(c);
                tx.Commit();
            }

            using (var session = sessionFactory.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                var query = from customer in session.Query<Customer>()
                            where customer.LastName == "Doe"
                            select customer;

                var c = query.First();
                session.Delete(c);
                tx.Commit();
            }

            Console.WriteLine("Press <ENTER> to exit...");
            Console.ReadLine();
        }
    }
}

