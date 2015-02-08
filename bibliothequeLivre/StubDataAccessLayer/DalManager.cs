using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;
using System.IO;
using System.Xml.Serialization;

namespace StubDataAccessLayer
{
    public class DalManager
    {
        public List<Auteur> Auteurs { get; set; }
        public List<Livre> Livres { get; set; }
        public List<Emprunteur> Emprunteurs { get; set; }
        public List<Emprunt> Emprunts { get; set; }
        public List<Utilisateur> Utilisateurs { get; set; }
        private static DalManager instance;

        public static DalManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new DalManager();
                return instance;
            }
        } 

        public DalManager()
        {
            Auteurs = new List<Auteur>();
            Livres = new List<Livre>();
            Emprunteurs = new List<Emprunteur>();
            Emprunts = new List<Emprunt>();
            Utilisateurs = new List<Utilisateur>();

            Auteurs.Add(new Auteur("John Ronald Reuel", "Tolkien", ESexe.Masculin, new DateTime(1892, 01, 3), new DateTime(1973, 09, 02), true));
            Auteurs.Add(new Auteur("Joanne", "Rowling", ESexe.Feminin, new DateTime(1965, 07, 31), null, true));
            Auteurs.Add(new Auteur("David Carroll", "Eddings", ESexe.Masculin, new DateTime(1931, 07, 07), new DateTime(2009, 06, 02), false));

            Livres.Add(new Livre(Auteurs[2], new DateTime(1989, 1, 1), "Editeur", Genre.Fantastique, "1111", 600, 4, "Le Trône de diamant"));
            Livres.Add(new Livre(Auteurs[2], new DateTime(1990, 1, 1), "Editeur", Genre.Fantastique, "1111", 600, 8, "Le Chevalier de rubis"));
            Livres.Add(new Livre(Auteurs[2], new DateTime(1991, 1, 1), "Editeur", Genre.Fantastique, "1111", 600, 9, "La Rose de saphir"));

            Emprunteurs.Add(new Emprunteur("Antoine", "Gueleraud", ESexe.Masculin, new DateTime(1993, 08, 17), "Clermont-Ferrand", "antoine.gueleraud@gmail.com", "0615589076"));
            Emprunteurs.Add(new Emprunteur("Jimmy", "Hoang", ESexe.Masculin, new DateTime(1989, 06, 05), "Clermont-Ferrand", "hoangjim@poste.isima.fr", "xxxxxxxxxx"));
            Emprunteurs.Add(new Emprunteur("Choco", "Chocolat", ESexe.Indetermine, new DateTime(1535, 12, 20), "Clermont-Choc", "choco@chocolat.fr", "xxxxxxxxxx"));

            Emprunts.Add(new Emprunt(new DateTime(2014, 12, 18), new DateTime(2014, 12, 25), Emprunteurs[0], Livres[0]));
            Emprunts.Add(new Emprunt(new DateTime(2014, 12, 18), new DateTime(2015, 01, 12), Emprunteurs[0], Livres[1]));
            Emprunts.Add(new Emprunt(new DateTime(2014, 12, 01), new DateTime(2014, 12, 23), Emprunteurs[1], Livres[2]));

            Utilisateurs.Add(new Utilisateur("Gueleraud","Antoine","Terred","pass"));
            Utilisateurs.Add(new Utilisateur("Hoang", "Jimmy", "Hoangjimmy", "Password"));
        }

        public Utilisateur getUtilisateurByLogin(String logrech)
        {
            Utilisateur rech = null;
            foreach (Utilisateur u in Utilisateurs)
                if (String.Compare(logrech, u.Login) == 0)
                {
                    rech = u;
                    break;
                }
            return rech;
        }

        public void ToXml(String path)
        {
            StreamWriter stream = new StreamWriter(path + ".xml");
            XmlSerializer serializer = new XmlSerializer(typeof(List<Livre>));
            serializer.Serialize(stream, Livres);
            stream.Close();
        }
    }
}
