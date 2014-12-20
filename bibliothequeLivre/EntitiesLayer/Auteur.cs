﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class Auteur : Personne
    {
        DateTime DateMort { get; set; }
        Boolean PrixGoncourt{ get; set;}

        public Auteur (String prenom, String nom, ESexe sex, DateTime naissance, DateTime mort, Boolean prix)
            : base(prenom, nom, sex, naissance)
        {
            this.DateMort = mort;
            this.PrixGoncourt = prix;
        }
    }
}