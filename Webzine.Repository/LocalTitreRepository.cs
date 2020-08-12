using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Webzine.Entity;
using Webzine.Repository.Contracts;

namespace Webzine.Repository
{
    public class LocalTitreRepository : ITitreRepository
    {
        public void Add(Titre titre)
        {
            titre.TitresStyles.ForEach(ts => ts.Titre = titre);//ajoute le titre à ses styles
            titre.IdTitre = Factory.Titres.Max(t => t.IdTitre) + 1;
            titre.DateCreation = DateTime.Now;
            Factory.Titres.Add(titre);
        }

        public int Count()
        {
            return Factory.Titres.Count();
        }

        public void Delete(Titre titre)
        {
            Factory.Commentaires.RemoveAll(c => c.IdTitre == titre.IdTitre);//pourrait créer des problèmes si un autre titre recuperait l'id du titre supprimé
            Factory.Artistes.ForEach(a => a.Titres.Remove(titre));
            Factory.Styles.ForEach(s => s.TitresStyles.RemoveAll(ts => ts.Titre == titre));//enlève tout les liens entre les styles et le titre
            Factory.Titres.Remove(titre);
        }

        public Titre Find(int idTitre)
        {
            return Factory.Titres.FirstOrDefault(t => t.IdTitre == idTitre);
        }

        public IEnumerable<Titre> FindAll()
        {
            return Factory.Titres;
        }

        public IEnumerable<Titre> FindTitres(int offset, int limit)
        {
            return Factory.Titres.GetRange(offset, limit);
        }

        public IEnumerable<Titre> FindTitresPopulaires(int quantitee)
        {
            return Factory.Titres.OrderByDescending(t => t.NbLectures).Take(quantitee);

        }

        public IEnumerable<Titre> FindTitresReçent(int quantitee)
        {
            return Factory.Titres.OrderByDescending(t => t.DateCreation).Take(quantitee);

        }

        public void IncrementNbLectures(Titre titre)
        {
            Factory.Titres.FirstOrDefault(t => t.IdTitre == titre.IdTitre).NbLectures += 1;
        }

        public void IncrementNbLikes(Titre titre)
        {
            Factory.Titres.FirstOrDefault(t=>t.IdTitre==titre.IdTitre).NbLikes=titre.NbLikes;
        }

        public IEnumerable<Titre> Search(string mot)
        {
            return Factory.Titres.Where(t => t.Libelle.ToLower().Contains(mot.ToLower()));
        }

        public IEnumerable<Titre> SearchByStyle(string libelle)
        {

            var result = Factory.Styles.FirstOrDefault(s => s.Libelle == libelle);
            if (result.TitresStyles != null)
            {
                return result.TitresStyles.Select(ts=>ts.Titre);
            }
            else
            {
                return new List<Titre>();
            }
        }

        public void Update(Titre titre)
        {
            //mise a jour des propriétées du titre selectioné
            Factory.Titres.FirstOrDefault(t => t.IdTitre == titre.IdTitre).Artiste = titre.Artiste;
            Factory.Titres.FirstOrDefault(t => t.IdTitre == titre.IdTitre).IdArtiste = titre.Artiste.IdArtiste;
            Factory.Titres.FirstOrDefault(t => t.IdTitre == titre.IdTitre).Libelle = titre.Libelle;
            Factory.Titres.FirstOrDefault(t => t.IdTitre == titre.IdTitre).DateSortie = titre.DateSortie;
            Factory.Titres.FirstOrDefault(t => t.IdTitre == titre.IdTitre).Chronique = titre.Chronique;
            Factory.Titres.FirstOrDefault(t => t.IdTitre == titre.IdTitre).Duree = titre.Duree;
            Factory.Titres.FirstOrDefault(t => t.IdTitre == titre.IdTitre).UrlJaquette = titre.UrlJaquette;
            Factory.Titres.FirstOrDefault(t => t.IdTitre == titre.IdTitre).UrlEcoute = titre.UrlEcoute;
            Factory.Titres.FirstOrDefault(t => t.IdTitre == titre.IdTitre).TitresStyles = titre.TitresStyles;
            Factory.Titres.FirstOrDefault(t => t.IdTitre == titre.IdTitre).NbLectures = titre.NbLectures;
            Factory.Titres.FirstOrDefault(t => t.IdTitre == titre.IdTitre).NbLikes = titre.NbLikes;
        }
    }
}
