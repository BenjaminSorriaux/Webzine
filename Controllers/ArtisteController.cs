using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Webzine.WebApplication.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Webzine.WebApplication.Administration.Controllers
{
    public class ArtisteController : Controller
    {

        public IActionResult Index(int id)
        {
            ArtisteViewModel artisteViewModel = new ArtisteViewModel
            {
                Artiste = Startup.iartisteRepository.Find(id)
            };
            artisteViewModel.TitresParAlbum = artisteViewModel.Artiste.Titres.GroupBy(t => t.UrlJaquette);
            return View(artisteViewModel);
        }
    }
}
