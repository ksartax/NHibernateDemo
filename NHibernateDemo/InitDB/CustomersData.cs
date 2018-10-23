using Iesi.Collections.Generic;
using System;

namespace NHibernateDemo
{
    public static class CustomersData
    {
        public static ISet<Customer> Customers { get; set; } = new HashedSet<Customer>();

        public static ISet<Customer> GetCustomers()
        {
            Customers.Add(new Customer {
                FirstName = "Dam",
                LastName = "St",
                Age = 1,
                Sex = SexEnum.Famele,
                CreateTime = DateTime.Now,
                Active = true,

                Address = new Location
                {
                    City = "Polska",
                    Province = "Maz",
                    Street = "W"
                },
                Orders =
                {
                    new Order()
                    {
                        Name = "Test",
                        Price = "100"
                    }
                }
            });

            Customers.Add(new Customer
            {
                FirstName = "Dam1",
                LastName = "St1",
                Age = 1,
                Sex = SexEnum.Famele,
                CreateTime = DateTime.Now,
                Active = true,

                Address = new Location
                {
                    City = "Polska",
                    Province = "Maz",
                    Street = "W"
                },
            });

            Customers.Add(new Customer
            {
                FirstName = "Dam2",
                LastName = "St2",
                Age = 1,
                Sex = SexEnum.Famele,
                CreateTime = DateTime.Now,
                Active = true,

                Address = new Location
                {
                    City = "Polska",
                    Province = "Maz",
                    Street = "W"
                },
            });

            return Customers;
        }
    }
}
