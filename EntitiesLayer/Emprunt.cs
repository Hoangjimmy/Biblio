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
        public Emprunteur Emprunter { get; set; }
        public Livre Livre { get; set; }

        public Emprunt(DateTime debut, DateTime fin, Emprunteur emprunter, Livre livre)
             : base()
        { 
            this.DateDebut = debut;
            this.DateFin = fin;
            this.Emprunter = emprunter;
            this.Livre = livre;
        }

        public override string ToString()
        {
            StringBuilder emprunt = new StringBuilder("Emprunt : ");
            emprunt.Append(DateDebut).Append(" ").Append(DateFin).Append(" ").Append(Emprunter).Append(" ").Append(Livre);
            return emprunt.ToString();   
        }
    }
}
