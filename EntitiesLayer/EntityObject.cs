﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
   public abstract class EntityObject
    {
        public int Id
        {
            get;
            set;
        }

        public EntityObject()
        {
            Id = 0;
        }

        public override bool Equals(Object o)
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