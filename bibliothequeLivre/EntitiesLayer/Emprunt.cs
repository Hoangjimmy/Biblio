using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    class Emprunt:EntityObject
    {
        DateTime DateDebut{get;set;}
        DateTime DateFin{get;set;}
        Emprunteur Emprunter{get; set;}
        Livre Livr{get; set;}

        public Emprunt(DateTime debut, DateTime fin, Emprunteur emprunter, Livre livr)
             : base()
        { 
            this.DateDebut = debut;
            this.DateFin = fin;
            this.Emprunter = emprunter;
            this.Livr = livr;
        }

        public String ToString()
        {
            StringBuilder emprunt = new StringBuilder("Emprunt : ");
            emprunt.Append(DateDebut).Append(" ").Append(DateFin).Append(" ").Append(Emprunter).Append(" ").Append(Livr);
            return emprunt.ToString();   
        }
    }
}
