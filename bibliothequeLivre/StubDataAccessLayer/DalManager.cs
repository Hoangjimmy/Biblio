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
        IList<Auteur> Auteurs { get; set; }
        IList<Livre> Livres { get; set; }
        IList<Emprunteur> Emprunteurs { get; set; }
        IList<Emprunt> Emprunts { get; set; }

        public DalManager()
        {
            Auteurs.Add(new Auteur("John Ronald Reuel", "Tolkien", ESexe.Masculin, new DateTime(1982, 01, 3), new DateTime(1973, 09, 02), true));
            Auteurs.Add(new Auteur("Joanne", "Rowling", ESexe.Feminin, new DateTime(1965, 07, 31), new DateTime(), true));
            Auteurs.Add(new Auteur("David Carroll", "Eddings", ESexe.Masculin, new DateTime(1931, 07, 07), new DateTime(2009, 06, 02), true));

            Livres.Add(new Livre(Auteurs[2], new DateTime(1989, 0, 0), "Editeur", Genre.Fantastique, "1111", 600, "Le Trône de diamant"));
            Livres.Add(new Livre(Auteurs[2], new DateTime(1990, 0, 0), "Editeur", Genre.Fantastique, "1111", 600, "Le Chevalier de rubis"));
            Livres.Add(new Livre(Auteurs[2], new DateTime(1991, 0, 0), "Editeur", Genre.Fantastique, "1111", 600, "La Rose de saphir"));

            Emprunteurs.Add(new Emprunteur("Antoine", "Gueleraud", ESexe.Masculin, new DateTime(1993, 08, 17), "Clermont-Ferrand", "antoine.gueleraud@gmail.com", "0615589076"));
            Emprunteurs.Add(new Emprunteur("Jimmy", "Hoang", ESexe.Masculin, new DateTime(1992, 01, 01), "Clermont-Ferrand", "hoangjim@poste.isima.fr", "xxxxxxxxxx"));

            Emprunts.Add(new Emprunt(new DateTime(2014, 12, 18), new DateTime(2014, 12, 25), Emprunteurs[0], Livres[0]));
            Emprunts.Add(new Emprunt(new DateTime(2014, 12, 18), new DateTime(2015, 01, 12), Emprunteurs[0], Livres[1]));
            Emprunts.Add(new Emprunt(new DateTime(2014, 12, 01), new DateTime(2014, 12, 23), Emprunteurs[1], Livres[2]));
        }
    }
}
