using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    sealed class Genre
    {
        public static readonly Genre BandeDessinee = new Genre();
        public static readonly Genre Biographie = new Genre();
        public static readonly Genre Conte = new Genre();
        public static readonly Genre Description = new Genre();
        public static readonly Genre Fantastique = new Genre();
        public static readonly Genre Horreur = new Genre();
        public static readonly Genre Name = new Genre();
        public static readonly Genre Nouvelle = new Genre();
        public static readonly Genre Roman = new Genre();
        public static readonly Genre ScienceFiction = new Genre();

        private Genre()
        {

        }
    }
}
