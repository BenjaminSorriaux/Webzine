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
    public class DbTitreRepository : ITitreRepository
    {
        DatabaseContext _context = new DatabaseContext();

        /// <summary>
        /// Ajoute le titre passé en paramètre à la base de données.
        /// </summary>
        /// <param name="titre"></param>
        public void Add(Titre titre)
        {
            titre.Artiste = _context.Artistes.FirstOrDefault(x => x.IdArtiste == titre.IdArtiste);
            titre.TitresStyles.ForEach(ts => { ts.Style = _context.Styles.FirstOrDefault(s => s.IdStyle == ts.IdStyle); });//Evite erreur de recréation d'objet a lier au titre à inserer
            _context.Titres.Add(titre);
            _context.SaveChanges();
        }

        /// <summary>
        /// Retourne le nombre de titres contenus dans la base de données.
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return _context.Titres.Count();
        }

        /// <summary>
        /// Supprime le titre passé en paramètre de la base de données.
        /// </summary>
        /// <param name="titre"></param>
        public void Delete(Titre titre)
        {
            _context.Titres.Remove(titre);
            _context.SaveChanges();
        }

        /// <summary>
        /// Retourne le titre possédant l'id passé en paramètre.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Titre Find(int idTitre)
        {
            return _context.Titres.Where(t => t.IdTitre == idTitre).Include(t => t.Artiste).Include(t => t.TitresStyles).ThenInclude(ts => ts.Style).Include(t => t.Commentaires).FirstOrDefault();
        }

        /// <summary>
        /// Récupère une liste contenant tous les titres de la base de données.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Titre> FindAll()
        {
            return _context.Titres.Include(t => t.Artiste).Include(t=>t.Commentaires);
        }

        /// <summary>
        /// Retourne les titres demandés (pour la pagination) triés selon la date de création (du plus récent à ancien). 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Titre> FindTitres(int offset, int limit)
        {
            return _context.Titres.Skip(offset).Take(limit).OrderBy(t => t.DateCreation);
        }

        public IEnumerable<Titre> FindTitresPopulaires(int quantitee)
        {
            return _context.Titres.OrderByDescending(t => t.NbLikes).Take(quantitee).Include(t => t.Artiste);
        }

        public IEnumerable<Titre> FindTitresReçent(int quantitee)
        {
            return _context.Titres.OrderByDescending(t => t.DateCreation).Take(quantitee).Include(t => t.Artiste).Include(t => t.TitresStyles).ThenInclude(ts => ts.Style);
        }

        /// <summary>
        /// Incrémente le nombre de lectures du titre passé en paramètre de 1.
        /// </summary>
        /// <param name="titre"></param>
        public void IncrementNbLectures(Titre titre)
        {
            titre.NbLectures += 1;
            _context.Titres.Update(titre);
            _context.SaveChanges();
        }

        /// <summary>
        /// Incrémente le nombre de likes du titre passé en paramètre de 1.
        /// </summary>
        /// <param name="titre"></param>
        public void IncrementNbLikes(Titre titre)
        {
            _context.Titres.Update(titre);
            _context.SaveChanges();
        }

        /// <summary>
        /// Retourne une liste de titres contenant le mot passé en paramètre
        /// </summary>
        /// <param name="mot"></param>
        /// <returns></returns>
        public IEnumerable<Titre> Search(string mot)
        {
            return _context.Titres.Where(t => t.Libelle.ToLower().Contains(mot.ToLower()));
        }      

        /// <summary>
        /// Met à jour un titre de la base de données.
        /// </summary>
        /// <param name="titre"></param>
        public void Update(Titre titre)
        {
            titre.Artiste = _context.Artistes.FirstOrDefault(x => x.IdArtiste == titre.IdArtiste);
            titre.TitresStyles.ForEach(ts => { ts.Style = _context.Styles.FirstOrDefault(s => s.IdStyle == ts.IdStyle); });//Evite erreur de recréation d'objet a lier au titre à inserer
            var updatetitre = _context.Titres.FirstOrDefault(t=>t.IdTitre==titre.IdTitre);

            //L'update ne fonctionne pas en passant directement l'objet : il y a une erreur de tracking sur l'objet modifié donc on modifie directement l'objet du repository puis on sauvegarde
            //l'objet dans la base
            updatetitre.Artiste = titre.Artiste;
            updatetitre.Chronique = titre.Chronique;
            updatetitre.Commentaires = titre.Commentaires;
            updatetitre.DateCreation = titre.DateCreation;
            updatetitre.DateSortie = titre.DateSortie;
            updatetitre.Duree = titre.Duree;
            updatetitre.IdArtiste = titre.IdArtiste;
            updatetitre.Libelle = titre.Libelle;
            updatetitre.NbLectures = titre.NbLectures;
            updatetitre.NbLikes = titre.NbLikes;
            updatetitre.TitresStyles = titre.TitresStyles;
            updatetitre.UrlEcoute = titre.UrlEcoute;
            updatetitre.UrlJaquette = titre.UrlJaquette;


            _context.Titres.Update(updatetitre);
            _context.SaveChanges();
        }
    }
}
