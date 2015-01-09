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
        public List<Auteur> Auteurs { get; set; }
        public List<Livre> Livres { get; set; }
        public List<Emprunteur> Emprunteurs { get; set; }
        public List<Emprunt> Emprunts { get; set; }
        public List<Utilisateur> Utilisateurs { get; set; }
        public DalManager()
        {
            Auteurs = new List<Auteur>();
            Livres = new List<Livre>();
            Emprunteurs = new List<Emprunteur>();
            Emprunts = new List<Emprunt>();
            Utilisateurs = new List<Utilisateur>();

            Auteurs.Add(new Auteur("John Ronald Reuel", "Tolkien", ESexe.Masculin, new DateTime(1982, 01, 3), new DateTime(1973, 09, 02), true));
            Auteurs.Add(new Auteur("Joanne", "Rowling", ESexe.Feminin, new DateTime(1965, 07, 31), new DateTime(), true));
            Auteurs.Add(new Auteur("David Carroll", "Eddings", ESexe.Masculin, new DateTime(1931, 07, 07), new DateTime(2009, 06, 02), true));

            Livres.Add(new Livre(Auteurs[2], new DateTime(1989, 1, 1), "Editeur", Genre.Fantastique, "1111", 600, 4, "Le Trône de diamant"));
            Livres.Add(new Livre(Auteurs[2], new DateTime(1990, 1, 1), "Editeur", Genre.Fantastique, "1111", 600, 8, "Le Chevalier de rubis"));
            Livres.Add(new Livre(Auteurs[2], new DateTime(1991, 1, 1), "Editeur", Genre.Fantastique, "1111", 600, 9, "La Rose de saphir"));

            Emprunteurs.Add(new Emprunteur("Antoine", "Gueleraud", ESexe.Masculin, new DateTime(1993, 08, 17), "Clermont-Ferrand", "antoine.gueleraud@gmail.com", "0615589076"));
            Emprunteurs.Add(new Emprunteur("Jimmy", "Hoang", ESexe.Masculin, new DateTime(1989, 06, 05), "Clermont-Ferrand", "hoangjim@poste.isima.fr", "xxxxxxxxxx"));

            Emprunts.Add(new Emprunt(new DateTime(2014, 12, 18), new DateTime(2014, 12, 25), Emprunteurs[0], Livres[0]));
            Emprunts.Add(new Emprunt(new DateTime(2014, 12, 18), new DateTime(2015, 01, 12), Emprunteurs[0], Livres[1]));
            Emprunts.Add(new Emprunt(new DateTime(2014, 12, 01), new DateTime(2014, 12, 23), Emprunteurs[1], Livres[2]));
        }

        public Utilisateur getUtilisateurbyLogin(String logrech)
        {
            Utilisateur rech = null;
            foreach(Utilisateur u in Utilisateurs)
                if (String.Compare(logrech, u.login) == 0)
                {
                    rech = u;
                    break;
                }
            return rech;
        }
    }
}
