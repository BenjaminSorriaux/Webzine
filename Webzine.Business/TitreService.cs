using Webzine.Business.Contracts;
using Webzine.Repository;
using Webzine.Repository.Contracts;

namespace Webzine.Business
{
    public class TitreService : ITitreService
    {
        private ITitreRepository repository;
        public void IncrementeNbLikes(int idTitre, ITitreRepository titreRepository)
        {
            repository = titreRepository;
            var titre = repository.Find(idTitre);
            titre.NbLikes++;
            repository.IncrementNbLikes(titre);
        }
    }
}
