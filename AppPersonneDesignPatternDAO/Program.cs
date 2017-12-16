using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppPersonneDesignPatternDAO.com.cours.dao.factory;
using AppPersonneDesignPatternDAO.com.cours.dao;
using AppPersonneDesignPatternDAO.com.cours.entities;

namespace AppPersonneDesignPatternDAO
{
    class Program
    {
        static void Main(string[] args)
        {
            SQLPersonneDAO sqlDao = new SQLPersonneDAO();
            Personne testPersonne = new Personne(0, "Paul", "Saxono", 64, 180, "rue des lilas", "Paris", "93000");

            //Liste des méthodes à tester

            displayPersonneById();
            //displayAllPersonne();
            //createPersonne();
            //updatePersonne();
            //deletePersonne();

            void displayPersonneById()
            {
                Personne personneById = sqlDao.FindById(5);
                string personne = personneById.ToString();
                Console.WriteLine(personne);
            }

            void displayAllPersonne()
            {
                List<Personne> listPersonnes = sqlDao.FindAll();
                foreach(Personne personne in listPersonnes)
                {
                    string currentPersonne = personne.ToString();
                    Console.WriteLine(currentPersonne);
                }                
            }

            void createPersonne()
            {
                Personne personneCreated = sqlDao.Create(testPersonne);
                string personne = personneCreated.ToString();
                Console.WriteLine(personne);
            }

            void updatePersonne()
            {
                Personne personneUpdated = sqlDao.Update(testPersonne);
                string personne = personneUpdated.ToString();
                Console.WriteLine(personne);
            }

            void deletePersonne()
            {
                bool success = sqlDao.Delete(testPersonne);
                if(success == true)
                {
                    Console.WriteLine("La personne a bien été supprimé");
                }
            }
        }
    }
}
