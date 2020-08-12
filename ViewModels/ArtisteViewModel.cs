using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webzine.Entity;

namespace Webzine.WebApplication.ViewModels
{
    public class ArtisteViewModel : BaseViewModel
    {
        public Artiste Artiste { get; set; }

        public IEnumerable<IGrouping<string, Titre>> TitresParAlbum { get; set; }

        public ArtisteViewModel()
        {
            
        }
    }
}
