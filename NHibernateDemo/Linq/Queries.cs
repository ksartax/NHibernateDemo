using NHibernate;
using NHibernate.Linq;
using System.Linq;

namespace NHibernateDemo.Linq
{
    public static class Queries
    {
        public static void Prepare(ISessionFactory sessionFactory)
        {
            using (var session = sessionFactory.OpenSession())
            {
                System.Console.WriteLine("Nr 1");
                var customers = session.Query<Customer>().FetchMany(c => c.Orders);
                foreach (var item in customers)
                {
                    System.Console.WriteLine(item.FirstName);
                    System.Console.WriteLine(item.Orders.Count);
                }
                System.Console.WriteLine("=========");


                System.Console.WriteLine("Nr 2");
                var customers2 = session.Query<Customer>()
                    .Where(c => c.FirstName == "Dam")
                    .Fetch(c => c.Orders);

                foreach (var item in customers2)
                {
                    System.Console.WriteLine(item.FirstName);
                    System.Console.WriteLine(item.Orders.Count);
                }
                System.Console.WriteLine("=========");


                System.Console.WriteLine("Nr 3");
                var customers3 = session.Query<Customer>().Select(c => new { c.FirstName, c.LastName });

                foreach (var item in customers3)
                {
                    System.Console.WriteLine(item.FirstName);
                }
                System.Console.WriteLine("=========");


                System.Console.WriteLine("Nr 4");
                var customers4 = session.Query<Customer>().ToFuture();
                customers4 = customers4.Where(a => a.FirstName == "Dam");

                foreach (var item in customers4)
                {
                    System.Console.WriteLine(item.FirstName);
                }
                System.Console.WriteLine("=========");


                System.Console.WriteLine("Nr 5");
                var customers5 = session
                    .Query<Customer>()
                    .Where(
                            c => c.Orders.Where(o => o.Price == "100") != null
                        );

                foreach (var item in customers5)
                {
                    System.Console.WriteLine(item.FirstName);
                }
                System.Console.WriteLine("=========");


                System.Console.WriteLine("Nr 6");
                var customers6 = session
                    .Query<Customer>()
                    .Where(
                            c => c.Orders.Count > 1
                        );

                foreach (var item in customers6)
                {
                    System.Console.WriteLine(item.FirstName);
                }
                System.Console.WriteLine("=========");
            }
        }
    }
}
