using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public abstract class EntityObject : IEquatable<EntityObject>
    {
        public int Id
        {
            get;
            set;
        }

        private static int cpt = 0;

        public EntityObject()
        {
            Id = cpt;
            cpt++;
        }

        public bool Equals(EntityObject o)
        {
            bool equal = false;
            if (o.GetType() == typeof(EntityObject))
                if (((EntityObject)o).Id == this.Id)
                    equal = true;
            return equal;
        }

        public override int GetHashCode()
        {
            return Id;
        }
    }
}
