using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Webzine.WebApplication.ViewModels;

namespace Webzine.WebApplication.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var config = Startup.Configuration;
            TitresViewModel titresViewModel = new TitresViewModel();
            titresViewModel.TitresRecent = Startup.ititreRepository.FindTitresReçent(Int32.Parse(config["TitresRecent"])).ToList();
            titresViewModel.TitresPlusEcoutes = Startup.ititreRepository.FindTitresPopulaires(Int32.Parse(config["TitresPlusEcoutes"])).ToList();
            return this.View(titresViewModel);
        }
    }
}