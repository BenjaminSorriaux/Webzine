using System;
using System.Collections.Generic;
using System.Text;
using Webzine.Entity;
using Webzine.Repository.Contracts;
using System.Linq;

namespace Webzine.Repository
{
    public class LocalCommentaireRepository : ICommentaireRepository
    {
        public void Add(Commentaire commentaire)
        {
            commentaire.IdCommentaire = Factory.Commentaires.Count() + 1;
            Factory.Commentaires.Add(commentaire);
            Factory.Titres.FirstOrDefault(t => t.IdTitre == commentaire.IdTitre).Commentaires.Add(commentaire);

        }

        public void Delete(Commentaire commentaire)
        {
            Factory.Titres.ForEach(t => t.Commentaires.Remove(commentaire));
            Factory.Commentaires.Remove(commentaire);
        }

        public IEnumerable<Commentaire> FindAll()
        {
            return Factory.Commentaires;
        }

        public Commentaire Find(int id)
        {
            return Factory.Commentaires.FirstOrDefault(c => c.IdCommentaire == id);
        }
    }
}
