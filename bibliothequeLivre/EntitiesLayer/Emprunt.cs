using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class Emprunt : EntityObject
    {
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public DateTime DateFinPrevue { get; set; }
        public Emprunteur Emprunteur { get; set; }
        public Livre Livre { get; set; }

        public Emprunt(DateTime debut, DateTime fin, Emprunteur emprunter, Livre livre)
             : base()
        { 
            this.DateDebut = debut;
            this.DateFin = fin;
            this.Emprunteur = emprunter;
            this.Livre = livre;
        }

        public Emprunt()
        {}

        public Emprunt(Emprunt previousEmprunt)
        {
            Id = previousEmprunt.Id;
            DateDebut = previousEmprunt.DateDebut;
            DateFin = previousEmprunt.DateFin;
            DateFinPrevue = previousEmprunt.DateFinPrevue;
            Emprunteur = previousEmprunt.Emprunteur;
            Livre = previousEmprunt.Livre;
        }

        public override string ToString()
        {
            StringBuilder emprunt = new StringBuilder("Emprunt : ");
            emprunt.Append(DateDebut).Append(" ").Append(DateFin).Append(" ").Append(Emprunteur).Append(" ").Append(Livre);
            return emprunt.ToString();   
        }
    }
}
