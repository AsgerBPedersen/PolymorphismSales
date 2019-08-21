using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolymorphismSales;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class EmployeesTest
    {
       
        [DataTestMethod]
        [DataRow(100)]
        [DataRow(100000)]
        public void BaseEmplyee_GetPayment(int value)
        {
            IPayable employee = new BaseSalariedEmployee(value, "hans");
            Assert.AreEqual(value * 0.85m, employee.GetPaymentAmount());
        }

        [DataTestMethod]
        [DataRow(100, 10, 50)]
        [DataRow(100000, 32, 400)]
        public void Sa1ariedEmployee_GetPayment(int salary, int weeklySales, int commision)
        {
            IPayable employee = new SalesRepresentative(weeklySales,commision,salary, "hans");
            Assert.AreEqual((weeklySales * commision +salary)*0.85m, employee.GetPaymentAmount());
        }

        [TestMethod]
        public void PayablesTest()
        {
            List<IPayable> payables = new List<IPayable>() {
                new BaseSalariedEmployee(1234,"hans"),
                new BaseSalariedEmployee(32000, "hans"),
                new SalesRepresentative(12, 200, 22000, "hans"),
                new SalesRepresentative(2, 10, 250, "hans"),
                new SalesRepresentative(28, 400, 1200, "hans"),
                new Invoice(new List<Product>()
                {
                    new Product(2, 23.99m, "Is"),
                    new Product(18, 4.5m, "Slik")
                }),
                new Invoice(new List<Product>()
                {
                    new Product(12, 21m, "Søm"),
                    new Product(45, 4.5m, "Skruer")
                }),
                new Invoice(new List<Product>()
                {
                    new Product(11, 56.2m, "Fluesmækker"),
                    new Product(13, 21.5m, "Fluepapir")
                })
            };
            Assert.AreEqual(GetTotalPaymentAmount(payables), 61239.58m);
        }

        [TestMethod]
        public void EqualsTest()
        {
            Invoice invoice1 = new Invoice(new List<Product>()
                {
                    new Product(11, 56.2m, "Fluesmækker"),
                    new Product(13, 21.5m, "Fluepapir")
                });

            Invoice invoice2 = new Invoice(new List<Product>()
                {
                    new Product(11, 56.2m, "Fluesmækker"),
                    new Product(13, 21.5m, "Fluepapir")
                });
            Assert.IsTrue(invoice1.Equals(invoice2));
        }

        decimal GetTotalPaymentAmount(List<IPayable> IPayables)
        {
            return IPayables.Sum(p => p.GetPaymentAmount());
        }
    }
}
