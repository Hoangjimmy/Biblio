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
        public static Genre getGenreByID(int id)
        {
            /*DataTable dt = Datafill("SELECT Nom FROM Genres WHERE ID = " + id);
            DataRow dr = dt.Rows[0];
            Genre res = new Genre(id, dr["Nom"].ToString());
            return res;*/
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
                n.Genre = getGenreByID((int)dr["GenreID"]);
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
            foreach (DataRow dr in dt.Rows)
            {
                IList<Livre> listLivre = new List<Livre>();
                DataTable dt2 = Datafill("SELECT LivresId FROM LivreCollection WHERE CollectionId =" +(int)dr["ID"]);
                foreach(DataRow dr2 in dt2.Rows)
                {
                    Livre livre = getLivreByID((int)dr2["ID"]);
                    listLivre.Add(livre);
                }
                Collection n = new Collection(listLivre);
                res.Add(n);
            }
            return res;
        }

        public void AddModifyNewAuteur(Auteur aut)
        {
            SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Jean\Downloads\EasyBorrowing.mdf;Integrated Security=True;Connect Timeout=30");
            SqlCommand command = new SqlCommand ("UPDATE Auteurs SET ID = @id, Prenom = @prenom, Nom = @nom, DateNaissance = @datenaiss, DateDeces = @datedece, PrixGoncourt = @Prix, Sexe = @Sexe FROM (SELECT ID FROM AUTEUR WHERE ID = @id", connect);
            command.Parameters.AddWithValue("@id", aut.Id);
            command.Parameters.AddWithValue("@prenom", aut.Prenom);
            command.Parameters.AddWithValue("@nom", aut.Nom);
            command.Parameters.AddWithValue("@datenaiss", aut.DateNaissance);
            command.Parameters.AddWithValue("@datedece", aut.DateMort);
            command.Parameters.AddWithValue("@Prix", aut.PrixGoncourt);
            command.Parameters.AddWithValue("@Sexe", aut.Sexe);
            connect.Open();
            command.ExecuteNonQuery();
            connect.Close();
        }
        public void DeleteAuteur(Auteur aut)
        {
            SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Jean\Downloads\EasyBorrowing.mdf;Integrated Security=True;Connect Timeout=30");
            SqlCommand command = new SqlCommand("DELETE FROM Auteurs WHERE ID = @id", connect);
            command.Parameters.AddWithValue("@id", aut.Id);
            connect.Open();
            command.ExecuteNonQuery();
            connect.Close();
        }
        public void AddModifyCollection( Collection Collec)
        {
            SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Jean\Downloads\EasyBorrowing.mdf;Integrated Security=True;Connect Timeout=30");
            SqlCommand command = new SqlCommand("UPDATE Collections SET ID = @id,CollectionName = @cn, Description = @Descri  FROM (SELECT ID FROM Collections WHERE ID = @id", connect);
            command.Parameters.AddWithValue("@id", Collec.Id);
            command.Parameters.AddWithValue("@cn", Collec.Nom);
            command.Parameters.AddWithValue("@Descri", Collec.Description);
            connect.Open();
            command.ExecuteNonQuery();
            connect.Close();
        }
        public void DeleteCollection(Collection Collec)
        {
            SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Jean\Downloads\EasyBorrowing.mdf;Integrated Security=True;Connect Timeout=30");
            SqlCommand command = new SqlCommand("DELETE FROM Collections WHERE ID = @id", connect);
            command.Parameters.AddWithValue("@id", Collec.Id);
            connect.Open();
            command.ExecuteNonQuery();
            connect.Close();
        }
        public void AddModifyEmprunteur(Emprunteur emp)
        {
            SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Jean\Downloads\EasyBorrowing.mdf;Integrated Security=True;Connect Timeout=30");
            SqlCommand command = new SqlCommand("UPDATE Emprunteurs SET ID = @id, Prenom = @pre, Nom = @n, Sexe = @s, DateNaissance = @dn, Adresse = @addr, EMail = @em, Telephone = @tel  FROM (SELECT ID FROM Emprunteurs WHERE ID = @id", connect);
            command.Parameters.AddWithValue("@id", emp.Id);
            command.Parameters.AddWithValue("@n", emp.Nom);
            command.Parameters.AddWithValue("@pre", emp.Prenom);
            command.Parameters.AddWithValue("@s", emp.Sexe);
            command.Parameters.AddWithValue("@dn", emp.DateNaissance);
            command.Parameters.AddWithValue("@addr", emp.Adresse);
            command.Parameters.AddWithValue("@em", emp.Email);
            command.Parameters.AddWithValue("@tel", emp.Tel);
            connect.Open();
            command.ExecuteNonQuery();
            connect.Close();
        }
        public void DeleteEmprunteur(Emprunteur emp)
        {
            SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Jean\Downloads\EasyBorrowing.mdf;Integrated Security=True;Connect Timeout=30");
            SqlCommand command = new SqlCommand("DELETE FROM Emprunteurs WHERE ID = @id", connect);
            command.Parameters.AddWithValue("@id", emp.Id);
            connect.Open();
            command.ExecuteNonQuery();
            connect.Close();
        }
        public void AddModifyEmprunt(Emprunt emp)
        {
            SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Jean\Downloads\EasyBorrowing.mdf;Integrated Security=True;Connect Timeout=30");
            SqlCommand command = new SqlCommand("UPDATE Emprunts SET ID = @id, ID_LIVRE = @idli, ID_EMPRUNTEUR = @idemp, DATE_DEBUT = @Date debut, DATE_FIN = @datefin, DATE_FIN_PREVUE = @datefinprevu  FROM (SELECT ID FROM Emprunts WHERE ID = @id", connect);            
            command.Parameters.AddWithValue("@id", emp.Id);
            command.Parameters.AddWithValue("@idli", emp.Livre.Id);
            command.Parameters.AddWithValue("@idemp", emp.Emprunteur.Id);
            command.Parameters.AddWithValue("@Datedebut", emp.DateDebut);
            command.Parameters.AddWithValue("@datefin", emp.DateFin);
            command.Parameters.AddWithValue("@datefinprevu", emp.DateDebut.AddDays(14));
            connect.Open();
            command.ExecuteNonQuery();
            connect.Close();
        }
        public void DeleteEmprunt(Emprunt emp)
        {
            SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Jean\Downloads\EasyBorrowing.mdf;Integrated Security=True;Connect Timeout=30");
            SqlCommand command = new SqlCommand("DELETE FROM Emprunts WHERE ID = @id", connect);
            command.Parameters.AddWithValue("@id", emp.Id);
            connect.Open();
            command.ExecuteNonQuery();
            connect.Close();
        }

        public void AddModifyGenre(Genre g)
        {
            SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Jean\Downloads\EasyBorrowing.mdf;Integrated Security=True;Connect Timeout=30");
            SqlCommand command = new SqlCommand("UPDATE Genres SET ID = @id, Nom = @n  FROM (SELECT ID FROM Genres WHERE ID = @id", connect);
            command.Parameters.AddWithValue("@id",g.Id);
            command.Parameters.AddWithValue("@n", g.Nom);
            connect.Open();
            command.ExecuteNonQuery();
            connect.Close();
        }
        public void DeleteGenre(Genre g)
        {
            SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Jean\Downloads\EasyBorrowing.mdf;Integrated Security=True;Connect Timeout=30");
            SqlCommand command = new SqlCommand("DELETE FROM Genres WHERE ID = @id", connect);
            command.Parameters.AddWithValue("@id", g.Id);
            connect.Open();
            command.ExecuteNonQuery();
            connect.Close();
        }
        public void AddModifyLivre(Livre liv )
        {
            SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Jean\Downloads\EasyBorrowing.mdf;Integrated Security=True;Connect Timeout=30");
            SqlCommand command = new SqlCommand("UPDATE Livres SET ID = @id, AuteurID = @Aid, DateParution = @Dateparu, EditeurName = @en, GenreID = @gid, ISBN = @isbn, NombrePages = @nbpage, Note = @note, Titre = @titre  FROM (SELECT ID FROM Livres WHERE ID = @id", connect);
            command.Parameters.AddWithValue("@id", liv.Id);
            command.Parameters.AddWithValue("@Aid", liv.Auteur.Id);
            command.Parameters.AddWithValue("@DateParu", liv.DateParution);
            command.Parameters.AddWithValue("@en", liv.Editeur);
            command.Parameters.AddWithValue("@gid", liv.Genre.Id);
            command.Parameters.AddWithValue("@isbn", liv.ISBN);
            command.Parameters.AddWithValue("@nbpage", liv.NombrePages);
            command.Parameters.AddWithValue("@note", liv.Note);
            command.Parameters.AddWithValue("@titre", liv.Titre);
            connect.Open();
            command.ExecuteNonQuery();
            connect.Close();
        }
        public void DeleteLivre(Livre liv)
        {
            SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Jean\Downloads\EasyBorrowing.mdf;Integrated Security=True;Connect Timeout=30");
            SqlCommand command = new SqlCommand("DELETE FROM Livres WHERE ID = @id", connect);
            command.Parameters.AddWithValue("@id", liv.Id);
            connect.Open();
            command.ExecuteNonQuery();
            connect.Close();
        }
    }
}
