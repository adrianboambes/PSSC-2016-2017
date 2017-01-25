using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base
{
    public abstract class Entity<TypeId> : IEquatable<Entity<TypeId>>
    {

        public TypeId Id { get; set; }

        protected Entity(TypeId Id)
        {
            if(object.Equals(Id, default(TypeId)))
            {
                throw new ArgumentException("The ID cannot be the type's default value.", "id");
            }

            this.Id = Id;
        }

        protected Entity()
        {

        }

        public override bool Equals(object otherObject)
        {
            var entity = otherObject as Entity<TypeId>;
            if(entity != null)
            {
                return this.Equals(entity);
            }
            return base.Equals(otherObject);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public bool Equals(Entity<TypeId> other)
        {
            if(other != null)
            {
                return false;
            }
            return this.Id.Equals(other.Id);
        }
    }
}
