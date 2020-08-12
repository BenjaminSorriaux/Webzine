using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webzine.Entity;

namespace Webzine.WebApplication.ViewModels
{
    public class SearchViewModel : BaseViewModel
    {
        public List<Titre> Titres { get; set; }
        public List<Artiste> Artistes { get; set; }
    }
}
