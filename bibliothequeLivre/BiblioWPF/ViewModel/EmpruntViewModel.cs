using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;

namespace BiblioWPF.ViewModel
{
    class EmpruntViewModel
    {
        public static List<Emprunteur> Emprunteurs
        {
            get
            {
                return new List<Emprunteur>(BusinessLayer.BiblioManager.listeEmprunteur());
            }
        }

        public static List<Livre> Livres
        {
            get
            {
                return new List<Livre>(BusinessLayer.BiblioManager.listeLivre());
            }
        }

        private Emprunt _emprunt;
        public Emprunt Emprunt
        {
            get
            {
                return _emprunt;
            }
            private set
            {
                _emprunt = value;
            }
        }

        public EmpruntViewModel(Emprunt emprunt)
        {
            Emprunt = emprunt;
        }
    }
}
