using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Webzine.WebApplication.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Webzine.WebApplication.Controllers
{
    public class SearchResultController : Controller
    {
        /// <summary>
        /// La méthode renvoie la vue contenant les artistes et les titres dont le paramètre de la recherche est contenu dans leur libellé
        /// </summary>
        /// <param name="search">Variable contenant la recherche de l'utilisateur</param>
        /// <returns>La vue avec en paramètre un view model contenant la liste de titres et la liste d'artistes renvoyé par la source de donnée</returns>
        public IActionResult Index(string search)
        {
            SearchViewModel searchViewModel = new SearchViewModel();

            if (search != null)
            {
                searchViewModel.Artistes = Startup.iartisteRepository.Find(search).ToList();
                searchViewModel.Titres = Startup.ititreRepository.Search(search).ToList();
                return View(searchViewModel);
            }
            else
            {
                searchViewModel.Artistes = new List<Entity.Artiste>();
                searchViewModel.Titres = new List<Entity.Titre>();
                return View(searchViewModel);
            }
        }
    }
}
