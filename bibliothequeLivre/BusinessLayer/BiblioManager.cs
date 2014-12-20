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
        
        public BiblioManager()
        {
            _dal = new DalManager();
        }

        public List<String> listeDesEmpruntsEnCours()
        {
            List<String> resultat = new List<string>();

            return resultat;
        }

        public List<String> listeDesAuteursAvecPrixGoncourt()
        {
            List<String> resultat = new List<string>();

            List<Auteur> auteurs = _dal.Auteurs.Where(a => a.PrixGoncourt == true).ToList();

            foreach (Auteur a in auteurs)
                resultat.Add(a.ToString());

            return resultat;
        }

        public List<String> listeDesLivresAvecNoteSuperieurACinq()
        {
            List<String> resultat = new List<string>();

            return resultat;
        }

        public List<String> listeDesLivresAvecNoteSuperieurACinqEtAuteurAvecPrixGoncourt()
        {
            List<String> resultat = new List<string>();

            return resultat;
        }
    }
}
