using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorphismSales
{
    public class BaseSalariedEmployee : Employee, IEquatable<BaseSalariedEmployee>
    {
        protected decimal salary;

        public BaseSalariedEmployee(decimal salary, string name, int id) : base(name, id)
        {
            Salary = salary;
        }

        public BaseSalariedEmployee(decimal salary, string name) : base(name)
        {
            Salary = salary;
        }

        public decimal Salary
        {
            get { return salary; }
            set { salary = value; }
        }

        public override decimal Earnings()
        {
            return Salary;
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                return Equals((BaseSalariedEmployee)obj) && base.Equals(obj);
            }
            
        }
        public bool Equals(BaseSalariedEmployee other)
        {
            return Salary == other.Salary;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;

                hash = hash * 23 + base.GetHashCode();
                hash = hash * 23 + Salary.GetHashCode();
                return hash;
            }
        }

    }
}
