using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;


namespace EntitiesLayer
{
    [Serializable]
    public class Livre : EntityObject
    {
        public Auteur Auteur { get; set; }
        public DateTime DateParution { get; set; }
        public String Editeur { get; set; }
        public Genre Genre { get; set; }
        public String ISBN { get; set; }
        public int NombrePages { get; set; }
        public int Note { get; set; }
        public String Titre { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("Livre : ");
            sb.Append("(").Append(Auteur.ToString()).Append("), ")
                .Append(DateParution.Year).Append(", ")
                .Append(Editeur).Append(", ")
                .Append(Genre).Append(", ")
                .Append(NombrePages).Append(", ")
                .Append(Note).Append(", ")
                .Append(Titre);
            return sb.ToString();
        }

        public Livre(Auteur auteur, DateTime dateParution, String editeur, Genre genre, String isbn, int nombrePages, int note, String titre)
        {
            Auteur = auteur;
            DateParution = dateParution;
            Editeur = editeur;
            Genre = genre;
            ISBN = isbn;
            NombrePages = nombrePages;
            Note = note;
            Titre = titre;
        }

    }
}
