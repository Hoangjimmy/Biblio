using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    [SerializableAttribute]
    public class Auteur : Personne
    {
        public DateTime? DateMort { get; set; }
        public Boolean PrixGoncourt { get; set; }

        public Auteur() { }

        public Auteur (String prenom, String nom, ESexe sex, DateTime naissance, DateTime? mort, Boolean prix)
            : base(prenom, nom, sex, naissance)
        {
            this.DateMort = mort;
            this.PrixGoncourt = prix;
        }
    }
}
