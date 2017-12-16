using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPersonneDesignPatternDAO.com.cours.entities
{
    class Personne
    {
        //Attributes
        public int idPersonne { get; set; }
        public string prenom { get; set; }
        public string nom { get; set; }
        public double poids { get; set; }
        public double taille { get; set; }
        public string rue { get; set; }
        public string ville { get; set; }
        public string codePostal { get; set; }


        //Constructeurs
        public Personne(int idPersonne, string prenom, string nom, double poids, double taille, string rue, string ville, string codePostal)
        {
            this.idPersonne = idPersonne;
            this.prenom = prenom;
            this.nom = nom;
            this.poids = poids;
            this.taille = taille;
            this.rue = rue;
            this.ville = ville;
            this.codePostal = codePostal;
        }

        public override string ToString()
        {
            return String.Format("[idPersonne={0},prenom={1}, nom={2}, poids={3}, taille{4}, rue={5},ville={6}, codePostal={7}]",
           idPersonne, prenom, nom, poids, taille, rue, ville, codePostal);
        }

        public double GetIMC(double poids, double taille)
        {
            double IMC = 0;
            IMC = poids / taille * taille;
            return IMC;
        }

        public bool IsMaigre(double IMC)
        {
            Boolean maigre = false;
            if (IMC <= 18.5 && IMC >= 16.5)
            {
                maigre = true;
            }
            else
            {
                maigre = false;
            }
            return maigre;
        }

        public bool IsSurPOids(double IMC)
        {
            Boolean surpoids = false;
            if (IMC <= 30 && IMC >= 25)
            {
                surpoids = true;
            }
            else
            {
                surpoids = false;
            }
            return surpoids;
        }

        public bool IsOBese(double IMC)
        {
            Boolean obese = false;
            if (IMC < 30)
            {
                obese = true;
            }
            else
            {
                obese = false;
            }
            return obese;
        }
    }
}
