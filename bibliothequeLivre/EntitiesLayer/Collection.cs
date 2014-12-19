using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    class Collection : EntityObject
    {
        public String Description { get; set; }
        public IList<Livre> Livres { get; set; }
        public String Nom { get; set; }

        public Collection(IList<Livre> livres)
        {
            Livres = livres;
        }
    }
}
