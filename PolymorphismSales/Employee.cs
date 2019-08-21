using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorphismSales
{
    public abstract class Employee : Entity, IPayable, IEquatable<Employee>
    {
        protected string name;

        public Employee(string name, int id) : base(id)
        {
            Name = name;
        }
        public Employee(string name) : this(name, default)
        {
           
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public decimal GetPaymentAmount()
        {
            return Earnings() * 0.85m;
        }

        public abstract decimal Earnings();

        public override bool Equals(object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                return Equals((Employee)obj) && base.Equals(obj);
            }
        }

        public bool Equals(Employee other)
        {
            throw new NotImplementedException();
        }


        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                
                hash = hash * 23 + base.GetHashCode();
                hash = hash * 23 + Name.GetHashCode();
                return hash;
            }
        }

    }
}
