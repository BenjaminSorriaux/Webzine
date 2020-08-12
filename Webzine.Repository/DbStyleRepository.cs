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
    public class DbStyleRepository : IStyleRepository
    {
        DatabaseContext _context = new DatabaseContext();

        /// <summary>
        /// Ajoute le style passé en paramètre dans la base de données.
        /// </summary>
        /// <param name="style"></param>
        public void Add(Style style)
        {
            _context.Styles.Add(style);
            _context.SaveChanges();
        }

        /// <summary>
        /// Supprime le style passé en paramètre de la base de données.
        /// </summary>
        /// <param name="style"></param>
        public void Delete(Style style)
        {
            _context.Styles.Remove(_context.Styles.Find(style.IdStyle));//Le tracking n'est pas conservé entre dans le view model donc on recupère l'objet ayant le tracking
            _context.SaveChanges();
        }

        /// <summary>
        /// Retourne le style correspondat à l'id entré en paramètre.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Style Find(int id)
        {
            return _context.Styles.Where(s=>s.IdStyle==id).Include(s=>s.TitresStyles).ThenInclude(ts=>ts.Titre).FirstOrDefault();
        }

        /// <summary>
        /// Retourne une liste contenant tous les styles de la base de données.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Style> FindAll()
        {
            return _context.Styles;
        }

        /// <summary>
        /// Met à jour le style correspondant à celui entré en paramètre dans la base de données.
        /// </summary>
        /// <param name="style"></param>
        public void Update(Style style)
        {
            var styleUpdate = _context.Styles.Find(style.IdStyle);
            styleUpdate.Libelle = style.Libelle;
            _context.Styles.Update(styleUpdate);
            _context.SaveChanges();
        }
    }
}
