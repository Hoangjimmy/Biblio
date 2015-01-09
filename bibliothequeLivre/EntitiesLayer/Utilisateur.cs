using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class Utilisateur
    {

        public String nom { get; set; }
        public String prenom { get; set; }
        public String login { get; set; }
        public String password { get; set; }

        public Utilisateur(String n, String p, String l , String pass) 
        {
            this.nom = nom;
            this.prenom = p;
            this.login = l;
            this.password = pass;
        }

    }
}
