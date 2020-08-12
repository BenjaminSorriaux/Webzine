using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webzine.WebApplication.ViewModels
{
    public class TitresViewModel : BaseViewModel
    {
        public List<Entity.Titre> Titres { get; set; }
        public List<Entity.Titre> TitresPlusEcoutes { get; set; }
        public List<Entity.Titre> TitresRecent { get; set; }
    }
}
