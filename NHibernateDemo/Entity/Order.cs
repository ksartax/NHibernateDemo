namespace NHibernateDemo
{
    public class Order
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Price { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
