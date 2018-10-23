using Iesi.Collections.Generic;
using System;

namespace NHibernateDemo {
    public class Customer {

        public Customer()
        {
            Orders = new HashedSet<Order>();
        }

        public virtual int Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual int Age { get; set; }
        public virtual bool Active { get; set; }
        public virtual DateTime CreateTime { get; set; }

        public virtual SexEnum Sex { get; set; }

        public virtual Location Address { get; set; }

        public virtual ISet<Order> Orders { get; set; }
    }

    public class Location
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
    }

    public enum SexEnum
    {
        Famele,
        Male
    }
}