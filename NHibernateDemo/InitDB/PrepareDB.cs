using NHibernate;

namespace NHibernateDemo
{
    public static class PrepareDB
    {
        public static void Prepare(ISessionFactory sessionFactory)
        {
            var customers = CustomersData.GetCustomers();

            using (var session = sessionFactory.OpenSession())
            {
                using (var t = session.BeginTransaction())
                {
                    var a = session.CreateQuery("delete Customer").ExecuteUpdate();
                    
                    foreach (var item in customers)
                    {
                        session.Save(item);
                    }

                    t.Commit();
                }
            }
        }
    }
}
