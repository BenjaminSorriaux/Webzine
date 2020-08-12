using System;
using System.Collections.Generic;
using System.Text;
using Webzine.Entity;
using Webzine.Repository.Contracts;

namespace Webzine.Business.Contracts
{
    public interface ITitreService
    {
        void IncrementeNbLikes(int idTitre, ITitreRepository titreRepository);
    }
}
