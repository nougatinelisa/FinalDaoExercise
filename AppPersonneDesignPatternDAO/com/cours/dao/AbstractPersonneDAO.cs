using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPersonneDesignPatternDAO.com.cours.dao
{
    public abstract class AbstractPersonneDAO<Personne>
    {
        /**
        * Permet de récupérer un objet via son ID */
        public abstract Personne FindById(int id);
        /**
        * Permet de récupérer tous les objets de type T */
        public abstract List<Personne> FindAll();
        /**
        * Permet de créer une entrée dans la datasource par rapport à un objet */
        public abstract Personne Create(Personne personne);
        /**
        * Permet de mettre à jour les données d'une entrée dans la datasource */
        public abstract Personne Update(Personne personne);
        /**
        * Permet la suppression d'une entrée de la datasource */
        public abstract bool Delete(Personne personne);
    }
}
