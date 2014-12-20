using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StubDataAccessLayer;

namespace BusinessLayer
{
    public class BiblioManager
    {
        private DalManager dal = new DalManager();

        static IList<String> listeDesEmpruntsEnCours()
        {
            List<String> resultat = new List<string>();

            return resultat;
        }

        static IList<String> listeDesAuteursAvecPrixGoncourt()
        {
            List<String> resultat = new List<string>();

            return resultat;
        }

        static IList<String> listeDesLivresAvecNoteSuperieurACinq()
        {
            List<String> resultat = new List<string>();

            return resultat;
        }

        static IList<String> listeDesLivresAvecNoteSuperieurACinqEtAuteurAvecPrixGoncourt()
        {
            List<String> resultat = new List<string>();

            return resultat;
        }
    }
}
