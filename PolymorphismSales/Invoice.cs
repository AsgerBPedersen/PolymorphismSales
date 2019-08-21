using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PolymorphismSales
{
    public class Invoice : Entity, IPayable, IEquatable<Invoice>
    {
        protected List<Product> products;

        public Invoice(List<Product> products, int id) : base(id)
        {
            Products = products;
        }

        public Invoice(List<Product> products) : this(products, default)
        {
          
        }

        public List<Product> Products
        {
            get { return products; }
            set { products = value; }
        }

        public decimal GetPaymentAmount()
        {
            return products.Sum(p => p.Price * p.Quantity);
        }

        public override bool Equals(object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                return Equals((Invoice)obj) && base.Equals(obj);
            }
        }
        public bool Equals(Invoice other)
        {
            return Products.SequenceEqual(other.Products);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;

                hash = hash * 23 + base.GetHashCode();
                foreach (Product product in Products)
                {
                    hash = hash * 23 + product.GetHashCode();
                }
                
                return hash;
            }
        }

    }
}
