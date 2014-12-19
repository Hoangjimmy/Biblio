using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    class Livre : EntityObject
    {
        public String Auteur { get; set; }
        public DateTime DateParution{ get; set; }
        public String Editeur { get; set; }
        public Genre Genre { get; set; }
        public String ISBN { get; set; }
        public int NombrePages { get; set; }
        public String Titre { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("Livre : ");
            sb.Append(Auteur).Append(", ")
                .Append(DateParution).Append(", ")
                .Append(Editeur).Append(", ")
                .Append(Genre).Append(", ")
                .Append(NombrePages).Append(", ")
                .Append(Titre);
            return sb.ToString();
        }

        public Livre(String auteur, DateTime dateParution, String editeur, Genre genre, String isbn, int nombrePages, String titre)
        {
            Auteur = auteur;
            DateParution = dateParution;
            Editeur = editeur;
            Genre = genre;
            ISBN = isbn;
            NombrePages = nombrePages;
            Titre = titre;
    }
}
