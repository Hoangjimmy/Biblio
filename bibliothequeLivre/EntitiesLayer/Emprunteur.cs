using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class Emprunteur : Personne
    {
        String Adresse { get; set;}
        String Email { get; set; }
        String Tel { get; set; }

        public Emprunteur(String prenom, String nom, ESexe sex, DateTime naissance, String addr, String mail, String tel)
            : base(prenom, nom, sex, naissance)
        {   
            this.Adresse = addr;
            this.Email = mail ;
            this.Tel = tel;
        }

        public override string ToString()
        {
    
            StringBuilder emprunt = new StringBuilder("Emprunteur : ");
            emprunt.Append(Nom).Append(" ").Append(Prenom).Append(" ").Append(DateNaissance).Append(" ").Append(emprunt.getSexe()).
            Append(" ").Append(Adresse).Append(" ").Append(Email).Append(" ").Append(Tel);
            return emprunt.ToString();     
        }
    }
}
