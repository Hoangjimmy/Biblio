using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;

namespace StubDataAccessLayer
{
    public class DalManager
    {
        IList<Livre> Livres { get; set; }
        IList<Emprunt> Emprunts { get; set; }
        IList<Emprunteur> Emprunteurs { get; set; }
        IList<Auteur> Auteurs { get; set; }


        public DalManager()
        {
            Auteurs.Add(new Auteur("John Ronald Reuel", "Tolkien", ESexe.Masculin, new DateTime(1982, 01, 3), new DateTime(1973, 09, 02), true));
            
        }
    }
}
