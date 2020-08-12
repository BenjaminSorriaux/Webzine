using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Webzine.EntitiesContext;
using Webzine.Entity;
using Webzine.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Webzine.Repository
{
    public class DbCommentaireRepository : ICommentaireRepository
    {
        DatabaseContext _context = new DatabaseContext();

        /// <summary>
        /// Ajoute le commentaire passé en paramètre à la base de données.
        /// </summary>
        /// <param name="commentaire"></param>
        public void Add(Commentaire commentaire)
        {
            commentaire.Musique = _context.Titres.FirstOrDefault(t => t.IdTitre == commentaire.IdTitre);
            _context.Commentaires.Add(commentaire);
            _context.SaveChanges();
        }

        /// <summary>
        /// Supprimer le commentaire passé en paramètre de la base de données.
        /// </summary>
        /// <param name="commentaire"></param>
        public void Delete(Commentaire commentaire)
        {
            _context.Commentaires.Remove(_context.Commentaires.Find(commentaire.IdCommentaire));//Le tracking n'est pas conservé entre dans le view model donc on recupère l'objet ayant le tracking
            _context.SaveChanges();
        }

        public Commentaire Find(int id)
        {
            return _context.Commentaires.Where(c => c.IdCommentaire == id).Include(c => c.Musique).FirstOrDefault();
        }

        /// <summary>
        /// Retourne une liste contenant tous les commentaires de la base de données.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Commentaire> FindAll()
        {
            return _context.Commentaires.Include(c => c.Musique);
        }
    }
}
