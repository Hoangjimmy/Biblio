using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StubDataAccessLayer;
using EntitiesLayer;
using System.Reflection;

namespace BusinessLayer
{
    public class BiblioManager
    {
        private DalManager _dal;

        private static BiblioManager instance;

        public static BiblioManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new BiblioManager();
                return instance;
            }
        } 
        
        public BiblioManager()
        {
            _dal = new DalManager();
        }

        public List<String> listeDesEmpruntsEnCours()
        {
            List<String> resultat = new List<string>();
            IEnumerable<Emprunt> emprunts = _dal.Emprunts.Where(e => DateTime.Compare( (e.DateFin), DateTime.Now) > 0);

            foreach (Emprunt e in emprunts)
                resultat.Add(e.ToString());

            return resultat;
        }

        public List<String> listeDesAuteursAvecPrixGoncourt()
        {
            List<String> resultat = new List<string>();

            IEnumerable<Auteur> auteurs = _dal.Auteurs.Where(a => a.PrixGoncourt == true);

            foreach (Auteur a in auteurs)
                resultat.Add(a.ToString());

            return resultat;
        }

        public List<String> listeDesLivresAvecNoteSuperieurACinq()
        {
            List<String> resultat = new List<string>();

            IEnumerable<Livre> livres = _dal.Livres.Where(l => l.Note < 5);

            foreach (Livre l in livres)
                resultat.Add(l.ToString());

            return resultat;
        }

        public List<String> listeDesLivresAvecNoteSuperieurACinqEtAuteurAvecPrixGoncourt()
        {
            List<String> resultat = new List<string>();

         // IEnumerable<Auteur> auteurs = _dal.Auteurs.Where(a => a.PrixGoncourt == true);

            IEnumerable<Livre> livres = _dal.Livres.Where(l =>l.Note > 5 && l.Auteur.PrixGoncourt == true);

            foreach (Livre l in livres)
                resultat.Add(l.ToString());

            return resultat;
        }

        public static IEnumerable<Emprunteur> listeEmprunteur()
        {
            return DalManager.Instance.Emprunteurs;
        }

        public bool CheckConnexionUser(String login, String password)
        {
            Utilisateur user = _dal.getUtilisateurByLogin(login);
            if (user != null)
            {
                return user.Password == password;
            }
            return false;
        }

        public static void exportLivres(string path)
        {
            DalManager.Instance.ToXml(path);
        }

        public static void removeEmprunteur(Emprunteur emprunteur)
        {
            DalManager.Instance.Emprunteurs.Remove(emprunteur);
        }

        public static void addEmprunteur(Emprunteur emprunteur)
        {
            DalManager.Instance.Emprunteurs.Add(emprunteur);
        }

        public static IEnumerable<Auteur> listeAuteur()
        {
            return DalManager.Instance.Auteurs;
        }

        public static void removeAuteur(Auteur auteur)
        {
            DalManager.Instance.Auteurs.Remove(auteur);
        }

        public static void addAuteur(Auteur auteur)
        {
            DalManager.Instance.Auteurs.Add(auteur);
        }

        public static IEnumerable<Livre> listeLivre()
        {
            return DalManager.Instance.Livres;
        }

        public static void removeLivre(Livre livre)
        {
            DalManager.Instance.Livres.Remove(livre);
        }

        public static void addLivre(Livre livre)
        {
            DalManager.Instance.Livres.Add(livre);
        }

        public static IEnumerable<Genre> listeGenre()
        {
            List<Genre> liste = new List<Genre>();

            liste.Add(Genre.BandeDessinee);
            liste.Add(Genre.Biographie);
            liste.Add(Genre.Conte);
            liste.Add(Genre.Description);
            liste.Add(Genre.Fantastique);
            liste.Add(Genre.Horreur);
            liste.Add(Genre.Name);
            liste.Add(Genre.Nouvelle);
            liste.Add(Genre.Roman);
            liste.Add(Genre.ScienceFiction);

            return liste;
        }
    }
}
