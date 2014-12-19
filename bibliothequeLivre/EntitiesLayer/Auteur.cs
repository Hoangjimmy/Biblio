using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    class Auteur : Personne
    {
        DateTime DateMort { get; set; }
        Boolean PrixGoncourt{ get; set;};

        public Auteur (DateTime dat, String prenom, String nom, ESexe sex, DateTime mort, Boolean prix):base(dat, prenom, nom, sex)
        {
            this.DateMort = mort;
            this.PrixGoncourt = prix;
        }
    }
}
