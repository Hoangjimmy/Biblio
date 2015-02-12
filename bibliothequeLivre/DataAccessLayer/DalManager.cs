using EntitiesLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Data.SqlClient;

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


        public static void  getAuteur() 
        {   
            Auteur aut;
            List<Auteur> res = new List<Auteur>();
            string connexionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\hoangjim\Downloads\EasyBorrowing.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection connexion = new SqlConnection(connexionString);
            connexion.Open();
            string requete = ("SELECT * FROM Auteurs;");
            SqlCommand cmd = new SqlCommand(requete, connexion);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {   

                //res.Add(aut);
            }


            
            
            
            connexion.Close();

        }
    }
}
