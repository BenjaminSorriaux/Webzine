using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Webzine.EntitiesContext;
using Webzine.Entity;
using Webzine.Repository.Contracts;

namespace Webzine.Repository
{
    public class DbArtisteRepository : IArtisteRepository
    {
        DatabaseContext _context = new DatabaseContext();

        /// <summary>
        /// Ajoute l'artiste récupéré en paramètres à la base de données.
        /// </summary>
        /// <param name="artiste"></param>
        public void Add(Artiste artiste)
        {
            _context.Artistes.Add(artiste);
            _context.SaveChanges();
        }

        /// <summary>
        /// Supprime l'artiste récupéré en paramètre de la base de données.
        /// </summary>
        /// <param name="artiste"></param>
        public void Delete(Artiste artiste)
        {
            _context.Artistes.Remove(_context.Artistes.Find(artiste.IdArtiste));//Le tracking n'est pas conservé entre dans le view model donc on recupère l'objet ayant le tracking
            _context.SaveChanges();
        }

        /// <summary>
        /// Retourne l'artiste qui possède la clé primaire correspondant à l'id entré en paramètre.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Artiste Find(int id)
        {
            return _context.Artistes.Where(a=>a.IdArtiste==id).Include(a=>a.Titres).FirstOrDefault();
        }

        /// <summary>
        /// Retourne une liste d'artiste contenant la partie du mot / le mot entré(e) en paramètre.
        /// </summary>
        /// <param name="nom"></param>
        /// <returns></returns>
        public IEnumerable<Artiste> Find(string nom)
        {
            return _context.Artistes.Where(a => a.Nom.ToLower().Contains(nom.ToLower()));
        }

        /// <summary>
        /// Retourne une liste contenant tous les artistes.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Artiste> FindAll()
        {
            return _context.Artistes;
        }

        /// <summary>
        /// Met à jour l'artiste correspondant à l'artiste entré en paramètre.
        /// </summary>
        /// <param name="artiste"></param>
        public void Update(Artiste artiste)
        {
            var artisteUpdate = _context.Artistes.Find(artiste.IdArtiste);
            artisteUpdate.Nom = artiste.Nom;
            artisteUpdate.Biographie = artiste.Biographie;
            _context.Artistes.Update(artisteUpdate);
            _context.SaveChanges();
        }
    }
}
