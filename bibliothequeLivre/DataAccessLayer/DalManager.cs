using EntitiesLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Data.SqlClient;
using System.Data;

namespace DataAccessLayer
{
    public class DalManager
    {
        public List<Auteur> Auteurs { get; set; }
        public List<Livre> Livres { get; set; }
        public List<Emprunteur> Emprunteurs { get; set; }
        public List<Emprunt> Emprunts { get; set; }
        public List<Utilisateur> Utilisateurs { get; set; }
        private static DalManager instance;
        private static readonly object padlock = new object();
        public static DalManager Instance
        {
            get
            {
                if (instance == null)
                {
                    lock(padlock)
                        if (instance == null)
                        {
                            instance = new DalManager();
                        }
                }
                return instance;
            }
        }
        public static DataTable Datafill (String requete)
        {
            DataTable dt = new DataTable();
            String connexionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Jean\Downloads\EasyBorrowing.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection connexion = new SqlConnection(connexionString);
            connexion.Open();
            SqlCommand cmd = new SqlCommand(requete, connexion);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.Fill(dt);
            connexion.Close();
            return dt;

        }
        public static Emprunteur getEmprunteurByID (int id)
        {
            
            DataTable dt = Datafill("SELECT * FROM Emprunteurs Where ID = " + id);
            DataRow dr = dt.Rows[0];
            ESexe sex = (ESexe)Enum.Parse(typeof(ESexe),dr["Sexe"].ToString());
            Emprunteur n = new Emprunteur(
                dr["Prenom"].ToString(),
                dr["Nom"].ToString(),
                sex,
                (DateTime)dr["DateNaissance"],
                dr["Adresse"].ToString(),
                dr["EMail"].ToString(),
                dr["Telephone"].ToString()
            );
            return n;

        }
        public static Livre getLivreByID (int id)
        {
            DataTable dt = Datafill("SELECT * FROM Livres Where ID = "+id);
            DataRow dr = dt.Rows[0];
            Livre n = new Livre();
            n.Id = (int)dr["ID"];
            n.Auteur = getAuteurById((int)dr["AuteurID"]);
            n.DateParution = (DateTime)dr["DateParution"];
            n.Editeur = dr["EditeurName"].ToString();
            // n.Genre = dr["GenreID"].ToString();
            n.ISBN = dr["ISBN"].ToString();
            n.NombrePages = (int)dr["NombrePages"];
            n.Note = (int)dr["Note"];
            n.Titre = dr["Titre"].ToString();
            return n;
        }
        public static Auteur getAuteurById(int id)
        {
            Auteur aut = new Auteur();
            DataTable dt = Datafill("SELECT * FROM Auteurs WHERE ID ="+id);
            DataRow dr = dt.Rows[0];
            aut.Id = (int)dr["ID"];
            aut.Nom = dr["Nom"].ToString();
            aut.Prenom = dr["Prenom"].ToString();
            aut.PrixGoncourt = (Boolean)dr["PrixGoncourt"];
            aut.DateMort = (DateTime)dr["DateDeces"];
            aut.DateNaissance = (DateTime)dr["DateNaissance"];
            return aut;
        }
        public static Genre getGenreByID(int id) { 
        
        
        }
        public static List<Auteur> getAuteurs() 
        {
            DataTable dt = Datafill("SELECT * FROM Auteurs");
            List<Auteur> res = new List<Auteur>();
            foreach (DataRow dr in dt.Rows)
            {
                Auteur n = new Auteur();
                n.Id = (int)dr["ID"];
                n.Nom = dr["Nom"].ToString();
                n.Prenom = dr["Prenom"].ToString();
                n.PrixGoncourt = (Boolean)dr["PrixGoncourt"];
                n.DateMort = (DateTime)dr["DateDeces"];
                n.DateNaissance = (DateTime)dr["DateNaissance"];
                res.Add(n);
            }
            return res;
        }
        public static List<Livre> getLivre()
        {
            DataTable dt = Datafill("SELECT * FROM Livres");
            List<Livre> res = new List<Livre>();
            foreach (DataRow dr in dt.Rows)
            {
                Livre n = new Livre();
                n.Id = (int)dr["ID"];
                n.Auteur = getAuteurById((int)dr["AuteurID"]);
                n.DateParution = (DateTime)dr["DateParution"];
                n.Editeur = dr["EditeurName"].ToString();
               // n.Genre = dr["GenreID"].ToString();
                n.ISBN = dr["ISBN"].ToString();
                n.NombrePages = (int)dr["NombrePages"];
                n.Note = (int)dr["Note"];
                n.Titre = dr["Titre"].ToString();
                res.Add(n);
            }
            return res;
        }
        public static List<Emprunt> getEmprunt()
        {
            List<Emprunt> res = new List<Emprunt>();
            DataTable dt = Datafill("SELECT * FROM Emprunts");
            foreach (DataRow dr in dt.Rows)
            {
                Emprunt n = new Emprunt (
                    (DateTime)dr["DATE_DEBUT"],
                    (DateTime)dr["DATE_FIN"],
                    getEmprunteurByID((int)dr["ID_EMPRUNTEUR"]),
                    getLivreByID((int)dr["ID_LIVRE"])           
                    );
            }

            return res;
        }
        public static List<Collection> getCollection()
        {
            DataTable dt = Datafill("Select * FROM Collections");
            List<Collection> res = new List<Collection>();

        }
    }
}
