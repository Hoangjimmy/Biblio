using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public sealed class Genre
    {
        public int Id{private set; get;}
        public string Nom {private set; get;}


        public static readonly Genre BandeDessinee = new Genre(0,"Bande Dessinee");
        public static readonly Genre Biographie = new Genre(1,"Biographie");
        public static readonly Genre Conte = new Genre(2,"Conte");
        public static readonly Genre Description = new Genre(3,"Description");
        public static readonly Genre Fantastique = new Genre(4,"Fantastique");
        public static readonly Genre Horreur = new Genre(5,"Horreur");
        public static readonly Genre Name = new Genre(6, "Name");
        public static readonly Genre Nouvelle = new Genre(7,"Nouvelle");
        public static readonly Genre Roman = new Genre(8,"Roman");
        public static readonly Genre ScienceFiction = new Genre(9,"Science Fiction");

        private Genre(int id, string nom)
        {
            this.Id = id;
            this.Nom = nom;
        }
    }
}
