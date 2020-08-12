using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Webzine.Business;
using Webzine.Business.Contracts;
using Webzine.Entity;
using Webzine.WebApplication.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Webzine.WebApplication.Controllers
{
    public class TitreController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index(int id)
        {
            TitreViewModel titreViewModel = new TitreViewModel();
            IncrementeNbVues(id);
            titreViewModel.Titre = Startup.ititreRepository.Find(id);
            return View(titreViewModel);
        }

        /// <summary>
        /// La méthode effectue le traitement pour ajouter un commentaire
        /// </summary>
        /// <param name="commentaire">Objet Commentaire à ajouter</param>
        /// <returns>Une redirection vers l'index du titre</returns>
        [HttpPost]
        public IActionResult ActionAddCommentaire(Commentaire commentaire)
        {
            commentaire.DateCreation = DateTime.Now;
            var titre = Startup.ititreRepository.Find(commentaire.IdTitre);
            commentaire.Musique = titre;
            Startup.icommentaireRepository.Add(commentaire);
            return RedirectToAction("Index", new { id = commentaire.IdTitre });
        }

        /// <summary>
        /// La méthode effectue le traitement d'incrémentation du nombre de like
        /// </summary>
        /// <param name="titre">Objet titre dont il faut augmenter le nombre de like</param>
        /// <returns>Une redirection vers l'index du titre</returns>
        [HttpPost]
        public IActionResult ActionLike(Titre titre)
        {

            ITitreService titreService = new TitreService();
            titreService.IncrementeNbLikes(titre.IdTitre, Startup.ititreRepository);
            return RedirectToAction("Index", new { id = titre.IdTitre });
        }

        /// <summary>
        /// La méthode effectue le traitement pour incrémenter le nombre de vue
        /// </summary>
        /// <param name="id">Identifiant du Titre dont il faut augmenter le nombre de vue</param>
        public void IncrementeNbVues(int id)
        {
            Startup.ititreRepository.IncrementNbLectures(Startup.ititreRepository.Find(id));
        }
    }
}
