using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webzine.Entity;

namespace Webzine.WebApplication.ViewModels
{
    public class ArtisteAdminViewModel
    {
        public List<Artiste> Artistes { get; set; }
        public Artiste Artiste { get; set; }
        public string MessageErreur { get; set; }


        public ArtisteAdminViewModel()
        {
            
            Artiste = new Artiste();
            Artiste.Nom = "";
            Artiste.Biographie = "";
            MessageErreur = null;
        }
    }
}
