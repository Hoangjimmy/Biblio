using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public sealed class Genre
    {
        private int ID;

        public static readonly Genre BandeDessinee = new Genre(0);
        public static readonly Genre Biographie = new Genre(1);
        public static readonly Genre Conte = new Genre(2);
        public static readonly Genre Description = new Genre(3);
        public static readonly Genre Fantastique = new Genre(4);
        public static readonly Genre Horreur = new Genre(5);
        public static readonly Genre Name = new Genre(6);
        public static readonly Genre Nouvelle = new Genre(7);
        public static readonly Genre Roman = new Genre(8);
        public static readonly Genre ScienceFiction = new Genre(9);

        private Genre(int ID)
        {

        }
    }
}
