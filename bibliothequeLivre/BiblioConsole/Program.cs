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
            List<String> res = biblioManager.listeDesAuteursAvecPrixGoncourt();

            Console.WriteLine("Liste des Auteurs avec prix goncourt");
            foreach (String s in res)
                Console.WriteLine(s);

            Console.ReadLine();
        }
    }
}
