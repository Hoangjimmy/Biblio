using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class Utilisateur
    {

        public String Nom { get; set; }
        public String Prenom { get; set; }
        public String Login { get; set; }
        public String Password { get; set; }

        public Utilisateur(String n, String p, String l , String pass) 
        {
            this.Nom = n;
            this.Prenom = p;
            this.Login = l;
            this.Password = pass;
        }

    }
}
