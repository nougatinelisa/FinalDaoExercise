using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace AppPersonneDesignPatternDAO.com.cours.dao
{
    class SQLPersonneDAO : AbstractPersonneDAO<entities.Personne>
    {
        public override entities.Personne FindById(int id)
        {
            string methodName = "displayPersonneById";
            string connectionString = ConfigurationManager.ConnectionStrings["connectionBasePersonnes"].ConnectionString;
            using (SqlConnection connexion = new SqlConnection(connectionString))
            {
                try
                {
                    // Ouverture de la connexion
                    connexion.Open();
                    SqlCommand sqlCommand = new SqlCommand("select * from Personne where Personne.IdPersonne=@id", connexion);
                    sqlCommand.Parameters.Add("@id", SqlDbType.Int);
                    sqlCommand.Parameters["@id"].Value = id;
                    sqlCommand.Prepare();
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                       entities.Personne personne = new entities.Personne(int.Parse(reader[0].ToString()), reader[1].ToString(), reader[2].ToString(), double.Parse(reader[3].ToString()), double.Parse(reader[4].ToString()), reader[5].ToString(), reader[6].ToString(), reader[7].ToString());
                       return personne;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Erreur lors de l'execution de la methode {0} , Exception : {1}", methodName, e.Message);
                }
            }
            return null;
        }

        public override List<entities.Personne> FindAll()
        {
            string methodName = "displayAllPersonnes";
            string connectionString =
            ConfigurationManager.ConnectionStrings["connectionBasePersonnes"].ConnectionString;
            using (SqlConnection connexion = new SqlConnection(connectionString))
            {
                try
                {
                    // Ouverture de la connexion
                    connexion.Open();
                    SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Personne", connexion);
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    List<entities.Personne> listPersonne = new List<entities.Personne>();
                    while (reader.Read())
                    {
                        //Console.WriteLine("idPersonne : {0} , prenom: {1} , nom: {2}", reader[0], reader[1], reader[2]);                       
                        listPersonne.Add(new entities.Personne(int.Parse(reader[0].ToString()), reader[1].ToString(), reader[2].ToString(), double.Parse(reader[3].ToString()), double.Parse(reader[4].ToString()), reader[5].ToString(), reader[6].ToString(), reader[7].ToString()));
                    }
                    return listPersonne;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Erreur lors de l'execution de la methode {0} , Exception : {1}", methodName,
                   e.Message);
                }
            }
            return null;
        }

        public override entities.Personne Create(entities.Personne personne)
        {
            string methodName = "CreatePersonne";
            int numRows = 0;
            string connectionString = ConfigurationManager.ConnectionStrings["connectionBasePersonnes"].ConnectionString;
            using (SqlConnection connexion = new SqlConnection(connectionString))
            {
                try
                {
                    //ouverture de la connexion
                    connexion.Open();
                    string requeteAddPersonne = "INSERT INTO Personne(Prenom,Nom,Poids,Taille,Rue,Ville,CodePostal) values(@prenom,@nom,@poids,@taille,@rue,@ville,@codepostal)";
                    SqlCommand sqlCommand = new SqlCommand(requeteAddPersonne, connexion);
                    sqlCommand.Parameters.Add("@prenom", SqlDbType.NVarChar, 100);
                    sqlCommand.Parameters.Add("@nom", SqlDbType.NVarChar, 100);
                    sqlCommand.Parameters.Add("@poids", SqlDbType.Float);
                    sqlCommand.Parameters.Add("@taille", SqlDbType.Float);
                    sqlCommand.Parameters.Add("@rue", SqlDbType.NVarChar, 100);
                    sqlCommand.Parameters.Add("@ville", SqlDbType.NVarChar, 100);
                    sqlCommand.Parameters.Add("@codepostal", SqlDbType.NVarChar, 100);              
                    sqlCommand.Parameters["@prenom"].Value = personne.prenom;
                    sqlCommand.Parameters["@nom"].Value = personne.nom;
                    sqlCommand.Parameters["@poids"].Value = personne.poids;
                    sqlCommand.Parameters["@taille"].Value = personne.taille;
                    sqlCommand.Parameters["@rue"].Value = personne.rue;
                    sqlCommand.Parameters["@ville"].Value = personne.ville;
                    sqlCommand.Parameters["@codepostal"].Value = personne.codePostal;
                    sqlCommand.Prepare();
                    numRows = sqlCommand.ExecuteNonQuery();
                    return personne;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Erreur lors de l'execution de la methode {0} , Exception : {1}", methodName, e.Message);
                }
            }
            return null;
        }
        public override entities.Personne Update(entities.Personne personne)
        {
            string methodName = "UpdatePrenomPersonne";
            int numRows = 0;
            string connectionString = ConfigurationManager.ConnectionStrings["connectionBasePersonnes"].ConnectionString;
            using (SqlConnection connexion = new SqlConnection(connectionString))
            {
                try
                {
                    connexion.Open();
                    string requeteUpdatePersonne = "UPDATE Personne SET Prenom=@prenom, Nom=@nom, Poids=@poids, Taille=@taille, Rue=@rue, Ville=@ville, CodePostal=@codepostal WHERE Personne.IdPersonne=@id";
                    SqlCommand sqlCommand = new SqlCommand(requeteUpdatePersonne, connexion);
                    sqlCommand.Parameters.Add("@id", SqlDbType.Int);
                    sqlCommand.Parameters.Add("@prenom", SqlDbType.NVarChar, 100);
                    sqlCommand.Parameters.Add("@nom", SqlDbType.NVarChar, 100);
                    sqlCommand.Parameters.Add("@poids", SqlDbType.Float);
                    sqlCommand.Parameters.Add("@taille", SqlDbType.Float);
                    sqlCommand.Parameters.Add("@rue", SqlDbType.NVarChar, 100);
                    sqlCommand.Parameters.Add("@ville", SqlDbType.NVarChar, 100);
                    sqlCommand.Parameters.Add("@codepostal", SqlDbType.NVarChar, 100);
                    sqlCommand.Parameters["@id"].Value = personne.idPersonne;
                    sqlCommand.Parameters["@prenom"].Value = personne.prenom;
                    sqlCommand.Parameters["@nom"].Value = personne.nom;
                    sqlCommand.Parameters["@poids"].Value = personne.poids;
                    sqlCommand.Parameters["@taille"].Value = personne.taille;
                    sqlCommand.Parameters["@rue"].Value = personne.rue;
                    sqlCommand.Parameters["@ville"].Value = personne.ville;
                    sqlCommand.Parameters["@codepostal"].Value = personne.codePostal;
                    sqlCommand.Prepare();
                    numRows = sqlCommand.ExecuteNonQuery();
                    return personne;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Erreur lors de l'execution de la methode {0} , Exception : {1}", methodName, e.Message);
                }
            }
            return null;
        }
        public override bool Delete(entities.Personne personne)
        {
            string methodName = "DeletePersonne";
            int numRows = 0;
            bool success = false;
            string connectionString =
           ConfigurationManager.ConnectionStrings["connectionBasePersonnes"].ConnectionString;
            using (SqlConnection connexion = new SqlConnection(connectionString))
            {
                try
                {
                    //ouverture de la connexion
                    connexion.Open();
                    string requeteAddPersonne = "DELETE FROM Personne where Personne.IdPersonne=@id";
                    SqlCommand sqlCommand = new SqlCommand(requeteAddPersonne, connexion);
                    sqlCommand.Parameters.Add("@id", SqlDbType.Int);
                    sqlCommand.Parameters["@id"].Value = personne.idPersonne;
                    sqlCommand.Prepare();
                    numRows = sqlCommand.ExecuteNonQuery();
                    success = true;
                    return success;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Erreur lors de l'execution de la methode {0} , Exception : {1}", methodName, e.Message);
                    success = false;
                    return success;
                }
            }
        }
    }
}
