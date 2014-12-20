using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;
using BusinessLayer;

namespace BiblioConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            BiblioManager biblioManager = new BiblioManager();

            Console.WriteLine("Liste des Auteurs avec prix goncourt");
            List<String> res = biblioManager.listeDesAuteursAvecPrixGoncourt();
            foreach (String s in res)
                Console.WriteLine(s);

            Console.WriteLine("\nListe des Livres de note > 5 avec auteur qui a gagné prix goncourt");
            List<String> res2 = biblioManager.listeDesLivresAvecNoteSuperieurACinqEtAuteurAvecPrixGoncourt();
            foreach (String s in res2)
                Console.WriteLine(s);

            Console.ReadLine();
        }
    }
}
