using NHibernate;
using NHibernate.SqlCommand;
using NHibernate.Transform;

namespace NHibernateDemo.QueryOver
{
    public static class Queries
    {
        public static void Prepare(ISessionFactory sessionFactory)
        {
            using (var session = sessionFactory.OpenSession())
            {
                System.Console.WriteLine("Nr 1");
                var customers = session
                    .QueryOver<Customer>()
                    .TransformUsing(Transformers.DistinctRootEntity)
                    .JoinQueryOver(c => c.Orders, JoinType.LeftOuterJoin)
                    .List<Customer>();

                foreach (var item in customers)
                {
                    System.Console.WriteLine(item.FirstName);
                    System.Console.WriteLine(item.Orders.Count);
                }
                System.Console.WriteLine("=========");


                System.Console.WriteLine("Nr 2");
                var customers2 = session
                    .QueryOver<Customer>()
                    .TransformUsing(Transformers.DistinctRootEntity)
                    .JoinQueryOver(c => c.Orders, JoinType.LeftOuterJoin)
                    .List<Customer>();

                foreach (var item in customers2)
                {
                    System.Console.WriteLine(item.FirstName);
                    System.Console.WriteLine(item.Orders.Count);
                }
                System.Console.WriteLine("=========");


                System.Console.WriteLine("Nr 3");
                var customers3 = session
                    .QueryOver<Customer>()
                    .TransformUsing(Transformers.DistinctRootEntity)
                    .JoinQueryOver<Order>(c => c.Orders, JoinType.LeftOuterJoin)
                        .Where(o => o.Price == "100")
                    .List<Customer>();

                foreach (var item in customers3)
                {
                    System.Console.WriteLine(item.FirstName);
                    System.Console.WriteLine(item.Orders.Count);
                }
                System.Console.WriteLine("=========");
            }
        }
    }
}