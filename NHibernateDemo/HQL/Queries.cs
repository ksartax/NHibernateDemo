using NHibernate;
using NHibernate.Transform;

namespace NHibernateDemo.HQL
{
    public static class Queries
    {
        public static void Prepare(ISessionFactory sessionFactory)
        {
            using (var session = sessionFactory.OpenSession())
            {
                System.Console.WriteLine("Nr 1");
                var customers = session
                    .CreateQuery("SELECT c FROM Customer c where c.FirstName = :name")
                    .SetParameter("name", "Dam")
                    .List<Customer>();
                foreach (var item in customers)
                {
                    System.Console.WriteLine(item.FirstName);
                    System.Console.WriteLine(item.Orders.Count);
                }
                System.Console.WriteLine("=========");


                System.Console.WriteLine("Nr 2");
                customers = session
                    .CreateQuery("select c from Customer c left join fetch c.Orders o where size(c.Orders) = :size")
                    .SetParameter("size", 1)
                    .SetResultTransformer(Transformers.DistinctRootEntity)
                    .List<Customer>();

                foreach (var item in customers)
                {
                    System.Console.WriteLine(item.FirstName);
                    System.Console.WriteLine(item.Orders.Count);
                }
                System.Console.WriteLine("=========");


                System.Console.WriteLine("Nr 3");
                customers = session
                    .CreateQuery("select c from Customer c left join fetch c.Orders o where c.FirstName IN (select c.FirstName from Customer c)")
                    .SetResultTransformer(Transformers.DistinctRootEntity)
                    .List<Customer>();

                foreach (var item in customers)
                {
                    System.Console.WriteLine(item.FirstName);
                    System.Console.WriteLine(item.Orders.Count);
                }
                System.Console.WriteLine("=========");
            }
        }
    }
}