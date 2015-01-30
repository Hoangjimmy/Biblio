using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StubDataAccessLayer;
using EntitiesLayer;

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

        public static List<Emprunteur> listeEmprunteur()
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
    }
}
