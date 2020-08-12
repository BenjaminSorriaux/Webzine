using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webzine.WebApplication.ViewComponents
{
    public class StyleBar : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var styles = Startup.istyleRepository.FindAll().ToList();
            return View(styles);
        }
    }
}
