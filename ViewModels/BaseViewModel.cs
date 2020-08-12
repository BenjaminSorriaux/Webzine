using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webzine.Entity;

namespace Webzine.WebApplication.ViewModels
{
    public class BaseViewModel
    {
        public List<Style> Styles { get; set; }
        public string MessageErreur { get; set; }

    }
}
