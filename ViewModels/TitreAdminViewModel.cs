using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webzine.WebApplication.ViewModels
{
    public class TitreAdminViewModel : BaseViewModel
    {
        public List<Entity.Artiste> Artistes { set; get; }
        public Entity.Titre Titre { get; set; }
        

        
    }
}
