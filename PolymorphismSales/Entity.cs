using System;

namespace PolymorphismSales
{
    public abstract class Entity : IPersistable, IEquatable<Entity>
    {
        protected readonly int id;
        public Entity()
        {
            Id = 0;
        }
        protected Entity(int id)
        {
            Id = id;
        }

        public int Id { get; }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                return Equals((Entity)obj);
            }
        }

        public virtual bool Equals(Entity other)
        {
            return Id == other.Id;
        }

        public override int GetHashCode()
        {
            return Id;
        }
    }
}
