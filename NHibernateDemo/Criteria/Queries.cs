using NHibernate;
using NHibernate.Criterion;
using NHibernate.Transform;

namespace NHibernateDemo.Criteria
{
    public static class Queries
    {
        public static void Prepare(ISessionFactory sessionFactory)
        {
            using (var session = sessionFactory.OpenSession())
            {
                System.Console.WriteLine("Nr 1");
                var customers = session.CreateCriteria<Customer>().SetFetchMode("Orders", FetchMode.Eager);
                foreach (var item in customers.List<Customer>())
                {
                    System.Console.WriteLine(item.ToString());
                    System.Console.WriteLine(item.Orders.Count);
                }
                System.Console.WriteLine("=====================");



                System.Console.WriteLine("Nr 2");
                customers = customers
                    .Add(Restrictions.Like("FirstName", "Dam%"))
                    .Add(Restrictions.Or(
                            Restrictions.Eq("LastName", "St"),
                            Restrictions.IsNotNull("Age")
                        ))
                    .SetFetchMode("Orders", FetchMode.Eager);

                foreach (var item in customers.List<Customer>())
                {
                    System.Console.WriteLine(item.ToString());
                    System.Console.WriteLine(item.Orders.Count);
                }
                System.Console.WriteLine("=====================");



                System.Console.WriteLine("Nr 3");
                customers = customers
                    .Add(Restrictions.In("FirstName", new string[] { "Dam", "Dam1" }))
                    .SetFetchMode("Orders", FetchMode.Eager);

                foreach (var item in customers.List<Customer>())
                {
                    System.Console.WriteLine(item.ToString());
                    System.Console.WriteLine(item.Orders.Count);
                }
                System.Console.WriteLine("=====================");



                System.Console.WriteLine("Nr 4");
                customers = customers
                    .SetResultTransformer(Transformers.DistinctRootEntity)
                    .AddOrder(NHibernate.Criterion.Order.Asc("FirstName"))
                    .SetFetchMode("Orders", FetchMode.Eager);

                foreach (var item in customers.List<Customer>())
                {
                    System.Console.WriteLine(item.ToString());
                    System.Console.WriteLine(item.Orders.Count);
                }
                System.Console.WriteLine("=====================");



                System.Console.WriteLine("Nr 5");
                customers = customers
                    .SetResultTransformer(Transformers.DistinctRootEntity)
                        .CreateCriteria("Orders", NHibernate.SqlCommand.JoinType.LeftOuterJoin);

                foreach (var item in customers.List<Customer>())
                {
                    System.Console.WriteLine(item.FirstName);
                    System.Console.WriteLine(item.Orders.Count);
                }
                System.Console.WriteLine("=====================");
            }
        }
    }
}
