using System;
using System.Collections.Generic;
using System.Text;
using Webzine.Entity;

namespace Webzine.Repository.Contracts
{
    public interface IArtisteRepository
    {
        void Add(Artiste artiste);
        void Delete(Artiste artiste);
        Artiste Find(int id);
        IEnumerable<Artiste> Find(string nom);
        IEnumerable<Artiste> FindAll();
        void Update(Artiste artiste);
    }
}
