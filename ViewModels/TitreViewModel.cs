using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webzine.WebApplication.ViewModels
{
    public class TitreViewModel : BaseViewModel
    {
        public Entity.Titre Titre { get; set; }
        public Entity.Commentaire Commentaire { get; set; }
        public TitreViewModel()
        {

        }
    }
}
