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
            List<String> res = null;
            int choix;
            do
            {
                Console.WriteLine("1) Liste des Emprunts en cours");
                Console.WriteLine("\n2) Liste des Auteurs avec prix goncourt");
                Console.WriteLine("\n3) Liste des Livres de note supérieure à 5 ");
                Console.WriteLine("\n4) Liste des Livres de note supérieure à 5 avec auteur qui a gagné prix goncourt");
                Console.WriteLine("\n0) Sortie");
                choix = Console.Read();
                switch (choix)
                { 
                    case 1:
                        res = biblioManager.listeDesEmpruntsEnCours();
                        break;
                    case 2:
                        res = biblioManager.listeDesAuteursAvecPrixGoncourt();
                        break;
                    case 3:
                        res = biblioManager.listeDesLivresAvecNoteSuperieurACinq();
                        break;
                    case 4:
                        res = biblioManager.listeDesLivresAvecNoteSuperieurACinqEtAuteurAvecPrixGoncourt();
                        break;
                    case 0:
                        Console.WriteLine("\nAu revoir");
                        break;
                    default:
                        Console.WriteLine("\nMauvais Choix");
                        break;
                }

                if (res != null)
                {
                    foreach (String s in res)
                        Console.WriteLine(s);
                }
            } while (choix != 0);

            
            
            /*Console.WriteLine("Liste des Auteurs avec prix goncourt");
            List<String> res = biblioManager.listeDesAuteursAvecPrixGoncourt();
            foreach (String s in res)
                Console.WriteLine(s);

            Console.WriteLine("\nListe des Livres de note > 5 avec auteur qui a gagné prix goncourt");
            List<String> res2 = biblioManager.listeDesLivresAvecNoteSuperieurACinqEtAuteurAvecPrixGoncourt();
            foreach (String s in res2)
                Console.WriteLine(s);

            Console.ReadLine();*/
        }
    }
}
