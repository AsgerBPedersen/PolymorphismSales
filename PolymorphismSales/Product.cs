using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorphismSales
{
    public class Product : Entity, IEquatable<Product>
    {
        protected string name;
        protected decimal price;
        protected int quantity;

        public Product(int quantity, decimal price, string name, int id) : base(id)
        {
            Quantity = quantity;
            Price = price;
            Name = name;
        }

        public Product(int quantity, decimal price, string name) :this(quantity, price, name, default)
        {
           
        }
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                return Equals((Product)obj) && base.Equals(obj);
            }
        }
        public bool Equals(Product other)
        {
            return (Quantity == other.Quantity && Price == other.Price && Name == other.Name);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;

                hash = hash * 23 + base.GetHashCode();
                hash = hash * 23 + Quantity.GetHashCode();
                hash = hash * 23 + Price.GetHashCode();
                hash = hash * 23 + Name.GetHashCode();
                return hash;
            }
        }

        
    }
}
