using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Webzine.Entity;
using Webzine.WebApplication.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Webzine.WebApplication.Controllers
{
    public class StyleController : Controller
    {
        
        public IActionResult Index(int id)
        {
            Style style = Startup.istyleRepository.Find(id);
            return View(style);
        }
    }
}
