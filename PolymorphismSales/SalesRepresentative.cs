using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorphismSales
{
    public class SalesRepresentative : BaseSalariedEmployee, IEquatable<SalesRepresentative>
    {
        protected decimal weeklySales;
        protected double commisionRate;

        public double CommisionRate
        {
            get { return commisionRate; }
            set { commisionRate = value; }
        }

        public decimal WeeklySales
        {
            get { return weeklySales; }
            set { weeklySales = value; }
        }

        public SalesRepresentative(decimal weeklySales, double commisionRate,decimal salary, string name, int id) : base(salary, name, id)
        {
            WeeklySales = weeklySales;
            CommisionRate = commisionRate;
        }

        public SalesRepresentative(decimal weeklySales, double commisionRate, decimal salary, string name) : this(weeklySales, commisionRate,salary, name, default)
        {
            
        }

        public override decimal Earnings()
        {
            return Salary + WeeklySales * (decimal)CommisionRate;
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                return Equals((SalesRepresentative)obj) && base.Equals(obj);
            }
 
        }
        public bool Equals(SalesRepresentative other)
        {
            return (WeeklySales == other.WeeklySales && CommisionRate == other.CommisionRate);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;

                hash = hash * 23 + base.GetHashCode();
                hash = hash * 23 + WeeklySales.GetHashCode();
                hash = hash * 23 + CommisionRate.GetHashCode();
                return hash;
            }
        }

    }
}
