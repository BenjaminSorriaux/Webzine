using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webzine.WebApplication.ViewModels
{
    public class CommentaireViewModel : BaseViewModel
    {
        public Entity.Commentaire Commentaire { get; set; }

        public CommentaireViewModel()
        {

        }
    }
}
