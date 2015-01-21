﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public enum ESexe
    {
        Feminin,
        Masculin,
        Indetermine
    }

    public class Personne : EntityObject
    {
        public DateTime DateNaissance { get; set; }
        public String Prenom { get; set; }
        public String Nom { get; set; }
        public ESexe Sexe { get; set; }

        public Personne() { }

        public Personne(String prenom, String nom, ESexe sex, DateTime naissance)
            : base()
        {
            this.DateNaissance = naissance;
            this.Prenom = prenom;
            this.Nom = nom;
            this.Sexe = sex;
        }

        public override string ToString()
        {
            StringBuilder person = new StringBuilder("Personne : ");
            person.Append(Nom).Append(" ").Append(Prenom).Append(" né(e) le ").Append(DateNaissance.ToLongDateString()).Append(" de sexe ").Append(Sexe);
            return person.ToString();
        }

    }
}
