using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Webzine.Entity;
using Webzine.Repository.Contracts;

namespace Webzine.Repository
{
    public class LocalArtisteRepository : IArtisteRepository
    {
        public void Add(Artiste artiste)
        {
            artiste.IdArtiste = FindAll().Max(a=>a.IdArtiste)+1;
            artiste.Titres = new List<Titre>();
            Factory.Artistes.Add(artiste);
        }

        public void Delete(Artiste artiste)
        {
           Factory.Artistes.Remove(Factory.Artistes.FirstOrDefault(a=>a.IdArtiste==artiste.IdArtiste));
        }

        public Artiste Find(int id)
        {
            return Factory.Artistes.FirstOrDefault(a => a.IdArtiste == id);
        }
        public IEnumerable<Artiste> Find(string nom)
        {
            return Factory.Artistes.Where(a => a.Nom.ToLower().Contains(nom.ToLower()));
        }

        public IEnumerable<Artiste> FindAll()
        {
            return Factory.Artistes;
        }

        public void Update(Artiste artiste)
        {
            //optimiser en une seul query si possible
            Factory.Artistes.FirstOrDefault(a => a.IdArtiste == artiste.IdArtiste).Nom = artiste.Nom ;
            Factory.Artistes.FirstOrDefault(a => a.IdArtiste == artiste.IdArtiste).Biographie = artiste.Biographie;


        }
    }
}
