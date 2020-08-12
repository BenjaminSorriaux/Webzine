using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webzine.Entity;

namespace Webzine.WebApplication.ViewModels
{
    public class StyleAdminViewModel
    {
        public List<Style> Styles { get; set; }
        public Style Style { get; set; }
        public string MessageErreur { get; set; }

        public StyleAdminViewModel()
        {
            Style = new Style();
            Style.Libelle = "";
            MessageErreur = null;

        }
    }
}
